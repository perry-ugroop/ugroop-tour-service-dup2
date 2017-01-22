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
        HttpResponseMessage ActualResponse_Get_TourByDate() {
            var _startdate = "12/20/2016 00:00:00";
            var _enddate = "12/30/2016 23:59:59";

            var param = new { startdate = _startdate, enddate = _enddate }.JsonSerialize();
            var content = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = ClientBase().PostAsync("Tour/Get_TourByDate", content).Result;
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
            var actual = ActualResponse_Get_TourByDate();
            var responseType = actual.Content.ReadAsStringAsync().Result.JsonDeserialize<List<Tour_View>>();

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.ReasonPhrase);
            Assert.Equal(typeof(List<Tour_View>), responseType.GetType());
        }


        #endregion


        #endregion

    }


}
