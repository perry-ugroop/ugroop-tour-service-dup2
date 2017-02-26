using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourTransportationType
    {
        public TourTransportationType()
        {
            TourTransportations = new HashSet<TourTransportations>();
        }

        public int TransportationTypeId { get; set; }
        public string TransportationTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TourTransportations> TourTransportations { get; set; }
    }
}
