using System;
using System.Net.Http;
using System.Net.Http.Headers;
using UGroopData.Entity.ViewModel.SQL.Data;
using UGroopData.Utilities.String;
using Xunit;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Ugroop.API.IntegrationTest;
using System.Collections.Generic;

namespace Ugroop.API.IntegrationTest {

    public class TourIntegrationTest {

        private const string AccessToken = "eyJraWQiOiJNRTJaUU9KTUE1N1ZTREQ4WFBXMVE3QjFYIiwic3R0IjoiYWNjZXNzIiwiYWxnIjoiSFMyNTYifQ.eyJqdGkiOiI1dDdNMGRkdzJtSXpydUZRUGxyYXJsIiwiaWF0IjoxNDgzMzkzNTE5LCJpc3MiOiJodHRwczovL2FwaS5zdG9ybXBhdGguY29tL3YxL2FwcGxpY2F0aW9ucy8zZkhjTGg1UDZSMkpZcTJFeG1IVWl6Iiwic3ViIjoiaHR0cHM6Ly9hcGkuc3Rvcm1wYXRoLmNvbS92MS9hY2NvdW50cy8xYVhxRkFPT3V6OXBvbUVzVlExZmpwIiwiZXhwIjoxNDgzMzk3MTE5LCJydGkiOiI1dDdNMGFKcjhDMDFGNTlaRFcwS0ZoIn0.RDmBTCjkRwBsXhciMU_2etKjkKNDD0oWY_-PlDybJvM";

        #region HTTPCLIENT BASE                     .

        private HttpClient ClientBase() {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"].ToString());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            return client;
        }

        #endregion

        #region ACTUAL HTTP RESPONSE                    .

        #region TOUR                                .

        HttpResponseMessage ActualResponse_Add_Tour() {

            var Tour_Insert = new Tour_Insert {
                DestinationCity = "Mars City",
                OrganizedBy = 3,
                Photo = "AAA",
                TourDescription = "AAA",
                TourName = "AAA",
                TourTypeId = 1,
                StartDate = Convert.ToDateTime("12/25/2017"),
                EndDate = Convert.ToDateTime("12/30/2017"),
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
                DestinationCity = "Mars City",
                OrganizedBy = 3,
                Photo = "XXXXX",
                TourDescription = "AAA",
                TourName = "AAA",
                TourTypeId = 1,
                StartDate = Convert.ToDateTime("12/25/2017"),
                EndDate = Convert.ToDateTime("12/30/2017"),
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
