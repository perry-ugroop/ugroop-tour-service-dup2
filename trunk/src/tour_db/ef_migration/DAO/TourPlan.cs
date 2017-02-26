using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourPlan
    {
        public TourPlan()
        {
            TourActivities = new HashSet<TourActivities>();
            TourNote = new HashSet<TourNote>();
            TourTransportations = new HashSet<TourTransportations>();
        }

        public int TourPlanId { get; set; }
        public int TourId { get; set; }
        public int? PlanTypeId { get; set; }
        public string PlanName { get; set; }
        public DateTime? PlanDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TourActivities> TourActivities { get; set; }
        public virtual ICollection<TourNote> TourNote { get; set; }
        public virtual ICollection<TourTransportations> TourTransportations { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
