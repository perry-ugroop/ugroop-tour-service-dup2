using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourDirectionsPath
    {
        public int DirectionPathId { get; set; }
        public int TourDirectionId { get; set; }
        public int? AirportId { get; set; }
        public int? TimeZoneId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? IsActive { get; set; }

        public virtual Airports Airport { get; set; }
        public virtual TimeZone TimeZone { get; set; }
        public virtual TourDirections TourDirection { get; set; }
    }
}
