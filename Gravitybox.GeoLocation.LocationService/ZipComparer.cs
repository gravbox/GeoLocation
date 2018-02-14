using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gravitybox.GeoLocation.EFDAL.Entity;

namespace Gravitybox.GeoLocation.LocationService
{
    internal class ZipComparer : IEqualityComparer<EFDAL.Entity.Zip>
    {
        public bool Equals(Zip x, Zip y)
        {
            if (x == null && y == null) return true;
            if (x != null && y == null) return false;
            if (x == null && y != null) return false;
            return x.City == y.City && x.State == y.State;
        }

        public int GetHashCode(Zip obj)
        {
            return (obj?.City + "|" + obj?.State).GetHashCode();
        }
    }
}