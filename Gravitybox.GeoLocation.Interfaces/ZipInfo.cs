using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Runtime.Serialization;

namespace Gravitybox.GeoLocation.Interfaces
{
    [Serializable()]
    [DataContract]
    public class ZipInfo
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.City) && !string.IsNullOrEmpty(this.State) && !string.IsNullOrEmpty(this.Name))
                return $"{this.City}, {this.State} {this.Name}";
            else if (!string.IsNullOrEmpty(this.City) && !string.IsNullOrEmpty(this.State))
                return $"{this.City}, {this.State}";
            else if (!string.IsNullOrEmpty(this.City))
                return $"{this.Name}";
            else
                return string.Empty;
        }
    }
}