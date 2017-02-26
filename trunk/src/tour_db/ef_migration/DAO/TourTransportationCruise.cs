//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace UGroopData.Sql.Repository2.Data
//{
//    [Table("Tour_Transportation_Cruise")]
//    public class TourTransportationCruise  : TourTransportations {
//        public string ShipName { get; set; }
//    }
//}

using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourTransportationCruise {
        public int TransportationCruiseId { get; set; }
        public int TransportationId { get; set; }
        public string ShipName { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourTransportations Transportation { get; set; }
    }
}


