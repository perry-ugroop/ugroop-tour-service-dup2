using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourActivityType
    {
        public TourActivityType()
        {
            TourActivities = new HashSet<TourActivities>();
        }

        public int ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TourActivities> TourActivities { get; set; }
    }
}
