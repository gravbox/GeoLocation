namespace Gravitybox.GeoLocation.Interfaces
{
    public class GeoLocationCode
    {
        #region Constructors

        public GeoLocationCode() { }

        public GeoLocationCode(double latitude, double longitude) : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion

        #region Property Implementations

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public bool IsValid
        {
            get { return (this.Latitude != 0) && (this.Longitude != 0); }
        }

        #endregion
    }
}