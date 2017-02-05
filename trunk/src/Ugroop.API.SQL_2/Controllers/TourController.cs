using Newtonsoft.Json.Linq;
using Stormpath.AspNet.WebApi;
using Stormpath.SDK;
using Stormpath.SDK.Account;
using Stormpath.SDK.Client;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Ugroop.API.SQL.App_Start;
using Ugroop.API.SQL.Filter;
using UGroopData.Entity.ViewModel.SQL.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;
using UGroopData.Utilities.String;

namespace Ugroop.API.SQL.Controllers {

    [ApiExceptionFilter]
    public class TourController : SecurityController {

        public TourController(ITourService tourService) : base(tourService) { }

        #region TOUR                                .

        [HttpPost]
        public async Task<HttpResponseMessage> Add_Tour(JObject jsonData) {
            var tour = JEntity<Tour_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(tour)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update_Tour(JObject jsonData) {
            var tour = JEntity<Tour_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(tour)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Delete_Tour(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Tour(id)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourByAccountAndTourId(JObject jsonData) {
            int userId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("userId"));
            int tourId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourId"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourByAccountAndTourId(userId, tourId)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourListByAccountId(JObject jsonData) {
            int userId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("userId"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourListByAccountId(userId)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourListByDate(JObject jsonData) {
            var startdate = Convert.ToDateTime(JsonData.Instance(jsonData).Get_JsonObject("startdate"));
            var enddate = Convert.ToDateTime(JsonData.Instance(jsonData).Get_JsonObject("enddate"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourByDate(startdate, enddate)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR PARTICIPANT                    .

        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourParticipant(JObject jsonData) {
            var participant = JEntity<TourParticipant_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(participant)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update_TourParticipant(JObject jsonData) {
            var participant = JEntity<TourParticipant_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(participant)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Delete_TourParticipant(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            string email = Convert.ToString(JsonData.Instance(jsonData).Get_JsonObject("email"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourParticipant(id, email)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourParticipantByIdEmail(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            string email = Convert.ToString(JsonData.Instance(jsonData).Get_JsonObject("email"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourParticipantByIdEmail(id, email)).JsonSerialize())
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Get_TourParticipantsByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("tourid"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_AllTourParticipantsByTourId(id)).JsonSerialize())
            };
        }

        #endregion

        #region NEWSFEED                            .


        [HttpPost]
        public async Task<HttpResponseMessage> Add_NewsFeed(JObject jsonData) {
            var newsfeed = JEntity<Newsfeed_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(newsfeed)).JsonSerialize())
            };
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Update_NewsFeed(JObject jsonData) {
            var newsfeed = JEntity<Newsfeed_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(newsfeed)).JsonSerialize())
            };
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Delete_NewsFeed(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Newsfeed(id)).JsonSerialize())
            };
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Get_NewsfeedById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_NewsfeedByNewsfeedId_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region REVIEW                              .


        [HttpPost]
        public async Task<HttpResponseMessage> Add_Review(JObject jsonData) {
            var review = JEntity<TourReview_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(review)).JsonSerialize())
            };
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Update_Review(JObject jsonData) {
            var review = JEntity<TourReview_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(review)).JsonSerialize())
            };
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Delete_Review(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Review(id)).JsonSerialize())
            };
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Get_ReviewById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourReviewById(id)).JsonSerialize())
            };
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Get_ReviewListByTourId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_ReviewListByTourId(id)).JsonSerialize())
            };
        }

        #endregion

    }
}
