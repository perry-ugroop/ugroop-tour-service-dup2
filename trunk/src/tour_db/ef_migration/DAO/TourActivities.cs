//using System;
//using System.Collections.Generic;

//namespace UGroopData.Sql.Repository2.Data
//{
//    public partial class TourActivities
//    {
//        public TourActivities()
//        {
//            TourActivitiesPlace = new HashSet<TourActivitiesPlace>();
//            TourAttachment = new HashSet<TourAttachment>();
//            TourDirections = new HashSet<TourDirections>();
//        }

//        public int ActivityId { get; set; }
//        public int TourPlanId { get; set; }
//        public int TourId { get; set; }
//        public int ActivityTypeId { get; set; }
//        public DateTime DateCreated { get; set; }
//        public bool? IsActive { get; set; }

//        public virtual ICollection<TourActivitiesPlace> TourActivitiesPlace { get; set; }
//        public virtual ICollection<TourAttachment> TourAttachment { get; set; }
//        public virtual ICollection<TourDirections> TourDirections { get; set; }
//        public virtual TourActivityType ActivityType { get; set; }
//        public virtual TourPlan TourPlan { get; set; }
//    }
//}


using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourActivities {
        public TourActivities() {
            TourActivitiesDining = new HashSet<TourActivitiesDining>();
            TourActivitiesLodging = new HashSet<TourActivitiesLodging>();
            TourActivitiesMeeting = new HashSet<TourActivitiesMeeting>();
            TourActivitiesPlace = new HashSet<TourActivitiesPlace>();
            TourAttachment = new HashSet<TourAttachment>();
            TourDirections = new HashSet<TourDirections>();
        }

        public int ActivityId { get; set; }
        public int TourPlanId { get; set; }
        public int TourId { get; set; }
        public int ActivityTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TourActivitiesDining> TourActivitiesDining { get; set; }
        public virtual ICollection<TourActivitiesLodging> TourActivitiesLodging { get; set; }
        public virtual ICollection<TourActivitiesMeeting> TourActivitiesMeeting { get; set; }
        public virtual ICollection<TourActivitiesPlace> TourActivitiesPlace { get; set; }
        public virtual ICollection<TourAttachment> TourAttachment { get; set; }
        public virtual ICollection<TourDirections> TourDirections { get; set; }
        public virtual TourActivityType ActivityType { get; set; }
        public virtual TourPlan TourPlan { get; set; }
    }
}
