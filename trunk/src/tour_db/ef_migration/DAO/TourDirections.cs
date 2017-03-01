using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourDirections
    {
        public TourDirections()
        {
            TourDirectionsPath = new HashSet<TourDirectionsPath>();
        }

        public int TourDirectionId { get; set; }
        public int? ActivityId { get; set; }
        public int? TransportationId { get; set; }
        public int DirectionTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TourDirectionsPath> TourDirectionsPath { get; set; }
        public virtual TourActivities Activity { get; set; }
        public virtual TourDirectionType DirectionType { get; set; }
        public virtual TourTransportations Transportation { get; set; }
    }
}
