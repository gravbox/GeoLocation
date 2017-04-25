using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gravitybox.GeoLocation.Interfaces;

namespace Gravitybox.Webservice.GeoLocationService
{
    internal static class Extensions
    {
        public static StateInfo ToStateInfo(this LocationService.EFDAL.Entity.State state)
        {
            return new StateInfo()
            {
                Id = state.StateId,
                Name = state.Name,
                Abbr = state.Abbr,
            };
        }

        public static ZipInfo ToZipInfo(this LocationService.EFDAL.Entity.Zip zip)
        {
            var retval = new ZipInfo()
            {
                ID = zip.ZipId,
                Name = zip.Name,
                City = zip.City,
                State = zip.State,
            };

            if (zip.Latitude != null && zip.Longitude != null)
            {
                retval.Latitude = zip.Latitude.Value;
                retval.Longitude = zip.Longitude.Value;
            }

            return retval;

        }

    }
}