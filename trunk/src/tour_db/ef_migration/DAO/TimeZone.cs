using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TimeZone
    {
        public TimeZone()
        {
            TourDirectionsPath = new HashSet<TourDirectionsPath>();
        }

        public int TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
        public string TimeZoneAbbr { get; set; }
        public string TimeZoneUtc { get; set; }
        public string TimeGmt { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TourDirectionsPath> TourDirectionsPath { get; set; }
    }
}
