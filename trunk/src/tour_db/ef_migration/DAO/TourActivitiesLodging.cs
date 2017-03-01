//using System.ComponentModel.DataAnnotations.Schema;

//namespace UGroopData.Sql.Repository2.Data
//{
//    [Table("Tour_Activities_Lodging")]
//    public class TourActivitiesLodging : TourActivities {
//        public string LodgingName { get; set; }
//        public string LodgingPlace { get; set; }
//    }
//}

using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourActivitiesLodging {
        public int ActivityLodgingId { get; set; }
        public int ActivityId { get; set; }
        public string LodgingName { get; set; }
        public string LodgingPlace { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourActivities Activity { get; set; }
    }
}

