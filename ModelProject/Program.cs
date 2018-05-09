using CsvHelper;
using Gravitybox.GeoLocation.EFDAL;
using Gravitybox.GeoLocation.EFDAL.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModelProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //ResetPopulations();
            //CleanCity();
            //DumpSQL();
            //CheckCanada();

            Console.WriteLine("Press <ENTER> to end...");
            Console.ReadLine();
        }

        private static void CheckCanada()
        {
            try
            {
                var notFound = 0;
                var total = 0;
                var missed = 0;
                var connectionString = @"server=.\SQL2014;initial catalog=GeoLocation;integrated security=SSPI;";
                using (var context = new GeoLocationEntities(connectionString))
                {
                    using (var textReader = File.OpenText(@"C:\temp\CanadianZipCodes201805.csv"))
                    {
                        using (var csv = new CsvReader(textReader))
                        {
                            while (csv.Read())
                            {
                                var postalCode = csv.GetField<string>(0).Replace(" ", "").Trim();
                                var city = csv.GetField<string>(1);
                                var prov = csv.GetField<string>(2);

                                if (!context.CanadaPostalCode.Any(x => x.PostalCode == postalCode))
                                {
                                    notFound++;
                                    Console.WriteLine($"Total={total}, NotFound={notFound}, PostalCode={postalCode}");

                                    //Get same city
                                    var template = context.CanadaPostalCode.FirstOrDefault(x => x.City == city);

                                    if (template != null)
                                    {
                                        //Add new
                                        context.AddItem(new CanadaPostalCode { PostalCode = postalCode, City = template.City, Latitude = template.Latitude, Longitude = template.Longitude });
                                        context.SaveChanges();
                                    }
                                    else missed++;
                                }
                                total++;
                            }
                        }
                    }
                }

                Console.WriteLine($"Total={total}, NotFound={notFound}, Missed={missed}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void DumpSQL()
        {
            try
            {
                var connectionString = @"server=.\SQL2014;initial catalog=GeoLocation;integrated security=SSPI;";
                using (var context = new GeoLocationEntities(connectionString))
                {
                    var allZips = context.City.OrderBy(x => x.Name).ThenBy(x => x.State).ToList();
                    var sb  = new StringBuilder();
                    foreach(var item in allZips)
                    {
                        sb.AppendLine($"INSERT INTO [City]([Name],[State],[Population]) VALUES ('{item.Name.Replace("'","''")}','{item.State}',{item.Population});");
                    }
                    File.WriteAllText(@"c:\temp\city-gen.sql", sb.ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void CleanCity()
        {
            try
            {
                var index = 0;
                var connectionString = @"server=.\SQL2014;initial catalog=GeoLocation;integrated security=SSPI;";
                using (var context = new GeoLocationEntities(connectionString))
                {
                    var allZips = context.City.ToList();

                    //Set to largest population
                    Dictionary<string, int> _cache = new Dictionary<string, int>();
                    foreach (var item in allZips)
                    {
                        var key = (item.Name + "|" + item.State).ToLower();
                        if (!_cache.ContainsKey(key))
                        {
                            _cache.Add(key, item.Population ?? 0);
                        }

                        var newPopulation = item.Population ?? 0;
                        if (_cache[key] < newPopulation)
                            _cache[key] = newPopulation;

                        index++;
                        Console.WriteLine($"Loop 1: Index={index}, Count={allZips.Count}");
                    }

                    index = 0;
                    //Reset the populations
                    foreach (var item in allZips)
                    {
                        var key = (item.Name + "|" + item.State).ToLower();
                        item.Population = _cache[key];
                        index++;
                        Console.WriteLine($"Loop 2: Index={index}, Count={allZips.Count}");
                    }
                    context.SaveChanges();
                    allZips = context.City.ToList();

                    //Delete duplicates
                    index = 0;
                    var dups = new HashSet<int>();
                    _cache = new Dictionary<string, int>();
                    foreach (var item in allZips)
                    {
                        var key = (item.Name + "|" + item.State).ToLower();
                        if (_cache.ContainsKey(key))
                            dups.Add(item.CityId);
                        else
                            _cache.Add(key, 0);
                        index++;
                        Console.WriteLine($"Loop 3: Index={index}, Count={allZips.Count}");
                    }

                    index = 0;
                    foreach (var key in dups)
                    {
                        context.City.Where(x => x.CityId == key).Delete();
                        context.SaveChanges();
                        Console.WriteLine($"Loop 4: Index={index}, Count={dups.Count}");
                    }

                    Console.WriteLine("Done");

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void ResetPopulations()
        {
            try
            {
                var index = 0;
                var connectionString = @"server=.\SQL2014;initial catalog=GeoLocation;integrated security=SSPI;";
                using (var context = new GeoLocationEntities(connectionString))
                {
                    var allZips = context.City.ToList();
                    var states = context.State.ToList();
                    var input = @"C:\temp\cities.csv";
                    using (var sr = new StreamReader(input))
                    {
                        using (var csv = new CsvReader(sr))
                        {
                            while (csv.Read())
                            {
                                var record = csv.GetRecord<CityItem>();
                                var population = record.Population.ToInt();
                                if (population > 0)
                                {
                                    var state = states.Where(x => x.Name.Match(record.State)).Select(x => x.Abbr).FirstOrDefault();
                                    var dbZip = allZips.FirstOrDefault(x => x.Name.Match(record.City) && x.State == state);
                                    if (dbZip == null)
                                    {
                                        context.AddItem(new Gravitybox.GeoLocation.EFDAL.Entity.City { Name = record.City, Population = population, State = state });
                                        Console.WriteLine($"Index={index}, Action=Add, City={record.City}, State={state}, Population={record.Population}");
                                    }
                                    else if (dbZip != null && dbZip.Population != population)
                                    {
                                        Console.WriteLine($"Index={index}, Action=Update, City={record.City}, State={state}, Population={record.Population}, Population2={dbZip.Population}");
                                        dbZip.Population = population;
                                    }
                                }
                                index++;
                            }
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    internal class CityItem
    {
        public int ID { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Population { get; set; }
    }

    internal static class Extensions
    {
        public static int ToInt(this string v)
        {
            if (string.IsNullOrEmpty(v)) return 0;
            v = v.Replace(",", string.Empty);
            int parsed;
            int.TryParse(v, out parsed);
            return parsed;
        }

        public static bool Match(this string s, string str)
        {
            if (s == null && str == null) return true;
            if (s != null && str == null) return false;
            if (s == null && str != null) return false;
            return string.Equals(s, str, StringComparison.InvariantCultureIgnoreCase);
        }

    }
}
