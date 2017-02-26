//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

//namespace UGroopData.Sql.Repository2.Data
//{
//    //[Table("Tour_Transportations")]
//    public abstract class TourTransportations
//    {
//        public TourTransportations()
//        {
//            TourDirections = new HashSet<TourDirections>();
//        }

//        public int TransportationId { get; set; }
//        public int TourPlanId { get; set; }
//        public int TransportationTypeId { get; set; }
//        public DateTime DateCreated { get; set; }
//        public bool? IsActive { get; set; }

//        public virtual ICollection<TourDirections> TourDirections { get; set; }
//        public virtual TourPlan TourPlan { get; set; }
//        public virtual TourTransportationType TransportationType { get; set; }
//    }
//}


using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data {
    public partial class TourTransportations {
        public TourTransportations() {
            TourDirections = new HashSet<TourDirections>();
            TourTransportationCar = new HashSet<TourTransportationCar>();
            TourTransportationCruise = new HashSet<TourTransportationCruise>();
            TourTransportationFlight = new HashSet<TourTransportationFlight>();
            TourTransportationTrain = new HashSet<TourTransportationTrain>();
        }

        public int TransportationId { get; set; }
        public int TourPlanId { get; set; }
        public int TransportationTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TourDirections> TourDirections { get; set; }
        public virtual ICollection<TourTransportationCar> TourTransportationCar { get; set; }
        public virtual ICollection<TourTransportationCruise> TourTransportationCruise { get; set; }
        public virtual ICollection<TourTransportationFlight> TourTransportationFlight { get; set; }
        public virtual ICollection<TourTransportationTrain> TourTransportationTrain { get; set; }
        public virtual TourPlan TourPlan { get; set; }
        public virtual TourTransportationType TransportationType { get; set; }
    }
}


