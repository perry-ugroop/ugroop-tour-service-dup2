using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourNote
    {
        public int TourNoteId { get; set; }
        public int TourId { get; set; }
        public int TourPlanId { get; set; }
        public string Note { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public string StartTimeZone { get; set; }
        public string StartTimeCounterpart { get; set; }
        public string Photo { get; set; }
        public string PhotoCaption { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourPlan Tour { get; set; }
    }
}
