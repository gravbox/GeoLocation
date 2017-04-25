using System;
using System.Collections.Generic;
using System.Linq;
using Gravitybox.GeoLocation.Interfaces;
using System.Xml;
using Gravitybox.LocationService.EFDAL;
using System.Diagnostics;
using System.Text;

namespace Gravitybox.Webservice.GeoLocationService
{
    public class GeoLocationService : IGeoLocationService
    {
        #region IGeoLocationService Members

        public ZipInfo GetZip(string term)
        {
            var found = false;
            var timer = Stopwatch.StartNew();
            try
            {
                //Error Check
                if (string.IsNullOrEmpty(term))
                    return null;

                using (var context = new LocationServiceEntities())
                {
                    var zip = context.Zip.FirstOrDefault(x => x.Name == term);
                    if (zip != null)
                    {
                        found = true;
                        return zip.ToZipInfo();
                    }

                    var arr = term.Split(',');
                    if (arr.Length == 2)
                    {
                        var cityValue = arr[0].Trim();
                        var stateValue = arr[1].Trim();

                        var state = GetStateInfo(stateValue);
                        if (state == null) state = new StateInfo() { Name = stateValue, Abbr = stateValue };

                        zip = context.Zip.FirstOrDefault(x => x.City == cityValue && (x.State == state.Name || x.State == state.Abbr));
                        if (zip != null)
                        {
                            found = true;
                            return zip.ToZipInfo();
                        }
                    }

                    var stateRaw = arr[arr.Length - 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var protoZip = stateRaw.Last();
                    int zipCode;
                    if (int.TryParse(protoZip, out zipCode))
                    {
                        stateRaw.RemoveAt(stateRaw.Count - 1);
                        var cityValue = arr[0].Trim();
                        var stateValue = string.Join(" ", stateRaw).Trim();
                        var zipValue = zipCode.ToString("00000");

                        var state = GetStateInfo(stateValue);
                        if (state == null) state = new StateInfo() { Name = stateValue, Abbr = stateValue };

                        zip = context.Zip.FirstOrDefault(x =>
                            x.City == cityValue &&
                            (x.State == state.Name || x.State == state.Abbr) &&
                            x.Name == zipValue);
                        if (zip != null)
                        {
                            found = true;
                            return zip.ToZipInfo();
                        }
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
                Logger.LogInfo("GetZip: Elapsed=" + timer.ElapsedMilliseconds + ", Found=" + found + ", Term=" + term);
            }
        }

        public ZipInfo GetZipFromCoordinates(double latitude, double longitude, bool isExact = true)
        {
            try
            {
                using (var context = new LocationServiceEntities())
                {
                    var z = context.Zip.FirstOrDefault(x => x.Latitude == latitude && x.Longitude == longitude);
                    if (isExact && z == null) return null;
                    if (z == null)
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("select top 1 z.*, dbo.CalcDistance(" + latitude + ", " + longitude + ", z.Latitude, z.Longitude) as distance");
                        sb.AppendLine("from zip z");
                        sb.AppendLine("order by dbo.CalcDistance(" + latitude + ", " + longitude + ", z.Latitude, z.Longitude)");

                        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LocationServiceEntities"].ConnectionString;
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
                using (var context = new LocationServiceEntities())
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

                using (var context = new LocationServiceEntities())
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
                using (var context = new LocationServiceEntities())
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
            try
            {
                var retval = new List<string>();
                if (string.IsNullOrEmpty(term)) return retval;

                using (var context = new LocationServiceEntities())
                {
                    //If numeric then assuem it is zip
                    int zipCode;
                    if (int.TryParse(term, out zipCode))
                    {
                        //If zip code then return zips
                        retval.AddRange(
                            context.Zip
                            .Where(x => x.City.Contains(term) ||
                            x.Name.Contains(term) ||
                            x.State.Contains(term))
                            .Select(x => x.City + ", " + x.State + " " + x.Name)
                            .ToList());
                        return retval;
                    }

                    //If two strings with comma then assume city state
                    var arr = term.Split(',');
                    if (arr.Length == 2)
                    {
                        var cityValue = arr[0].Trim();
                        var stateValue = arr[1].Trim();

                        var state = context.State.FirstOrDefault(x => x.Name.Contains(stateValue) || x.Abbr == stateValue);
                        if (state != null)
                            stateValue = state.Abbr;

                        //If (city AND state) match OR (city and ZIP) match
                        retval.AddRange(
                            context.Zip
                            .Where(x =>
                                (x.City.Contains(cityValue) &&
                                (x.State.Contains(stateValue))) ||
                                (x.City.Contains(cityValue) &&
                                (x.Name.Contains(stateValue))))
                                .OrderByDescending(x => x.Population)
                        .Select(x => new { cs = x.City + ", " + x.State, x.Population })
                        .Distinct()
                        .Take(30)
                        .ToList()
                        .OrderByDescending(x => x.Population)
                        .Select(x => x.cs));
                    }
                    else
                    {
                        retval.AddRange(
                            context.Zip
                            .Where(x => x.City.Contains(term) ||
                                x.Name.Contains(term) ||
                                x.State.Contains(term))
                                .OrderByDescending(x => x.Population)
                        .Select(x => new { cs = x.City + ", " + x.State, x.Population })
                        .Distinct()
                        .Take(30)
                        .ToList()
                        .OrderByDescending(x => x.Population)
                        .Select(x => x.cs));
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