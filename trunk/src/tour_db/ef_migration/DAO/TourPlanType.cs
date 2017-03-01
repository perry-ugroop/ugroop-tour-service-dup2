using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourPlanType
    {
        public int TourPlanTypeId { get; set; }
        public int CategoryId { get; set; }
        public string PlanTypeName { get; set; }
        public bool? IsActive { get; set; }
    }
}
