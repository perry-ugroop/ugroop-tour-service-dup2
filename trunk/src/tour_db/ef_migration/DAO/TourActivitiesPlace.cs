using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourActivitiesPlace
    {
        public int ActivityPlaceId { get; set; }
        public int? ActivityId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourActivities Activity { get; set; }
    }
}
