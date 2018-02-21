using System;
using System.Collections.Generic;
using System.Linq;
using Gravitybox.GeoLocation.Interfaces;
using System.Xml;
using Gravitybox.GeoLocation.EFDAL;
using System.Diagnostics;
using System.Text;

namespace Gravitybox.GeoLocation.LocationService
{
    public class GeoLocationService : IGeoLocationService
    {
        #region IGeoLocationService Members

        public ZipInfo GetZip(string term)
        {
            var item = Lookup(term).FirstOrDefault();
            if (item == null) return null;
            return item.ToZipInfo();
        }

        public ZipInfo GetZipFromCoordinates(double latitude, double longitude, bool isExact = true)
        {
            try
            {
                using (var context = new GeoLocationEntities())
                {
                    var z = context.Zip.FirstOrDefault(x => x.Latitude == latitude && x.Longitude == longitude);
                    if (isExact && z == null) return null;
                    if (z == null)
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("select top 1 z.*, dbo.CalcDistance(" + latitude + ", " + longitude + ", z.Latitude, z.Longitude) as distance");
                        sb.AppendLine("from zip z");
                        sb.AppendLine("order by dbo.CalcDistance(" + latitude + ", " + longitude + ", z.Latitude, z.Longitude)");

                        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GeoLocationEntities"].ConnectionString;
                        var ds = SqlHelper.GetDataset(connectionString, sb.ToString());
                        if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
                        {
                            var zipId = (int)ds.Tables[0].Rows[0]["zipid"];
                            z = context.Zip.FirstOrDefault(x => x.ZipId == zipId);
                        }
                        if (z == null) return null;
                    }
                    return z.ToZipInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        public ZipInfo GetZipFromCityState(string city, string state)
        {
            var found = false;
            var timer = Stopwatch.StartNew(); 
            try
            {
                if (string.IsNullOrEmpty(state)) return null;
                using (var context = new GeoLocationEntities())
                {
                    //If it is Not an abbr then find by name
                    if (state.Length != 2)
                        state = context.State.Where(x => x.Name == state).Select(x => x.Abbr).FirstOrDefault();

                    var list = context.Zip.Where(x =>
                                                 x.City == city &&
                                                 x.State == state)
                                      .ToList();

                    if (list.Count > 0)
                    {
                        found = true;
                        return list.First().ToZipInfo();
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
            finally
            {
                timer.Stop();
                Logger.LogInfo("GetZipFromCityState: Elapsed=" + timer.ElapsedMilliseconds + ", Found=" + found + ", Term=" + city + "|" + state);
            }
        }

        public bool IsZipValid(string zipCode)
        {
            try
            {
                //Logger.LogInfo("IsZipValid: " + zipCode);
                return (GetZip(zipCode) != null);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        public StateInfo GetStateInfo(string name)
        {
            try
            {
                //Error Check
                if (string.IsNullOrEmpty(name))
                    return null;

                using (var context = new GeoLocationEntities())
                {
                    return context.State
                                  .Where(x => x.Name == name || x.Abbr == name)
                                  .Select(x => new StateInfo()
                                  {
                                      Abbr = x.Abbr,
                                      Name = x.Name,
                                      Id = x.StateId,
                                  })
                                  .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        public List<StateInfo> GetStateList()
        {
            try
            {
                var retval = new List<StateInfo>();
                using (var context = new GeoLocationEntities())
                {
                    return context.State.Select(x => new StateInfo()
                    {
                        Abbr = x.Abbr,
                        Name = x.Name,
                        Id = x.StateId,
                    })
                                  .ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        public List<string> GetLookup(string term)
        {
            return Lookup(term).Select(x => (x.City + ", " + x.State + " " + x.Name).Trim()).ToList();
        }

        private List<EFDAL.Entity.Zip> Lookup(string term)
        {
            try
            {
                var retval = new List<EFDAL.Entity.Zip>();
                if (string.IsNullOrEmpty(term)) return retval;

                //Strip comma in case have not enter state yet
                term = term.TrimEnd(new char[] { ',' });

                //Now search for the different location formats
                using (var context = new GeoLocationEntities())
                {
                    //If numeric then assume it is zip
                    if (int.TryParse(term, out int zipCode))
                    {
                        //If zip code then return zips
                        retval.AddRange(
                            context.Zip
                            .Where(x => x.Name.Contains(term))
                            .ToList());
                        Logger.LogInfo($"GetLookup: Path1, Count={retval.Count}");
                        return retval;
                    }

                    //If two strings with comma then assume city state
                    var arr = term.Split(',');
                    if (arr.Length == 2)
                    {
                        var cityValue = arr[0].Trim();
                        var stateValue = arr[1].Trim();
                        var zipValue = string.Empty;

                        //If there is numeric ZIP on the end then split it out too
                        var arr2 = stateValue.Split(' ');
                        if (arr2.Length == 2 && arr2[1].ToInt32() > 0)
                        {
                            stateValue = arr2[0].Trim();
                            zipValue = arr2[1].Trim();
                        }

                        //If there is a ZIP then use it
                        //Zips can span cities so there may be multiple
                        var zipItems = context.Zip
                            .Where(x => x.Name == zipValue)
                            .ToList();

                        EFDAL.Entity.Zip singleZip = null;

                        //If there is a ZIP code included and not a single match
                        //determine if can match city, state
                        if (!string.IsNullOrEmpty(zipValue) && zipItems.Count > 1)
                        {
                            var lmabda = zipItems.Where(x => x.City.ToLower() == cityValue.ToLower());
                            if (lmabda.Count() == 1)
                                singleZip = lmabda.First();
                        }

                        if (singleZip == null && zipItems.Count == 1)
                            singleZip = zipItems.FirstOrDefault();
                        else if (singleZip == null) //Look for specific city, state
                        {
                            singleZip = context.Zip.FirstOrDefault(x => x.City == cityValue && x.State == stateValue);
                            if (singleZip == null)
                            {
                                singleZip = context.Zip.FirstOrDefault(x => x.City.Contains(cityValue) && x.State == stateValue);
                            }
                        }

                        //If the ZIP was found then return it
                        if (singleZip != null)
                        {
                            retval.Add(singleZip);
                        }

                        //If it was not found then look again, less specifically
                        if (!retval.Any())
                        {
                            var state = context.State.FirstOrDefault(x => x.Name.Contains(stateValue) || x.Abbr == stateValue);
                            if (state != null)
                                stateValue = state.Abbr;

                            //If (city AND state) match OR (city and ZIP) match OR (city, state zip)
                            var list = (from z in context.Zip
                                        join c in context.City on new { z.City, z.State } equals new { City = c.Name, c.State } into q
                                        from c in q.DefaultIfEmpty()
                                        where ((z.City.Contains(cityValue) && (z.State.Contains(stateValue))) ||
                                                (z.City.Contains(cityValue) && (z.Name.Contains(stateValue))))
                                        orderby c.Population descending
                                        select new { z, c })
                                    .ToList()
                                    .Select(x => new EFDAL.Entity.Zip { City = x.z.City, State = x.z.State, Population = x.c?.Population, Latitude = x.z.Latitude, Longitude = x.z.Longitude }) //, Name = x.Name
                                    .Distinct(new ZipComparer())
                                    .OrderByDescending(x => x.Population)
                                    .Take(50)
                                    .ToList();

                            retval.AddRange(list);
                        }
                        Logger.LogInfo($"GetLookup: Path2, Count={retval.Count}");
                    }
                    else
                    {
                        //Group by city/state and sum population so can order by largest overall population, not individual zip code

                        var list = (from z in context.Zip
                                    join c in context.City on new { z.City, z.State } equals new { City = c.Name, c.State } into q
                                    from c in q.DefaultIfEmpty()
                                    where (z.City.Contains(term) || z.Name.Contains(term) || z.State.Contains(term))
                                    orderby c.Population descending
                                    select new { z, c })
                                .ToList()
                                .Select(x => new EFDAL.Entity.Zip { City = x.z.City, State = x.z.State, Population = x.c?.Population, Latitude = x.z.Latitude, Longitude = x.z.Longitude }) //, Name = x.Name
                                .OrderByDescending(x => x.Population)
                                .Distinct(new ZipComparer())                                
                                .Take(50)
                                .ToList();

                        retval.AddRange(list);
                        Logger.LogInfo($"GetLookup: Path3, Count={retval.Count}");
                    }

                    return retval;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        #endregion

    }
}