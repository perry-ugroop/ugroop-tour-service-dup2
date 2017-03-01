//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace UGroopData.Sql.Repository2.Data
//{
//    [Table("Tour_Transportation_Flight")]
//    public class TourTransportationFlight : TourTransportations {
//        public string FlightNo { get; set; }                           
//    }
//}

using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourTransportationFlight {
        public int TransportationFlightId { get; set; }
        public int TransportationId { get; set; }
        public string FlightNo { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourTransportations Transportation { get; set; }
    }
}

