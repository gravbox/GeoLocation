using System.ComponentModel.DataAnnotations.Schema;

namespace Gravitybox.GeoLocation.EFDAL.Entity
{
    partial class Zip
    {
        /// <summary />
        public override string ToString()
        {
            return $"{this.City}, {this.State} {this.Name}";
        }

        /// <summary />
        [NotMapped]
        public string Country { get; set; }
    }
}