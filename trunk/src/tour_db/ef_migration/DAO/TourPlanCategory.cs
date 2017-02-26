using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourPlanCategory
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool? IsActive { get; set; }
    }
}
