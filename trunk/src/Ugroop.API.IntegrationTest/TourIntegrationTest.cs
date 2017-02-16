using System;
using System.Net.Http;
using System.Net.Http.Headers;
using UGroopData.Entity.ViewModel.SQL.Data;
using UGroopData.Utilities.String;
using Xunit;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using UGroopData.Sql.Repository2.Data;

namespace Ugroop.API.IntegrationTest {

    public class TourIntegrationTest {

        #region CONSTRUCTOR                             .

        private string BaseUri = ConfigurationManager.AppSettings["BaseUrl"].ToString();
        public TourIntegrationTest() {
            Instantiate_Token();
        }

        #endregion

        #region HTTPCLIENT BASE                         .

        private HttpClient ClientBase() {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenHandler.AccessToken);
            return client;
        }

        private HttpClient ClientBase2() {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        #endregion


        #region ACTUAL HTTP RESPONSE                    .

        #region TOKEN CREATE                        .

        HttpResponseMessage ActualResponse_CreateToken(string login, string password) {
            var userlogin = new {
                login = login,
                password = password,
            };
            var param = userlogin.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase2().PostAsync("login", content).Result;
            return response;
        }

        private void Create_Token() {
            var tokenresponse = ActualResponse_CreateToken("UG_User_1", "UG_User_1");
            TokenHandler.AccessToken = tokenresponse.Headers.GetValues("Set-Cookie").First(x => x.StartsWith("access_token")).Split('=')[1].Split(';')[0];
        }

        private void Instantiate_Token() {
            StormpathConfig.Initialize();
            if (string.IsNullOrEmpty(TokenHandler.AccessToken)) {
                Create_Token();
            }
            else {
                if (!TokenHandler.ValidateAccessToken().Result) {
                    Create_Token();
                }
            }
        }

        #endregion


        #region TOUR                                .

        HttpResponseMessage ActualResponse_Add_Tour() {

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
            var param = new { Tour_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_Tour", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_Tour() {

            var Tour_Update = new Tour_Update {
                // get id from DB
                TourId = 4090,
                AccountId = 1,
                OrgId = 1,
                TourTypeId = 1,
                TourName = "XXX",
                StartDate = Convert.ToDateTime("12/25/2030"),
                EndDate = Convert.ToDateTime("12/30/2030"),
                TourDescription = "AAA",
                DestinationCity = "Mars City",
                TargetNo = 500,
                Photo = "XXXXX",
            };
            var param = new { Tour_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_Tour", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_Tour() {
            var _id = 4109;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_Tour", content).Result;
            return response;
        }

        // Params ( userId:int )
        HttpResponseMessage ActualResponse_Get_TourListByAccountId() {
            var _userId = 3;
            var param = new { userId = _userId }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourListByAccountId", content).Result;
            return response;
        }

        // Params ( startdate:string  /  enddate:string )
        HttpResponseMessage ActualResponse_Get_TourListByDate() {
            var _startdate = "12/20/2016 00:00:00";
            var _enddate = "12/30/2016 23:59:59";

            var param = new { startdate = _startdate, enddate = _enddate }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourListByDate", content).Result;
            return response;
        }


        #endregion

        #region TOUR PARTICIPANT                               .

        // Note : Please change the value of TourId and Email if those values are already exists in database
        HttpResponseMessage ActualResponse_Add_TourParticipant() {

            var TourParticipant_Insert = new TourParticipant_Insert {
                TourId = 1065,
                EmailAddress = "xxx@yahoo.com",
                IsOrganizer = false,
                IsParticipant = false,
                IsViewer = false,
                Status = "PENDING",
                DateInvited = Convert.ToDateTime("12/25/2030"),
                DateConfirmed = Convert.ToDateTime("12/25/2030"),
                IsConfirmed = true,
            };

            var param = new { TourParticipant_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourParticipant", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourParticipant() {

            var TourParticipant_Update = new TourParticipant_Update {
                TourId = 1065,
                EmailAddress = "xxx@yahoo.com",
                IsOrganizer = true,
                IsParticipant = true,
                IsViewer = true,
                Status = "PENDING",
                DateInvited = Convert.ToDateTime("12/25/2030"),
                DateConfirmed = Convert.ToDateTime("12/25/2030"),
                IsConfirmed = false,
                IsActive = false,
            };

            var param = new { TourParticipant_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourParticipant", content).Result;
            return response;
        }

        // Params ( id:int / email:string )
        HttpResponseMessage ActualResponse_Delete_TourParticipant() {
            var _id = 1065;
            var _email = "ccc@yahoo.com";
            var param = new { id = _id, email = _email }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourParticipant", content).Result;
            return response;
        }

        // Params ( id:int / email:string )
        HttpResponseMessage ActualResponse_Get_TourParticipantByIdEmail() {
            var _id = 1065;
            var _email = "ccc@yahoo.com";
            var param = new { id = _id, email = _email }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourParticipantByIdEmail", content).Result;
            return response;
        }

        // Params ( tourid:int )
        HttpResponseMessage ActualResponse_Get_TourParticipantsByTourId() {
            var _tourid = 1065;
            var param = new { tourid = _tourid }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourParticipantsByTourId", content).Result;
            return response;
        }


        #endregion

        #region TOUR REVIEW                                .

        HttpResponseMessage ActualResponse_Add_TourReview() {

            var TourReview_Insert = new TourReview_Insert {
                TourId = 1065,
                AccountId = 1,
                ReviewText = "AAAAA",
            };

            var param = new { TourReview_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_Review", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourReview() {

            var TourReview_Update = new TourReview_Update {
                ReviewId = 1,
                ReviewText = "CCCCCCCCCCCCCC",
            };
            var param = new { TourReview_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_Review", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourReview() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_Review", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_ReviewById() {
            var _id = 5;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_ReviewById", content).Result;
            return response;
        }

        // Params ( tourid:int )
        HttpResponseMessage ActualResponse_Get_ReviewListByTourId() {
            var _tourid = 1065;
            var param = new { tourid = _tourid }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_ReviewListByTourId", content).Result;
            return response;
        }


        #endregion

        #region TOUR NEWSFEED                                .

        HttpResponseMessage ActualResponse_Add_NewsFeed() {

            var Newsfeed_Insert = new Newsfeed_Insert {
                TourId = 1,
                AccountId = 1,
                NewsfeedTitle = "AAAAAAAAA",
                NewsfeedContent = "CCCCCCCCCCCCCCCCCC",
                NewsfeedDate = Convert.ToDateTime("12/25/2030"),
            };

            var param = new { Newsfeed_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_NewsFeed", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_NewsFeed() {

            var Newsfeed_Update = new Newsfeed_Update {
                NewsfeedId = 1,
                TourId = 33,
                AccountId = 1,
                NewsfeedTitle = "AAAAAAAAA",
                NewsfeedContent = "SSSSSSSSSSSSSSSSSS",
                NewsfeedDate = Convert.ToDateTime("12/25/2030"),
            };
            var param = new { Newsfeed_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_NewsFeed", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_Newsfeed() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_NewsFeed", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_NewsfeedById() {
            var _id = 5;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_NewsfeedById", content).Result;
            return response;
        }


        #endregion

        #region TOUR NOTE                                .

        // Note : Please change the value of TourId and TourPlanId that exists in TourPlan table
        HttpResponseMessage ActualResponse_Add_TourNote() {

            var TourNote_Insert = new TourNote_Insert {
                TourId = 33,
                TourPlanId = 3,
                Note = "AAAAAAAAAAAAA",
                Photo = "XXXXXXXXXXXXXXX",
                PhotoCaption = "XXXXXXXXXXXXXXX",
                Title = "XXXXXXXXXXXXXXX",
                Url = "XXXXXXXXXXXXXXX",
            };

            var param = new { TourNote_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourNote", content).Result;
            return response;
        }

        // Note : Please change the value of TourId and TourPlanId that exists in TourNote table
        HttpResponseMessage ActualResponse_Update_TourNote() {

            var TourNote_Update = new TourNote_Update {
                TourNoteId = 1,
                TourId = 10,
                TourPlanId = 36,
                Note = "BBBBBBBBBBBBBB",
                Photo = "XXXXXXXXXXXXXXX",
                PhotoCaption = "XXXXXXXXXXXXXXX",
                Title = "XXXXXXXXXXXXXXX",
                Url = "XXXXXXXXXXXXXXX",
            };

            var param = new { TourNote_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourNote", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourNote() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourNote", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourNoteById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourNoteById", content).Result;
            return response;
        }


        #endregion

        #region TOUR PLAN                                .

        HttpResponseMessage ActualResponse_Add_TourPlan() {

            var TourPlan_Insert = new TourPlan_Insert {
                TourId = 1065,
                PlanName = "AAAAAAAAAAAAA",
                PlanDate = Convert.ToDateTime("12/25/2030"),
                PlanTypeId = 3,
            };

            var param = new { TourPlan_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourPlan", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourPlan() {

            var TourPlan_Update = new TourPlan_Update {
                TourPlanId = 2130,
                TourId = 1065,
                PlanName = "SSSSSSSSSSSSSSS",
                PlanDate = Convert.ToDateTime("12/25/2030"),
                PlanTypeId = 3,
            };

            var param = new { TourPlan_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourPlan", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourPlan() {
            var _id = 2130;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourPlan", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourPlanById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourPlanById", content).Result;
            return response;
        }


        #endregion

        #region TOUR PLAN TYPE                               .

        HttpResponseMessage ActualResponse_Add_TourPlanType() {

            var TourPlanType_Insert = new TourPlanType_Insert {
                CategoryId = 1,
                PlanTypeName = "AAAAAAAAAAAAA",
            };

            var param = new { TourPlanType_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourPlanType", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourPlanType() {

            var TourPlanType_Update = new TourPlanType_Update {
                CategoryId = 1,
                TourPlanTypeId = 1,
                PlanTypeName = "AAAAAAAAAAAAA",
            };

            var param = new { TourPlanType_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourPlanType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourPlanType() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourPlanType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourPlanTypeById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourPlanTypeById", content).Result;
            return response;
        }


        #endregion

        #region TOUR ACTIVITY TYPE                               .

        HttpResponseMessage ActualResponse_Add_TourActivityType() {

            var TourActivityType_Insert = new TourActivityType_Insert {
                ActivityTypeName = "AAAAA",
            };

            var param = new { TourActivityType_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourActivityType", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourActivityType() {

            var TourActivityType_Update = new TourActivityType_Update {
                ActivityTypeId = 1,
                ActivityTypeName = "AAAAA",
            };

            var param = new { TourActivityType_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourActivityType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourActivityType() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourActivityType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourActivityTypeById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourActivityTypeById", content).Result;
            return response;
        }


        #endregion

        #region TOUR TYPE                               .

        HttpResponseMessage ActualResponse_Add_TourType() {

            var TourType_Insert = new TourType_Insert {
                TourTypeName = "AAAAA",
            };

            var param = new { TourType_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourType", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourType() {

            var TourType_Update = new TourType_Update {
                TourTypeId = 3,
                TourTypeName = "AAAAA",
            };

            var param = new { TourType_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourType() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourTypeById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourTypeById", content).Result;
            return response;
        }


        #endregion


        #region TOUR TRANSPORTATIONS                               .

        HttpResponseMessage ActualResponse_Add_TourTransportations() {

            var TourTransportations_Insert = new TourTransportations_Insert {
                TourPlanId = 2130,
                TransportationTypeId = 2,
                DateCreated = DateTime.Now,
            };

            var param = new { TourTransportations_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourTransportations", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourTransportations() {

            var TourTransportations_Update = new TourTransportations_Update {
                TransportationId = 1,
                TourPlanId = 2094,
                TransportationTypeId = 2,
                DateCreated = DateTime.Today,
            };

            var param = new { TourTransportations_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourTransportations", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourTransportations() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourTransportations", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourTransportationsById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourTransportationsById", content).Result;
            return response;
        }

        #endregion

        #region TOUR TRANSPORTATIONS CAR                              .

        HttpResponseMessage ActualResponse_Add_TourTransportationsCar() {

            var TourTransportationCar_Insert = new TourTransportationCar_Insert {
                TransportationId = 8,
                CarType = "Mustang GTO"
            };

            var param = new { TourTransportationCar_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourTransportationCar", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourTransportationsCar() {

            var TourTransportationCar_Update = new TourTransportationCar_Update {
                TransportationCarId = 1,
                TransportationId = 8,
                CarType = "AAAAA"
            };

            var param = new { TourTransportationCar_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourTransportationCar", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourTransportationsCar() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourTransportationCar", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourTransportationsCarById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourTransportationCarById", content).Result;
            return response;
        }

        #endregion

        #region TOUR TRANSPORTATIONS CRUISE                              .

        HttpResponseMessage ActualResponse_Add_TourTransportationsCruise() {

            var TourTransportationCruise_Insert = new TourTransportationCruise_Insert {
                TransportationId = 1,
                ShipName = "AAAAAAAAAAAAAA"
            };

            var param = new { TourTransportationCruise_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourTransportationCruise", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourTransportationsCruise() {

            var TourTransportationCruise_Update = new TourTransportationCruise_Update {
                TransportationCruiseId = 1,
                TransportationId = 1,
                ShipName = "AAAAAAAAAAAAAA"
            };

            var param = new { TourTransportationCruise_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourTransportationCruise", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourTransportationsCruise() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourTransportationCruise", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourTransportationsCruiseById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourTransportationCruiseById", content).Result;
            return response;
        }

        #endregion

        #region TOUR TRANSPORTATIONS FLIGHT                              .

        HttpResponseMessage ActualResponse_Add_TourTransportationsFlight() {

            var TourTransportationFlight_Insert = new TourTransportationFlight_Insert {
                TransportationId = 1,
                FlightNo = "55555555"
            };

            var param = new { TourTransportationFlight_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourTransportationFlight", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourTransportationsFlight() {

            var TourTransportationFlight_Update = new TourTransportationFlight_Update {
                TransportationFlightId = 1,
                TransportationId = 3,
                FlightNo = "88888888888"
            };

            var param = new { TourTransportationFlight_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourTransportationFlight", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourTransportationsFlight() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourTransportationFlight", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourTransportationsFlightById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourTransportationFlightById", content).Result;
            return response;
        }

        #endregion

        #region TOUR TRANSPORTATIONS TRAIN                              .

        HttpResponseMessage ActualResponse_Add_TourTransportationsTrain() {

            var TourTransportationTrain_Insert = new TourTransportationTrain_Insert {
                TransportationId = 1,
                StationName = "SSSSSSSSSS"
            };

            var param = new { TourTransportationTrain_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourTransportationTrain", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourTransportationsTrain() {

            var TourTransportationTrain_Update = new TourTransportationTrain_Update {
                TransportationTrainId = 5,
                TransportationId = 3,
                StationName = "CCCCCCCC"
            };

            var param = new { TourTransportationTrain_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourTransportationTrain", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourTransportationsTrain() {
            var _id = 5;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourTransportationTrain", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourTransportationsTrainById() {
            var _id = 5;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourTransportationTrainById", content).Result;
            return response;
        }

        #endregion



        #region TOUR TRANSPORTATION TYPE                               .

        HttpResponseMessage ActualResponse_Add_TourTransportationType() {

            var TourTransportationType_Insert = new TourTransportationType_Insert {
                TransportationTypeName = "AAAAA",
            };

            var param = new { TourTransportationType_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourTransportationType", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourTransportationType() {

            var TourTransportationType_Update = new TourTransportationType_Update {
                TransportationTypeId = 1,
                TransportationTypeName = "AAAAA",
            };

            var param = new { TourTransportationType_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourTransportationType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourTransportationType() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourTransportationType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourTransportationTypeById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourTransportationTypeById", content).Result;
            return response;
        }


        #endregion

        #region TOUR ACTIVITIES PLACE                             .

        HttpResponseMessage ActualResponse_Add_TourActivitiesPlace() {

            var TourActivitiesPlace_Insert = new TourActivitiesPlace_Insert {
                ActivityId = 3,
                Address = "AAAAA",
                DateCreated = DateTime.Now,
                Latitude = 555,
                Longitude = 888,
            };

            var param = new { TourActivitiesPlace_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourActivitiesPlace", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourActivitiesPlace() {

            var TourActivitiesPlace_Update = new TourActivitiesPlace_Update {
                ActivityPlaceId = 1,
                ActivityId = 3,
                Address = "AAAAA",
                DateCreated = DateTime.Now,
                Latitude = 555,
                Longitude = 888,
            };

            var param = new { TourActivitiesPlace_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourActivitiesPlace", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourActivitiesPlace() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourActivitiesPlace", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourActivitiesPlaceById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourActivitiesPlaceById", content).Result;
            return response;
        }


        #endregion

        #region TOUR ATTACHMENT                       .

        HttpResponseMessage ActualResponse_Add_TourAttachment() {

            var TourAttachment_Insert = new TourAttachment_Insert {
                ActivityId = 3,
                AttachmentName = "AAAAA",
                AttachmentPath = "BBBBB",
                DateCreated = DateTime.Now,
            };

            var param = new { TourAttachment_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourAttachment", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourAttachment() {

            var TourAttachment_Update = new TourAttachment_Update {
                AttachmentId = 1,
                ActivityId = 3,
                AttachmentName = "AAAAA",
                AttachmentPath = "BBBBB",
                DateCreated = DateTime.Now,
            };

            var param = new { TourAttachment_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourAttachment", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourAttachment() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourAttachment", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourAttachmentById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourAttachmentById", content).Result;
            return response;
        }


        #endregion

        #region TOUR DIRECTIONS                       .

        HttpResponseMessage ActualResponse_Add_TourDirections() {

            var TourDirections_Insert = new TourDirections_Insert {
                ActivityId = 1,
                DateCreated = DateTime.Now,
                DirectionTypeId = 1,
                TransportationId = 1,
            };

            var param = new { TourDirections_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourDirections", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourDirections() {

            var TourDirections_Update = new TourDirections_Update {
                TourDirectionId = 1,
                ActivityId = 1,
                DateCreated = DateTime.Now,
                DirectionTypeId = 1,
                TransportationId = 1,
            };

            var param = new { TourDirections_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourDirections", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourDirections() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourDirections", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourDirectionsById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourDirectionsById", content).Result;
            return response;
        }


        #endregion

        #region TOUR DIRECTION TYPE                       .

        HttpResponseMessage ActualResponse_Add_TourDirectionType() {

            var TourDirectionType_Insert = new TourDirectionType_Insert {
                DirectionTypeName = "AAAAAAAAAAAAAAAAAAA",
            };

            var param = new { TourDirectionType_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourDirectionType", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourDirectionType() {

            var TourDirectionType_Update = new TourDirectionType_Update {
                DirectionTypeId = 1,
                DirectionTypeName = "CCCCCCCCCCCCC",
            };

            var param = new { TourDirectionType_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourDirectionType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourDirectionType() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourDirectionType", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourDirectionTypeById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourDirectionTypeById", content).Result;
            return response;
        }


        #endregion

        #region TOUR DIRECTIONS PATH                      .

        HttpResponseMessage ActualResponse_Add_TourDirectionsPath() {

            var TourDirectionsPath_Insert = new TourDirectionsPath_Insert {
                AirportId = 1,
                DateCreated = DateTime.Now,
                TimeZoneId = 1,
                TourDirectionId = 1,
            };

            var param = new { TourDirectionsPath_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourDirectionsPath", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourDirectionsPath() {

            var TourDirectionsPath_Update = new TourDirectionsPath_Update {
                DirectionPathId = 1,
                AirportId = 1,
                DateCreated = DateTime.Now,
                TimeZoneId = 1,
                TourDirectionId = 1,
            };

            var param = new { TourDirectionsPath_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourDirectionsPath", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourDirectionsPath() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourDirectionsPath", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourDirectionsPathById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourDirectionsPathById", content).Result;
            return response;
        }


        #endregion

        #region AIRPORTS                       .

        HttpResponseMessage ActualResponse_Add_Airports() {

            var Airports_Insert = new Airports_Insert {
                Altitude = "AAAAA",
                City = "AAAAA",
                Country = "AAAAA",
                Dst = "AAAAA",
                Iata = "AAAAA",
                Icao = "AAAAA",
                Latitude = "AAAAA",
                Longitude = "AAAAA",
                Name = "AAAAA",
                Timezone = "AAAAA",
                Tzdatabase = "AAAAA",
            };

            var param = new { Airports_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_Airports", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_Airports() {

            var Airports_Update = new Airports_Update {
                AirportId = 1,
                Altitude = "AAAAA",
                City = "AAAAA",
                Country = "AAAAA",
                Dst = "AAAAA",
                Iata = "AAAAA",
                Icao = "AAAAA",
                Latitude = "AAAAA",
                Longitude = "AAAAA",
                Name = "AAAAA",
                Timezone = "AAAAA",
                Tzdatabase = "AAAAA",
            };

            var param = new { Airports_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_Airports", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_Airports() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_Airports", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_AirportsById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_AirportsById", content).Result;
            return response;
        }


        #endregion






        #region TOUR ACTIVITIES                               .

        HttpResponseMessage ActualResponse_Add_TourActivities() {

            var TourActivities_Insert = new TourActivities_Insert {
                ActivityTypeId = 3,
                TourPlanId = 2130,
                TourId = 1065,
                DateCreated = DateTime.Today,
            };

            var param = new { TourActivities_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourActivities", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourActivities() {

            var TourActivities_Update = new TourActivities_Update {
                ActivityId = 1,
                ActivityTypeId = 3,
                TourPlanId = 2130,
                TourId = 1065,
                DateCreated = DateTime.Today,
            };

            var param = new { TourActivities_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourActivities", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourActivities() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourActivities", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourActivitiesById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourActivitiesById", content).Result;
            return response;
        }

        #endregion

        #region TOUR ACTIVITIES DINING                              .

        HttpResponseMessage ActualResponse_Add_TourActivitiesDining() {

            var TourActivitiesDining_Insert = new TourActivitiesDining_Insert {
                ActivityId = 3,
                DiningName = "AAAAAA",
                DiningPlace = "BBBBBBBBB"
            };

            var param = new { TourActivitiesDining_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourActivitiesDining", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourActivitiesDining() {

            var TourActivitiesDining_Update = new TourActivitiesDining_Update {
                ActivityDiningId = 1,
                ActivityId = 3,
                DiningName = "AAAAAA",
                DiningPlace = "BBBBBBBBB"
            };

            var param = new { TourActivitiesDining_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourActivitiesDining", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourActivitiesDining() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourActivitiesDining", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourActivitiesDiningById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourActivitiesDiningById", content).Result;
            return response;
        }

        #endregion

        #region TOUR ACTIVITIES LODGING                              .

        HttpResponseMessage ActualResponse_Add_TourActivitiesLodging() {

            var TourActivitiesLodging_Insert = new TourActivitiesLodging_Insert {
                ActivityId = 3,
                LodgingName = "AAAAAA",
                LodgingPlace = "BBBBBBBBB"
            };

            var param = new { TourActivitiesLodging_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourActivitiesLodging", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourActivitiesLodging() {

            var TourActivitiesLodging_Update = new TourActivitiesLodging_Update {
                ActivityLodgingId = 1,
                ActivityId = 3,
                LodgingName = "AAAAAA",
                LodgingPlace = "BBBBBBBBB"
            };

            var param = new { TourActivitiesLodging_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourActivitiesLodging", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourActivitiesLodging() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourActivitiesLodging", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourActivitiesLodgingById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourActivitiesLodgingById", content).Result;
            return response;
        }

        #endregion

        #region TOUR ACTIVITIES MEETING                              .

        HttpResponseMessage ActualResponse_Add_TourActivitiesMeeting() {

            var TourActivitiesMeeting_Insert = new TourActivitiesMeeting_Insert {
                ActivityId = 3,
                MeetingName = "AAAAAA",
                MeetingPlace = "BBBBBBBBB"
            };

            var param = new { TourActivitiesMeeting_Insert }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Add_TourActivitiesMeeting", content).Result;
            return response;
        }

        HttpResponseMessage ActualResponse_Update_TourActivitiesMeeting() {

            var TourActivitiesMeeting_Update = new TourActivitiesMeeting_Update {
                ActivityMeetingId = 1,
                ActivityId = 3,
                MeetingName = "AAAAAA",
                MeetingPlace = "BBBBBBBBB"
            };

            var param = new { TourActivitiesMeeting_Update }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Update_TourActivitiesMeeting", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Delete_TourActivitiesMeeting() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Delete_TourActivitiesMeeting", content).Result;
            return response;
        }

        // Params ( id:int )
        HttpResponseMessage ActualResponse_Get_TourActivitiesMeetingById() {
            var _id = 1;
            var param = new { id = _id }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourActivitiesMeetingById", content).Result;
            return response;
        }

        #endregion



        #endregion


        #region INTEGRATION TEST                        .

        #region TOUR                           .

        [Fact]
        public void Test_Add_Tour() {
            var actual = ActualResponse_Add_Tour();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<Tour_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(Tour_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_Tour() {
            var actual = ActualResponse_Update_Tour();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<Tour_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(Tour_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_Tour() {
            var actual = ActualResponse_Delete_Tour();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourListByAccountId() {
            var actual = ActualResponse_Get_TourListByAccountId();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<List<Tour_View>>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(List<Tour_View>), responseType.GetType());
        }

        [Fact]
        public void Test_Get_TourByDate() {
            var actual = ActualResponse_Get_TourListByDate();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<List<Tour_View>>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(List<Tour_View>), responseType.GetType());
        }


        #endregion

        #region TOUR PARTICIPANT                         .

        [Fact]
        public void Test_Add_TourParticipant() {
            var actual = ActualResponse_Add_TourParticipant();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourParticipant_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourParticipant_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourParticipant() {
            var actual = ActualResponse_Update_TourParticipant();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourParticipant_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourParticipant_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourParticipant() {
            var actual = ActualResponse_Delete_TourParticipant();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourParticipantByIdEmail() {
            var actual = ActualResponse_Get_TourParticipantByIdEmail();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourParticipant>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourParticipant), responseType.GetType());
        }

        [Fact]
        public void Test_Get_TourParticipantsByTourId() {
            var actual = ActualResponse_Get_TourParticipantsByTourId();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<List<TourParticipant>>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(List<TourParticipant>), responseType.GetType());
        }

        #endregion

        #region TOUR REVIEW                          .

        [Fact]
        public void Test_Add_TourReview() {
            var actual = ActualResponse_Add_TourReview();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourReview_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourReview_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourReview() {
            var actual = ActualResponse_Update_TourReview();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourReview_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourReview_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourReview() {
            var actual = ActualResponse_Delete_TourReview();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_ReviewById() {
            var actual = ActualResponse_Get_ReviewById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourReview>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourReview), responseType.GetType());
        }

        [Fact]
        public void Test_Get_ReviewListByTourId() {
            var actual = ActualResponse_Get_ReviewListByTourId();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<List<TourReview_View>>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(List<TourReview_View>), responseType.GetType());
        }


        #endregion

        //#region NEWSFEED                         .

        //[Fact]
        //public void Test_Add_NewsFeed() {
        //    var actual = ActualResponse_Add_NewsFeed();
        //    var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<Newsfeed_Insert>();

        //    Assert.NotNull(actual);
        //    Assert.Equal("OK", actual.ReasonPhrase);
        //    Assert.Equal(typeof(Newsfeed_Insert), responseType.GetType());
        //}

        //[Fact]
        //public void Test_Update_NewsFeed() {
        //    var actual = ActualResponse_Update_NewsFeed();
        //    var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<Newsfeed_Update>();

        //    Assert.NotNull(actual);
        //    Assert.Equal("OK", actual.ReasonPhrase);
        //    Assert.Equal(typeof(TourReview_Update), responseType.GetType());
        //}

        //[Fact]
        //public void Test_Delete_Newsfeed() {
        //    var actual = ActualResponse_Delete_Newsfeed();
        //    var responseValue = actual.Content.ReadAsStringAsync().Result;

        //    Assert.NotNull(actual);
        //    Assert.Equal("OK", actual.ReasonPhrase);
        //    Assert.True(Convert.ToBoolean(responseValue));
        //}

        //[Fact]
        //public void Test_Get_NewsfeedById() {
        //    var actual = ActualResponse_Get_NewsfeedById();
        //    var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<Newsfeed>();

        //    Assert.NotNull(actual);
        //    Assert.Equal("OK", actual.ReasonPhrase);
        //    Assert.Equal(typeof(Newsfeed), responseType.GetType());
        //}

        //#endregion

        #region TOUR NOTE                                .

        [Fact]
        public void Test_Add_TourNote() {
            var actual = ActualResponse_Add_TourNote();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourNote_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourNote_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourNote() {
            var actual = ActualResponse_Update_TourNote();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourNote_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourNote_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourNote() {
            var actual = ActualResponse_Delete_TourNote();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourNoteById() {
            var actual = ActualResponse_Get_TourNoteById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourNote>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourNote), responseType.GetType());
        }

        #endregion

        #region TOUR PLAN                                .

        [Fact]
        public void Test_Add_TourPlan() {
            var actual = ActualResponse_Add_TourPlan();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourPlan_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourPlan_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourPlan() {
            var actual = ActualResponse_Update_TourPlan();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourPlan_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourPlan_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourPlan() {
            var actual = ActualResponse_Delete_TourPlan();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourPlanById() {
            var actual = ActualResponse_Get_TourPlanById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourPlan>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourPlan), responseType.GetType());
        }

        #endregion

        #region TOUR PLAN TYPE                               .

        [Fact]
        public void Test_Add_TourPlanType() {
            var actual = ActualResponse_Add_TourPlanType();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourPlanType_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourPlanType_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourPlanType() {
            var actual = ActualResponse_Update_TourPlanType();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourPlanType_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourPlanType_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourPlanType() {
            var actual = ActualResponse_Delete_TourPlanType();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourPlanTypeById() {
            var actual = ActualResponse_Get_TourPlanTypeById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourPlanType>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourPlanType), responseType.GetType());
        }

        #endregion

        #region TOUR ACTIVITY TYPE                               .

        [Fact]
        public void Test_Add_TourActivityType() {
            var actual = ActualResponse_Add_TourActivityType();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivityType_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivityType_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourActivityType() {
            var actual = ActualResponse_Update_TourActivityType();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivityType_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivityType_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourActivityType() {
            var actual = ActualResponse_Delete_TourActivityType();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourActivityTypeById() {
            var actual = ActualResponse_Get_TourActivityTypeById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivityType>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivityType), responseType.GetType());
        }

        #endregion

        #region TOUR TYPE                                .

        [Fact]
        public void Test_Add_TourType() {
            var actual = ActualResponse_Add_TourType();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourType_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourType_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourType() {
            var actual = ActualResponse_Update_TourType();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourType_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourType_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourType() {
            var actual = ActualResponse_Delete_TourType();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourTypeById() {
            var actual = ActualResponse_Get_TourTypeById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourType>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourType), responseType.GetType());
        }

        #endregion


        #region TOUR TRANSPORTATIONS                                .

        [Fact]
        public void Test_Add_TourTransportations() {
            var actual = ActualResponse_Add_TourTransportations();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportations_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportations_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourTransportations() {
            var actual = ActualResponse_Update_TourTransportations();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportations_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportations_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourTransportations() {
            var actual = ActualResponse_Delete_TourTransportations();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourTransportationsById() {
            var actual = ActualResponse_Get_TourTransportationsById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportations>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportations), responseType.GetType());
        }

        #endregion

        #region TOUR TRANSPORTATIONS CAR                               .

        [Fact]
        public void Test_Add_TourTransportationsCar() {
            var actual = ActualResponse_Add_TourTransportationsCar();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportationCar_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportationCar_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourTransportationsCar() {
            var actual = ActualResponse_Update_TourTransportationsCar();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportationCar_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportationCar_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourTransportationsCar() {
            var actual = ActualResponse_Delete_TourTransportationsCar();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourTransportationsCarById() {
            var actual = ActualResponse_Get_TourTransportationsCarById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportations>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportations), responseType.GetType());
        }

        #endregion

        #region TOUR TRANSPORTATIONS CRUISE                               .

        [Fact]
        public void Test_Add_TourTransportationsCruise() {
            var actual = ActualResponse_Add_TourTransportationsCruise();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportationCruise_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportationCruise_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourTransportationsCruise() {
            var actual = ActualResponse_Update_TourTransportationsCruise();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportationCruise_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportationCruise_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourTransportationsCruise() {
            var actual = ActualResponse_Delete_TourTransportationsCruise();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourTransportationsCruiseById() {
            var actual = ActualResponse_Get_TourTransportationsCruiseById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportations>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportations), responseType.GetType());
        }

        #endregion

        #region TOUR TRANSPORTATIONS FLIGHT                               .

        [Fact]
        public void Test_Add_TourTransportationsFlight() {
            var actual = ActualResponse_Add_TourTransportationsFlight();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportationFlight_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportationFlight_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourTransportationsFlight() {
            var actual = ActualResponse_Update_TourTransportationsFlight();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportationFlight_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportationFlight_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourTransportationsFlight() {
            var actual = ActualResponse_Delete_TourTransportationsFlight();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourTransportationsFlightById() {
            var actual = ActualResponse_Get_TourTransportationsFlightById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportations>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportations), responseType.GetType());
        }

        #endregion

        #region TOUR TRANSPORTATIONS TRAIN                               .

        [Fact]
        public void Test_Add_TourTransportationsTrain() {
            var actual = ActualResponse_Add_TourTransportationsTrain();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportationTrain_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportationTrain_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourTransportationsTrain() {
            var actual = ActualResponse_Update_TourTransportationsTrain();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportationTrain_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportationTrain_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourTransportationsTrain() {
            var actual = ActualResponse_Delete_TourTransportationsTrain();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourTransportationsTrainById() {
            var actual = ActualResponse_Get_TourTransportationsTrainById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourTransportations>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourTransportations), responseType.GetType());
        }

        #endregion



        #region TOUR ACTIVITIES                                .

        [Fact]
        public void Test_Add_TourActivities() {
            var actual = ActualResponse_Add_TourActivities();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivities_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivities_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourActivities() {
            var actual = ActualResponse_Update_TourActivities();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivities_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivities_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourActivities() {
            var actual = ActualResponse_Delete_TourActivities();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourActivitiesById() {
            var actual = ActualResponse_Get_TourActivitiesById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivities>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivities), responseType.GetType());
        }

        #endregion

        #region TOUR ACTIVITIES DINING                               .

        [Fact]
        public void Test_Add_TourActivitiesDining() {
            var actual = ActualResponse_Add_TourActivitiesDining();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesDining_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesDining_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourActivitiesDining() {
            var actual = ActualResponse_Update_TourActivitiesDining();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesDining_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesDining_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourActivitiesDining() {
            var actual = ActualResponse_Delete_TourActivitiesDining();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourActivitiesDiningById() {
            var actual = ActualResponse_Get_TourActivitiesDiningById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesDining>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesDining), responseType.GetType());
        }

        #endregion

        #region TOUR ACTIVITIES LODGING                               .

        [Fact]
        public void Test_Add_TourActivitiesLodging() {
            var actual = ActualResponse_Add_TourActivitiesLodging();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesLodging_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesLodging_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourActivitiesLodging() {
            var actual = ActualResponse_Update_TourActivitiesLodging();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesLodging_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesLodging_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourActivitiesLodging() {
            var actual = ActualResponse_Delete_TourActivitiesLodging();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourActivitiesLodgingById() {
            var actual = ActualResponse_Get_TourActivitiesLodgingById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesLodging>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesLodging), responseType.GetType());
        }

        #endregion

        #region TOUR ACTIVITIES MEETING                               .

        [Fact]
        public void Test_Add_TourActivitiesMeeting() {
            var actual = ActualResponse_Add_TourActivitiesMeeting();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesMeeting_Insert>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesMeeting_Insert), responseType.GetType());
        }

        [Fact]
        public void Test_Update_TourActivitiesMeeting() {
            var actual = ActualResponse_Update_TourActivitiesMeeting();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesMeeting_Update>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesMeeting_Update), responseType.GetType());
        }

        [Fact]
        public void Test_Delete_TourActivitiesMeeting() {
            var actual = ActualResponse_Delete_TourActivitiesMeeting();
            var responseValue = actual.Content.ReadAsStringAsync().Result;

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.True(Convert.ToBoolean(responseValue));
        }

        [Fact]
        public void Test_Get_TourActivitiesMeetingById() {
            var actual = ActualResponse_Get_TourActivitiesMeetingById();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<TourActivitiesMeeting>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(TourActivitiesMeeting), responseType.GetType());
        }

        #endregion




        #endregion

    }


}
