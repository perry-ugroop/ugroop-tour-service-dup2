//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace UGroopData.Sql.Repository2.Data
//{
//    [Table("Tour_Transportation_Car")]
//    public class TourTransportationCar  : TourTransportations {
//        public string CarType { get; set; }
//    }
//}

using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourTransportationCar {
        public int TransportationCarId { get; set; }
        public int TransportationId { get; set; }
        public string CarType { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourTransportations Transportation { get; set; }
    }
}

