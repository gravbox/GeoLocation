using System;
using System.Runtime.Serialization;

namespace Gravitybox.GeoLocation.Interfaces
{
    [Serializable()]
    [DataContract]
    public class StateInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Abbr { get; set; }
    }
}