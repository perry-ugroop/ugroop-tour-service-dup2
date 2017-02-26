//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace UGroopData.Sql.Repository2.Data
//{
//    [Table("Tour_Transportation_Train")]
//    public class TourTransportationTrain: TourTransportations {
//        public string StationName { get; set; }
//    }
//}

using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourTransportationTrain {
        public int TransportationTrainId { get; set; }
        public int TransportationId { get; set; }
        public string StationName { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourTransportations Transportation { get; set; }
    }
}

