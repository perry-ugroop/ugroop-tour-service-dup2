using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourReview
    {
        public int ReviewId { get; set; }
        public int? AccountId { get; set; }
        public int? TourId { get; set; }
        public string ReviewText { get; set; }
        public bool? IsActive { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
