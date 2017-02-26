using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGroopData.Entity.ViewModel.SQL.Data;
using UGroopData.Utilities.String;

namespace Ugroop.API.SQL.Swagger.TestModel {



    public class Tour_Insert_Example : IProvideExamples {
        public object GetExamples()
        {
            var Tour_Insert = new Tour_Insert {
                AccountId = 1,
                OrgId = 1,
                TourTypeId = 1,
                TourName = "AAA",
                StartDate = Convert.ToDateTime("12/25/2030"),
                EndDate = Convert.ToDateTime("12/30/2030"),
                TourDescription = "AAA",
                DestinationCity = "Mars City",
                TargetNo = 500,
                Photo = "AAA",
            };
            return new { Tour_Insert }.JsonSerialize();
        }

        public int AccountId { get; set; }
        public string DestinationCity { get; set; }
        public DateTime EndDate { get; set; }
        public int OrgId { get; set; }
        public string Photo { get; set; }
        public DateTime StartDate { get; set; }
        public int? TargetNo { get; set; }
        public string TourDescription { get; set; }
        public int? TourId { get; set; }
        public string TourName { get; set; }
        public int TourTypeId { get; set; }
    }
}
