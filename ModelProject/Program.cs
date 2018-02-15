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
            var index = 0;
            var connectionString = @"server=.\SQL2014;initial catalog=GeoLocation;integrated security=SSPI;";
            using (var context = new GeoLocationEntities(connectionString))
            {
                var allZips = context.Zip.ToList();
                using (var sr = new StreamReader(@"C:\Users\chrisd\Downloads\Zipcode-ZCTA-Population-Density-And-Area-Unsorted.csv"))
                {
                    using (var csv = new CsvReader(sr))
                    {
                        while (csv.Read())
                        {
                            var record = csv.GetRecord<ZipItem>();
                            if (record.Population > 0)
                            {
                                var dbZip = allZips.FirstOrDefault(x => x.Name == record.Zip);
                                if (dbZip != null)
                                {
                                    Console.WriteLine($"Index={index}, Zip={record.Zip}, Population1={record.Population}, Population2={dbZip.Population}");
                                    dbZip.Population = record.Population;
                                }
                            }
                            index++;
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }

    internal class ZipItem
    {
        public string Zip { get; set; }
        public int Population { get; set; }
    }
}
