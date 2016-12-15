using Newtonsoft.Json.Linq;
using Stormpath.AspNet.WebApi;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ugroop.API.SQL.Filter;
using UGroopData.Entity.ViewModel.SQL.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;
using UGroopData.Utilities.String;

namespace Ugroop.API.SQL.Controllers {

    //// allows these stormpath groups to execute the controller
    //[StormpathGroupsRequired("Tour Admin", "Tour Participant")]
    [ApiExceptionFilter]
    public class TourController : SecurityController {

        public TourController(IUserService userService, ITourService tourService) : base(userService, tourService) { }

        #region TOUR                                .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_Tour(JObject jsonData) {
            var tour = JEntity<Tour_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(tour)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_Tour(JObject jsonData) {
            var tour = JEntity<Tour_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(tour)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_Tour(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Tour(id)).JsonSerialize())
            };
        }

        //[StormpathGroupsRequired("Tour Admin", "Tour Participant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourByAccountAndTourId(JObject jsonData) {
            int userId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("userId"));
            int tourId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourId"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourByAccountAndTourId(userId, tourId)).JsonSerialize())
            };
        }

        //[StormpathGroupsRequired("Tour Admin", "Tour Participant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourListByAccountId(JObject jsonData) {
            int userId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("userId"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourListByAccountId(userId)).JsonSerialize())
            };
        }

        //[StormpathGroupsRequired("Tour Admin", "Tour Participant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourByDate(JObject jsonData) {
            var startdate = Convert.ToDateTime(JsonData.Instance(jsonData).Get_JsonObject("startdate"));
            var enddate = Convert.ToDateTime(JsonData.Instance(jsonData).Get_JsonObject("enddate"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourByDate(startdate, enddate)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR PARTICIPANT                    .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourParticipant(JObject jsonData) {
            var participant = JEntity<TourParticipant_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(participant)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_TourParticipant(JObject jsonData) {
            var participant = JEntity<TourParticipant_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(participant)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_TourParticipant(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourParticipant(id)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourParticipantById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourParticipantById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region NEWSFEED                            .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_NewsFeed(JObject jsonData) {
            var newsfeed = JEntity<Newsfeed_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(newsfeed)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_NewsFeed(JObject jsonData) {
            var newsfeed = JEntity<Newsfeed_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(newsfeed)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_NewsFeed(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Newsfeed(id)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin", "Tour Participant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Get_NewsfeedById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_NewsfeedByNewsfeedId_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region REVIEW                              .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_Review(JObject jsonData) {
            var review = JEntity<Review_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(review)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_Review(JObject jsonData) {
            var review = JEntity<Review_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(review)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_Review(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Review(id)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin", "Tour Participant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Get_ReviewById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourReviewById(id)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin", "Tour Participant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Get_ReviewListByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_ReviewListByTourId(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR FLIGHT                         .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourFlight(JObject jsonData) {
            var flight = JEntity<TourFlight_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(flight)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_TourFlight(JObject jsonData) {
            var flight = JEntity<TourFlight_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(flight)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_TourFlight(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Flight(id)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin", "Tour Participant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourFlightById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourFlightById(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR CAR RENTAL                     .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourCarRental(JObject jsonData) {
            var carrental = JEntity<TourCarRental_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(carrental)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_TourCarRental(JObject jsonData) {
            var carrental = JEntity<TourCarRental_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(carrental)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_TourCarRental(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_CarRental(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR TRAIN                          .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourTrain(JObject jsonData) {
            var train = JEntity<TourTrain_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(train)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_TourTrain(JObject jsonData) {
            var train = JEntity<TourTrain_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(train)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_TourTrain(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Train(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR LODGING                        .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourLodging(JObject jsonData) {
            var lodging = JEntity<TourLodging_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(lodging)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_TourLodging(JObject jsonData) {
            var lodging = JEntity<TourLodging_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(lodging)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_TourLodging(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Lodging(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR CRUISE                         .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourCruise(JObject jsonData) {
            var cruise = JEntity<TourCruise_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(cruise)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_TourCruise(JObject jsonData) {
            var cruise = JEntity<TourCruise_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(cruise)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_TourCruise(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Cruise(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR PARKING                        .

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourParking(JObject jsonData) {
            var parking = JEntity<TourParking_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(parking)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update_TourParking(JObject jsonData) {
            var parking = JEntity<TourParking_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(parking)).JsonSerialize())
            };
        }

        [StormpathGroupsRequired("Tour Admin")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete_TourParking(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Parking(id)).JsonSerialize())
            };
        }

        #endregion


        // TEST -> EXCEPTION HANDLER / STORMPATH VALIDATION STRATEGY
        //[StormpathGroupsRequired("Tour Admin")]
        [StormpathGroupsRequired("Tour Admin", "Tour Participant")]
        [HttpPost]
        public async Task<HttpResponseMessage> TEST_Add_Tour_Async(JObject jsonData) {
            //throw new FormatException("this is a sample exception...");
            //var role = Identity.Role();
            var tour = JEntity<Tour_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(tour)).JsonSerialize())
            };
        }


    }
}
