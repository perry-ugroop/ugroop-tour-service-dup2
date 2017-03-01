using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger.Annotations;
using Ugroop.API.SQL.Filter;
using Ugroop.API.SQL.Swagger.TestModel;
using UGroopData.Entity.ViewModel.SQL.Data;
using UGroopData.Sql.Repository2.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;
using UGroopData.Utilities.String;

namespace Ugroop.API.SQL.Controllers {

    [ApiExceptionFilter]
    public class TourController : BaseController {

        public TourController(ITourService tourService) : base(tourService) { }

        #region TOUR                                .

        /// <summary>
        /// Add new Tour
        /// </summary>
        /// <remarks>
        /// Insert new Tour record
        /// </remarks>
        [ResponseType(typeof(Tour_Insert))]
        //[SwaggerResponseExamples(typeof(string), typeof(Tour_Insert_Example))]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_Tour(JObject jsonData) {
            var tour = JEntity<Tour_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(tour)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour
        /// </summary>
        /// <remarks>
        /// Update existing Tour record
        /// </remarks>
        [ResponseType(typeof(Tour_Update))]
        [HttpPut]
        public async Task<HttpResponseMessage> Update_Tour(JObject jsonData) {
            var tour = JEntity<Tour_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(tour)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour
        /// </summary>
        /// <remarks>
        /// Set the existing Tour record as inactive
        /// </remarks>
        /// <para/>id
        [ResponseType(typeof(bool))]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Tour(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Tour(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour record
        /// </summary>
        /// <remarks>
        /// Get Tour record by Account and TourId
        /// </remarks>
        /// <param name="userId"></param> 
        /// <param name="tourId"></param> 
        [ResponseType(typeof(Tour_View))]
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourByAccountAndTourId(string jsonData) {
            int userId = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "userId"));
            int tourId = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "tourId"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourByAccountAndTourId(userId, tourId)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get list of Tours
        /// </summary>
        /// <remarks>
        /// Get list of Tour records by Account
        /// </remarks>
        /// <param name="userId"></param> 
        [ResponseType(typeof(List<Tour_View>))]
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourListByAccountId(string jsonData) {
            int userId = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "userId"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourListByAccountId(userId)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get list of Tours
        /// </summary>
        /// <remarks>
        /// Get list of Tour records by Account
        /// </remarks>
        /// <parameters name="startdate">startdate</parameters> 
        /// <parameters name="enddate">enddate</parameters> 
        [ResponseType(typeof(List<Tour_View>))]
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourListByDate(string jsonData) {
            var startdate = Convert.ToDateTime(JsonData.Instance().Get_JsonObject(jsonData, "startdate"));
            var enddate = Convert.ToDateTime(JsonData.Instance().Get_JsonObject(jsonData, "enddate"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourByDate(startdate, enddate)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR PARTICIPANT                    .

        /// <summary>
        /// Add new Tour Participant
        /// </summary>
        /// <remarks>
        /// Insert new Tour Participant record
        /// </remarks> 
        [ResponseType(typeof(TourParticipant_Insert))]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourParticipant(JObject jsonData) {
            var participant = JEntity<TourParticipant_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(participant)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Participant
        /// </summary>
        /// <remarks>
        /// Update existing Tour Participant record
        /// </remarks>
        [ResponseType(typeof(TourParticipant_Update))]
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourParticipant(JObject jsonData) {
            var participant = JEntity<TourParticipant_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(participant)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Participant
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Participant record as inactive
        /// </remarks>
        /// <para/>id
        [ResponseType(typeof(bool))]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourParticipant(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            string email = Convert.ToString(JsonData.Instance(jsonData).Get_JsonObject("email"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourParticipant(id, email)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get Tour Participant record
        /// </summary>
        /// <remarks>
        /// Get Tour Participant record by TourId and Email
        /// </remarks>
        /// <param name="id"></param> 
        /// <param name="email"></param> 
        [ResponseType(typeof(TourParticipant))]
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourParticipantByIdEmail(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            string email = Convert.ToString(JsonData.Instance().Get_JsonObject(jsonData, "email"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourParticipantByIdEmail(id, email)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get list of Tour Participants
        /// </summary>
        /// <remarks>
        /// Get list of Tour Participants by TourId
        /// </remarks>
        /// <param name="tourid"></param> 
        [ResponseType(typeof(List<TourParticipant>))]
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourParticipantsByTourId(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_AllTourParticipantsByTourId(id)).JsonSerialize())
            };
        }

        #endregion

        #region NEWSFEED                            .

        /// <summary>
        /// Add Newsfeed
        /// </summary>
        /// <remarks>
        /// Insert new Newsfeed record
        /// </remarks> 
        [ResponseType(typeof(Newsfeed_Insert))]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_NewsFeed(JObject jsonData) {
            var newsfeed = JEntity<Newsfeed_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(newsfeed)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Newsfeed
        /// </summary>
        /// <remarks>
        /// Update existing Newsfeed record
        /// </remarks>
        [ResponseType(typeof(Newsfeed_Update))]
        [HttpPut]
        public async Task<HttpResponseMessage> Update_NewsFeed(JObject jsonData) {
            var newsfeed = JEntity<Newsfeed_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(newsfeed)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Newsfeed
        /// </summary>
        /// <remarks>
        /// Set the existing Newsfeed record as inactive
        /// </remarks>
        /// <para/>id
        [ResponseType(typeof(bool))]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_NewsFeed(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Newsfeed(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single NewsFeed
        /// </summary>
        /// <remarks>
        /// Get NewsFeed record by Id
        /// </remarks>
        /// <param name="id"></param> 
        [ResponseType(typeof(Newsfeed))]
        [HttpGet]
        public async Task<HttpResponseMessage> Get_NewsfeedById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_NewsfeedByNewsfeedId_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region REVIEW                              .

        /// <summary>
        /// Add Tour Review
        /// </summary>
        /// <remarks>
        /// Insert new Tour Review record
        /// </remarks> 
        [ResponseType(typeof(TourReview_Insert))]
        [HttpPost]
        public async Task<HttpResponseMessage> Add_Review(JObject jsonData) {
            var review = JEntity<TourReview_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(review)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Review
        /// </summary>
        /// <remarks>
        /// Update existing Tour Review record
        /// </remarks>
        [ResponseType(typeof(TourReview_Update))]
        [HttpPut]
        public async Task<HttpResponseMessage> Update_Review(JObject jsonData) {
            var review = JEntity<TourReview_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(review)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Review
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Review record as inactive
        /// </remarks>
        /// <para/>id
        [ResponseType(typeof(bool))]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Review(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Review(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Review
        /// </summary>
        /// <remarks>
        /// Get Tour Review record by Id
        /// </remarks>
        /// <param name="id"></param> 
        [ResponseType(typeof(TourReview_View))]
        [HttpGet]
        public async Task<HttpResponseMessage> Get_ReviewById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_TourReviewById(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get list of Tour Review
        /// </summary>
        /// <remarks>
        /// Get list of Tour Review records by TourId
        /// </remarks>
        /// <param name="tourid"></param> 
        [ResponseType(typeof(List<TourReview_View>))]
        [HttpGet]
        public async Task<HttpResponseMessage> Get_ReviewListByTourId(string jsonData) {
            int tourid = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "tourid"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.GetAsync_ReviewListByTourId(tourid)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR NOTE                              .

        /// <summary>
        /// Add Tour Note
        /// </summary>
        /// <remarks>
        /// Insert new Tour Note record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourNote(JObject jsonData) {
            var note = JEntity<TourNote_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Note
        /// </summary>
        /// <remarks>
        /// Update existing Tour Note record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourNote(JObject jsonData) {
            var note = JEntity<TourNote_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Note
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Note record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourNote(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourNote(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Note
        /// </summary>
        /// <remarks>
        /// Get Tour Note record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourNoteById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourNoteById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR PLAN                              .

        /// <summary>
        /// Add Tour Plan
        /// </summary>
        /// <remarks>
        /// Insert new Tour Plan record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourPlan(JObject jsonData) {
            var note = JEntity<TourPlan_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Plan
        /// </summary>
        /// <remarks>
        /// Update existing Tour Plan record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourPlan(JObject jsonData) {
            var note = JEntity<TourPlan_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Plan
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Plan record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourPlan(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourPlan(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Plan
        /// </summary>
        /// <remarks>
        /// Get Tour Plan record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourPlanById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourPlanById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR PLAN TYPE                             .

        /// <summary>
        /// Add Tour Plan Type
        /// </summary>
        /// <remarks>
        /// Insert new Tour Plan Type record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourPlanType(JObject jsonData) {
            var note = JEntity<TourPlanType_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Plan Type
        /// </summary>
        /// <remarks>
        /// Update existing Tour Plan Type record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourPlanType(JObject jsonData) {
            var note = JEntity<TourPlanType_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Plan Type
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Plan Type record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourPlanType(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourPlanType(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Plan Type
        /// </summary>
        /// <remarks>
        /// Get Tour Plan Type record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourPlanTypeById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourPlanTypeById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR ACTIVITY TYPE                             .

        /// <summary>
        /// Add Tour Activity Type
        /// </summary>
        /// <remarks>
        /// Insert new Tour Activity Type record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourActivityType(JObject jsonData) {
            var note = JEntity<TourActivityType_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Activity Type
        /// </summary>
        /// <remarks>
        /// Update existing Tour Activity Type record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourActivityType(JObject jsonData) {
            var note = JEntity<TourActivityType_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Activity Type
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Activity Type record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourActivityType(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourActivityType(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Activity Type
        /// </summary>
        /// <remarks>
        /// Get Tour Activity Type record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourActivityTypeById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourActivityTypeById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR TYPE                             .

        /// <summary>
        /// Add Tour Type
        /// </summary>
        /// <remarks>
        /// Insert new Tour Type record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourType(JObject jsonData) {
            var note = JEntity<TourType_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Type
        /// </summary>
        /// <remarks>
        /// Update existing Tour Type record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourType(JObject jsonData) {
            var note = JEntity<TourType_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(note)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Type
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Type record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourType(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourType(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Type
        /// </summary>
        /// <remarks>
        /// Get Tour Type record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourTypeById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourTypeById_Async(id)).JsonSerialize())
            };
        }

        #endregion


        #region TOUR TRANSPORTATIONS                             .

        /// <summary>
        /// Add Tour Transportations
        /// </summary>
        /// <remarks>
        /// Insert new Tour Transportations record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourTransportations(JObject jsonData) {
            var transpo = JEntity<TourTransportations_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Transportations
        /// </summary>
        /// <remarks>
        /// Update existing Tour Transportations record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourTransportations(JObject jsonData) {
            var transpo = JEntity<TourTransportations_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Transportations
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Transportations record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourTransportations(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourTransportations(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Transportations
        /// </summary>
        /// <remarks>
        /// Get Tour Transportations record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourTransportationsById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourTransportationById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR TRANSPORTATIONS CAR                            .

        /// <summary>
        /// Add Tour Transportation Car
        /// </summary>
        /// <remarks>
        /// Insert new Tour Transportation Car record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourTransportationCar(JObject jsonData) {
            var transpo = JEntity<TourTransportationCar_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Transportation Car
        /// </summary>
        /// <remarks>
        /// Update existing Tour Transportation Car record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourTransportationCar(JObject jsonData) {
            var transpo = JEntity<TourTransportationCar_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Transportation Car
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Transportation Car record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourTransportationCar(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourTransportationCar(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Transportation Car
        /// </summary>
        /// <remarks>
        /// Get Tour Transportation Car record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourTransportationCarById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourTransportationCarById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR TRANSPORTATIONS CRUISE                            .

        /// <summary>
        /// Add Tour Transportation Cruise
        /// </summary>
        /// <remarks>
        /// Insert new Tour Transportation Cruise record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourTransportationCruise(JObject jsonData) {
            var transpo = JEntity<TourTransportationCruise_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Transportation Cruise
        /// </summary>
        /// <remarks>
        /// Update existing Tour Transportation Cruise record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourTransportationCruise(JObject jsonData) {
            var transpo = JEntity<TourTransportationCruise_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Transportation Cruise
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Transportation Cruise record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourTransportationCruise(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourTransportationCruise(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Transportation Cruise
        /// </summary>
        /// <remarks>
        /// Get Tour Transportation Cruise record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourTransportationCruiseById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourTransportationCruiseById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR TRANSPORTATIONS FLIGHT                            .

        /// <summary>
        /// Add Tour Transportation Flight
        /// </summary>
        /// <remarks>
        /// Insert new Tour Transportation Flight record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourTransportationFlight(JObject jsonData) {
            var transpo = JEntity<TourTransportationFlight_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Transportation Flight
        /// </summary>
        /// <remarks>
        /// Update existing Tour Transportation Flight record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourTransportationFlight(JObject jsonData) {
            var transpo = JEntity<TourTransportationFlight_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Transportation Flight
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Transportation Flight record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourTransportationFlight(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourTransportationFlight(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Transportation Flight
        /// </summary>
        /// <remarks>
        /// Get Tour Transportation Flight record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourTransportationFlightById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourTransportationFlightById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR TRANSPORTATIONS TRAIN                            .

        /// <summary>
        /// Add Tour Transportation Train
        /// </summary>
        /// <remarks>
        /// Insert new Tour Transportation Train record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourTransportationTrain(JObject jsonData) {
            var transpo = JEntity<TourTransportationTrain_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Transportation Train
        /// </summary>
        /// <remarks>
        /// Update existing Tour Transportation Train record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourTransportationTrain(JObject jsonData) {
            var transpo = JEntity<TourTransportationTrain_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Transportation Train
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Transportation Train record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourTransportationTrain(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourTransportationTrain(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Transportation Train
        /// </summary>
        /// <remarks>
        /// Get Tour Transportation Train record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourTransportationTrainById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourTransportationTrainById_Async(id)).JsonSerialize())
            };
        }

        #endregion



        #region TOUR TRANSPORTATION TYPE                             .

        /// <summary>
        /// Add Tour Transportation Type
        /// </summary>
        /// <remarks>
        /// Insert new Tour Transportation Type record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourTransportationType(JObject jsonData) {
            var transpo = JEntity<TourTransportationType_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Transportation Type
        /// </summary>
        /// <remarks>
        /// Update existing Tour Transportation Type record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourTransportationType(JObject jsonData) {
            var transpo = JEntity<TourTransportationType_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Transportation Type
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Transportation Type record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourTransportationType(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourTransportationType(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Transportation Type
        /// </summary>
        /// <remarks>
        /// Get Tour Transportation Type record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourTransportationTypeById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourTransportationTypeById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR ACTIVITIES PLACE                             .

        /// <summary>
        /// Add Tour Activites Place
        /// </summary>
        /// <remarks>
        /// Insert new Tour Activites Place record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourActivitiesPlace(JObject jsonData) {
            var place = JEntity<TourActivitiesPlace_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(place)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Activites Place
        /// </summary>
        /// <remarks>
        /// Update existing Tour Activites Place record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourActivitiesPlace(JObject jsonData) {
            var place = JEntity<TourActivitiesPlace_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(place)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Activites Place
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Activites Place record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourActivitiesPlace(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourActivitiesPlace(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Activites Place
        /// </summary>
        /// <remarks>
        /// Get Tour Activites Place record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourActivitiesPlaceById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourActivitiesPlaceById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR ATTACHMENT                             .

        /// <summary>
        /// Add Tour Attachment
        /// </summary>
        /// <remarks>
        /// Insert new Tour Attachment record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourAttachment(JObject jsonData) {
            var attach = JEntity<TourAttachment_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Attachment
        /// </summary>
        /// <remarks>
        /// Update existing Tour Attachment record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourAttachment(JObject jsonData) {
            var attach = JEntity<TourAttachment_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Attachment
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Attachment record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourAttachment(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourAttachment(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Attachment
        /// </summary>
        /// <remarks>
        /// Get Tour Attachment record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourAttachmentById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourAttachmentById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR DIRECTIONS                             .

        /// <summary>
        /// Add Tour Directions
        /// </summary>
        /// <remarks>
        /// Insert new Tour Directions record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourDirections(JObject jsonData) {
            var attach = JEntity<TourDirections_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Directions
        /// </summary>
        /// <remarks>
        /// Update existing Tour Directions record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourDirections(JObject jsonData) {
            var attach = JEntity<TourDirections_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Directions
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Directions record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourDirections(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourDirections(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Directions
        /// </summary>
        /// <remarks>
        /// Get Tour Directions record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourDirectionsById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourDirectionsById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR DIRECTIONS TYPE                             .

        /// <summary>
        /// Add Tour Direction Type
        /// </summary>
        /// <remarks>
        /// Insert new Tour Direction Type record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourDirectionType(JObject jsonData) {
            var attach = JEntity<TourDirectionType_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Direction Type
        /// </summary>
        /// <remarks>
        /// Update existing Tour Direction Type record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourDirectionType(JObject jsonData) {
            var attach = JEntity<TourDirectionType_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Direction Type
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Direction Type record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourDirectionType(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourDirectionType(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Direction Type
        /// </summary>
        /// <remarks>
        /// Get Tour Direction Type record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourDirectionTypeById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourDirectionTypeById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR DIRECTIONS PATH                            .

        /// <summary>
        /// Add Tour Directions Path
        /// </summary>
        /// <remarks>
        /// Insert new Tour Directions Path record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourDirectionsPath(JObject jsonData) {
            var attach = JEntity<TourDirectionsPath_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Directions Path
        /// </summary>
        /// <remarks>
        /// Update existing Tour Directions Path record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourDirectionsPath(JObject jsonData) {
            var attach = JEntity<TourDirectionsPath_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Directions Path
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Directions Path record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourDirectionsPath(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourDirectionsPath(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Directions Path
        /// </summary>
        /// <remarks>
        /// Get Tour Directions Path record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourDirectionsPathById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourDirectionsPathById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region AIRPORTS                            .

        /// <summary>
        /// Add Airports
        /// </summary>
        /// <remarks>
        /// Insert new Airports record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_Airports(JObject jsonData) {
            var attach = JEntity<Airports_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Airports
        /// </summary>
        /// <remarks>
        /// Update existing Airports record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_Airports(JObject jsonData) {
            var attach = JEntity<Airports_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Airports
        /// </summary>
        /// <remarks>
        /// Set the existing Airports record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Airports(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_Airports(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Airports
        /// </summary>
        /// <remarks>
        /// Get Airports record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_AirportsById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_AirportsById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TIMEZONE                            .

        /// <summary>
        /// Add Timezone
        /// </summary>
        /// <remarks>
        /// Insert new Timezone record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TimeZone(JObject jsonData) {
            var attach = JEntity<TimeZone_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Timezone
        /// </summary>
        /// <remarks>
        /// Update existing Timezone record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TimeZone(JObject jsonData) {
            var attach = JEntity<TimeZone_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(attach)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Timezone
        /// </summary>
        /// <remarks>
        /// Set the existing Timezone record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TimeZone(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TimeZone(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Timezone
        /// </summary>
        /// <remarks>
        /// Get Timezone record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TimeZoneById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TimeZoneById_Async(id)).JsonSerialize())
            };
        }

        #endregion



        #region TOUR ACTIVITES                             .

        /// <summary>
        /// Add Tour Activities
        /// </summary>
        /// <remarks>
        /// Insert new Tour Activities record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourActivities(JObject jsonData) {
            var activity = JEntity<TourActivities_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(activity)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Activities
        /// </summary>
        /// <remarks>
        /// Update existing Tour Activities record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourActivities(JObject jsonData) {
            var transpo = JEntity<TourActivities_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(transpo)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Activities
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Activities record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourActivities(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourActivities(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Activities
        /// </summary>
        /// <remarks>
        /// Get Tour Activities record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourActivitiesById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourActivityById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR ACTIVITES DINING                            .

        /// <summary>
        /// Add Tour Activities Dining
        /// </summary>
        /// <remarks>
        /// Insert new Tour Activities Dining record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourActivitiesDining(JObject jsonData) {
            var activity = JEntity<TourActivitiesDining_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(activity)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Activities Dining
        /// </summary>
        /// <remarks>
        /// Update existing Tour Activities Dining record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourActivitiesDining(JObject jsonData) {
            var activity = JEntity<TourActivitiesDining_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(activity)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Activities Dining
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Activities Dining record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourActivitiesDining(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourActivitiesDining(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Activities Dining
        /// </summary>
        /// <remarks>
        /// Get Tour Activities Dining record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourActivitiesDiningById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourActivityDiningById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR ACTIVITES LODGING                            .

        /// <summary>
        /// Add Tour Activities Lodging
        /// </summary>
        /// <remarks>
        /// Insert new Tour Activities Lodging record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourActivitiesLodging(JObject jsonData) {
            var activity = JEntity<TourActivitiesLodging_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(activity)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Activities Lodging
        /// </summary>
        /// <remarks>
        /// Update existing Tour Activities Lodging record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourActivitiesLodging(JObject jsonData) {
            var activity = JEntity<TourActivitiesLodging_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(activity)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Activities Lodging
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Activities Lodging record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourActivitiesLodging(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourActivitiesLodging(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Activities Lodging
        /// </summary>
        /// <remarks>
        /// Get Tour Activities Lodging record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourActivitiesLodgingById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourActivityLodgingById_Async(id)).JsonSerialize())
            };
        }

        #endregion

        #region TOUR ACTIVITES MEETING                            .

        /// <summary>
        /// Add Tour Activities Meeting
        /// </summary>
        /// <remarks>
        /// Insert new Tour Activities Meeting record
        /// </remarks>
        [HttpPost]
        public async Task<HttpResponseMessage> Add_TourActivitiesMeeting(JObject jsonData) {
            var activity = JEntity<TourActivitiesMeeting_Insert>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Add_AsyncData(activity)).JsonSerialize())
            };
        }

        /// <summary>
        /// Update Tour Activities Meeting
        /// </summary>
        /// <remarks>
        /// Update existing Tour Activities Meeting record
        /// </remarks>
        [HttpPut]
        public async Task<HttpResponseMessage> Update_TourActivitiesMeeting(JObject jsonData) {
            var activity = JEntity<TourActivitiesMeeting_Update>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Update_AsyncData(activity)).JsonSerialize())
            };
        }

        /// <summary>
        /// Delete Tour Activities Meeting
        /// </summary>
        /// <remarks>
        /// Set the existing Tour Activities Meeting record as inactive
        /// </remarks>
        /// <para/>id
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_TourActivitiesMeeting(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.DeleteAsync_TourActivitiesMeeting(id)).JsonSerialize())
            };
        }

        /// <summary>
        /// Get single Tour Activities Meeting
        /// </summary>
        /// <remarks>
        /// Get Tour Activities Meeting record by Id
        /// </remarks>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<HttpResponseMessage> Get_TourActivitiesMeetingById(string jsonData) {
            int id = Convert.ToInt32(JsonData.Instance().Get_JsonObject(jsonData, "id"));
            return new HttpResponseMessage {
                Content = new StringContent((await TourService.Get_TourActivityMeetingById_Async(id)).JsonSerialize())
            };
        }

        #endregion


    }
}
