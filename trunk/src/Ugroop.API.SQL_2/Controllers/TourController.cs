using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web.Http;
using Ugroop.API.SQL.Helper.Json;
using UGroopData.Sql.Repository2.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {
    public class TourController : SecurityController {

        public TourController(IUserService userService, ITourService tourService) : base(userService, tourService) { }

        #region TOUR                    .

        [HttpPost]
        public HttpResponseMessage Add_Tour(JObject jsonData) {
            var tour = JEntity<Tour>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(tour).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_Tour(JObject jsonData) {
            var tour = JEntity<Tour>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(tour).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllToursByAccountID(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_AllToursByAccountID(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourByAccountId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourByAccountId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourByTourId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourByAccountAndTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            int organizerId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("organizerId"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourByAccountAndTourId(organizerId, id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourListByAccountId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourListByAccountId(id).JsonSerialize())
            };
        }

        #endregion

        #region TOUR PARTICIPANT                   .

        [HttpPost]
        public HttpResponseMessage Add_TourParticipant(JObject jsonData) {
            var tourParticipant = JEntity<Tour_Participant>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(tourParticipant).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourParticipant(JObject jsonData) {
            var tourParticipant = JEntity<Tour_Participant>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(tourParticipant).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllTourParticipantsByRole(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_AllTourParticipantsByRole(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_ParticipantByTourAndAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("accountId"));
            int tourId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourId"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_ParticipantByTourAndAccountId(accountId, tourId).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Verify_TourOwnership(JObject jsonData) {
            int tourId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourId"));
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("accountId"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Verify_TourOwnership(tourId, accountId).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllTourParticipantsByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_AllTourParticipantsByTourId(id).JsonSerialize())
            };
        }

        #endregion

        #region NEWSFEED                    .

        [HttpPost]
        public HttpResponseMessage Add_Newsfeed(JObject jsonData) {
            var newsfeed = JEntity<Newsfeed>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(newsfeed).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_Newsfeed(JObject jsonData) {
            var newsfeed = JEntity<Newsfeed>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(newsfeed).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_NewsfeedById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_NewsfeedByNewsfeedId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage GetAllNewsfeedbyTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.GetAllNewsfeedbyTourId(id).JsonSerialize())
            };
        }

        #endregion

        #region REVIEW                    .

        [HttpPost]
        public HttpResponseMessage Add_Review(JObject jsonData) {
            var review = JEntity<Review>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(review).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_Review(JObject jsonData) {
            var review = JEntity<Review>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(review).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_ReviewsByReviewId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_ReviewsByReviewId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage GetAllReviewsbyTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.GetAllReviewsbyTourId(id).JsonSerialize())
            };
        }

        #endregion

        #region TOUR_PLAN                    .

        [HttpPost]
        public HttpResponseMessage Add_TourPlan(JObject jsonData) {
            var tourPlan = JEntity<Tour_Plan>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(tourPlan).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourPlan(JObject jsonData) {
            var tourPlan = JEntity<Tour_Plan>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(tourPlan).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourPlanById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourPlanById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllTourPlanByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_AllTourPlanByTourId(id).JsonSerialize())
            };
        }

        #endregion

        #region TOUR_FLIGHT                 .

        [HttpPost]
        public HttpResponseMessage Add_TourFlight(JObject jsonData) {
            var tourFlight = JEntity<Tour_Flight>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(tourFlight).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourFlight(JObject jsonData) {
            var tourFlight = JEntity<Tour_Flight>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(tourFlight).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourFlightByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourFlightByTourId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourFlightByTourFlightId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourFlightByTourFlightId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourFlightByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourFlightByTourAndPlan(tourid,planid).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourFlightByFlightId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourFlightByFlightId(id).JsonSerialize())
            };
        }

        #endregion

        #region TOUR_TRAIN                 .

        [HttpPost]
        public HttpResponseMessage Add_TourTrain(JObject jsonData) {
            var tourTrain = JEntity<Tour_Train>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(tourTrain).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourTrain(JObject jsonData) {
            var tourTrain = JEntity<Tour_Train>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(tourTrain).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourTrainByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourTrainByTourId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourTrainByTourTrainId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourTrainByTourTrainId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourTrainByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourTrainByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region CAR RENTAL                 .

        [HttpPost]
        public HttpResponseMessage Add_TourCarRental(JObject jsonData) {
            var tourCar = JEntity<Tour_CarRental>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(tourCar).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourCarRental(JObject jsonData) {
            var tourCar = JEntity<Tour_CarRental>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(tourCar).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourCarByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourCarByTourId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourCarByTourCarId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourCarByTourCarId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourCarRentalByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourCarRentalByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR CRUISE                  .

        [HttpPost]
        public HttpResponseMessage Add_TourCruise(JObject jsonData) {
            var cruise = JEntity<Tour_Cruise>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(cruise).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourCruise(JObject jsonData) {
            var cruise = JEntity<Tour_Cruise>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(cruise).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourCruiseById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourCruiseById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourCruiseByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourCruiseByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR PARKING                  .

        [HttpPost]
        public HttpResponseMessage Add_TourParking(JObject jsonData) {
            var parking = JEntity<Tour_Parking>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(parking).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourParking(JObject jsonData) {
            var parking = JEntity<Tour_Parking>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(parking).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourParkingById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourParkingById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourParkingByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourParkingByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR LODGING                  .

        [HttpPost]
        public HttpResponseMessage Add_TourLodging(JObject jsonData) {
            var lodging = JEntity<Tour_Lodging>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(lodging).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourLodging(JObject jsonData) {
            var lodging = JEntity<Tour_Lodging>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(lodging).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourLodgingById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourLodgingById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourLodgingByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourLodgingByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR RESTAURANT                  .

        [HttpPost]
        public HttpResponseMessage Add_TourRestaurant(JObject jsonData) {
            var restaurant = JEntity<Tour_Restaurant>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(restaurant).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourRestaurant(JObject jsonData) {
            var restaurant = JEntity<Tour_Restaurant>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(restaurant).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourRestaurantById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourRestaurantById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourRestaurantByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourRestaurantByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR MEETING                  .

        [HttpPost]
        public HttpResponseMessage Add_TourMeeting(JObject jsonData) {
            var meeting = JEntity<Tour_Meeting>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(meeting).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourMeeting(JObject jsonData) {
            var meeting = JEntity<Tour_Meeting>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(meeting).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourMeetingById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourMeetingById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourMeetingByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourMeetingByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR ACTIVITY                  .

        [HttpPost]
        public HttpResponseMessage Add_TourActivity(JObject jsonData) {
            var activity = JEntity<Tour_Activity>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(activity).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourActivity(JObject jsonData) {
            var activity = JEntity<Tour_Activity>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(activity).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourActivityById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourActivityById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourActivityByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourActivityByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR MAP                  .

        [HttpPost]
        public HttpResponseMessage Add_TourMap(JObject jsonData) {
            var map = JEntity<Tour_Map>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(map).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourMap(JObject jsonData) {
            var map = JEntity<Tour_Map>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(map).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourMapById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourMapById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourMapByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourMapByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR DIRECTION                  .

        [HttpPost]
        public HttpResponseMessage Add_TourDirection(JObject jsonData) {
            var direction = JEntity<Tour_Direction>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(direction).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourDirection(JObject jsonData) {
            var direction = JEntity<Tour_Direction>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(direction).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourDirectionById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourDirectionById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourDirectionByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourDirectionByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

        #region TOUR NOTE                  .

        [HttpPost]
        public HttpResponseMessage Add_TourNote(JObject jsonData) {
            var note = JEntity<Tour_Note>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Add(note).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourNote(JObject jsonData) {
            var note = JEntity<Tour_Note>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Update(note).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourNoteById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TourNoteById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TournoteByTourAndPlan(JObject jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            int planid = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("planid"));
            return new HttpResponseMessage {
                Content = new StringContent(TourService.Get_TournoteByTourAndPlan(tourid, planid).JsonSerialize())
            };
        }

        #endregion

    }
}
