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


    }
}
