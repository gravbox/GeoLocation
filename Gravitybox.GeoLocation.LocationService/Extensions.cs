using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gravitybox.GeoLocation.Interfaces;

namespace Gravitybox.GeoLocation.LocationService
{
    internal static class Extensions
    {
        public static StateInfo ToStateInfo(this EFDAL.Entity.State state)
        {
            return new StateInfo()
            {
                Id = state.StateId,
                Name = state.Name,
                Abbr = state.Abbr,
            };
        }

        public static ZipInfo ToZipInfo(this EFDAL.Entity.Zip zip)
        {
            var retval = new ZipInfo()
            {
                ID = zip.ZipId,
                Name = zip.Name,
                City = zip.City,
                State = zip.State,
                Country = zip.Country ?? "US",
            };
            if (zip.Latitude != null && zip.Longitude != null)
            {
                retval.Latitude = zip.Latitude.Value;
                retval.Longitude = zip.Longitude.Value;
            }
            return retval;
        }

        public static int ToInt32(this string v)
        {
            if (v == null) return 0;
            int.TryParse(v, out int r);
            return r;
        }

    }
}