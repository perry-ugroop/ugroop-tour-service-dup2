using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web.Http;
using Ugroop.API.Mongo.Helper.Filter;
using Ugroop.API.Mongo.Helper.Json;
using UgroopData.Entity;
using UGroopData.Mongo.Service.UGroopWeb.Interface;

namespace Ugroop.API.Mongo.Controllers {

    public class UserController : SecurityController {

        public UserController(IAccountService accountService) : base(accountService) { }


        // GET : Login -> Token / API Key
        [HttpGet]
        public HttpResponseMessage ValidateUser(string username, string password) {
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.ValidateUser(username, password).JsonSerialize())
            };
        }
       
        #region ACCOUNT                 .

        // POST : Get Account By Id
        [HttpPost]
        public HttpResponseMessage Get_AccountById(JObject jsonData) {
            var userId = JsonData.Instance(jsonData).Get_JsonObject("id").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountById(userId).JsonSerialize())
            };
        }


        // POST : Add Account
        [HttpPost]
        public HttpResponseMessage Add_Account(JObject jsonData) {
            var account = JEntity<Account>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(account).JsonSerialize())
            };
        }

        // POST : Update Account
        [HttpPost]
        public HttpResponseMessage Update_Account(JObject jsonData) {
            var account = JEntity<Account>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Update(account).JsonSerialize())
            };
        }


        #endregion

        #region ACCOUNT INFO                .


        // POST : Get AccountInfo by Id
        [HttpPost]
        public HttpResponseMessage Get_AccountInfoById(JObject jsonData) {
            var idAccount = JsonData.Instance(jsonData).Get_JsonObject("id").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountInfoById(idAccount).JsonSerialize())
            };
        }


        #endregion


    }


}
