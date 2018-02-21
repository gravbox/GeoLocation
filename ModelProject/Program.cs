using CsvHelper;
using Gravitybox.GeoLocation.EFDAL;
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
