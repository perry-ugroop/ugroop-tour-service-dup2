//using System.ComponentModel.DataAnnotations.Schema;

//namespace UGroopData.Sql.Repository2.Data
//{
//    [Table("Tour_Activities_Meeting")]
//    public class TourActivitiesMeeting : TourActivities {
//        public string MeetingName { get; set; }
//        public string MeetingPlace { get; set; }
//    }
//}

using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourActivitiesMeeting {
        public int ActivityMeetingId { get; set; }
        public int ActivityId { get; set; }
        public string MeetingName { get; set; }
        public string MeetingPlace { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourActivities Activity { get; set; }
    }
}

