using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class Newsfeed
    {
        public int NewsfeedId { get; set; }
        public int AccountId { get; set; }
        public int TourId { get; set; }
        public string NewsfeedTitle { get; set; }
        public string NewsfeedContent { get; set; }
        public DateTime? NewsfeedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Tour Account { get; set; }
    }
}
