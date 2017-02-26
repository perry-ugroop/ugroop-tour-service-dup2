using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourDirectionType
    {
        public TourDirectionType()
        {
            TourDirections = new HashSet<TourDirections>();
        }

        public int DirectionTypeId { get; set; }
        public string DirectionTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TourDirections> TourDirections { get; set; }
    }
}
