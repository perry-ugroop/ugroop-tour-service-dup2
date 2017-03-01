using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class Airports
    {
        public Airports()
        {
            TourDirectionsPath = new HashSet<TourDirectionsPath>();
        }

        public int AirportId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Altitude { get; set; }
        public string Timezone { get; set; }
        public string Dst { get; set; }
        public string Tzdatabase { get; set; }

        public virtual ICollection<TourDirectionsPath> TourDirectionsPath { get; set; }
    }
}
