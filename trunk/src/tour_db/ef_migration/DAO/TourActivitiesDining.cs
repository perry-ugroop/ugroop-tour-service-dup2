//using System.ComponentModel.DataAnnotations.Schema;

//namespace UGroopData.Sql.Repository2.Data {
//    [Table("Tour_Activities_Dining")]
//    public class TourActivitiesDining : TourActivities {
//        public string DiningName { get; set; }
//        public string DiningPlace { get; set; }
//    }

//}

using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourActivitiesDining {
        public int ActivityDiningId { get; set; }
        public int ActivityId { get; set; }
        public string DiningName { get; set; }
        public string DiningPlace { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourActivities Activity { get; set; }
    }
}


