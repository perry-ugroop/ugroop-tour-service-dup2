using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourType
    {
        public TourType()
        {
            Tour = new HashSet<Tour>();
        }

        public int TourTypeId { get; set; }
        public string TourTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Tour> Tour { get; set; }
    }
}
