using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web.Http;
using Ugroop.API.SQL.Helper.Json;
using UGroopData.Sql.Repository.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {

    public class UserController : SecurityController {

        public UserController(IAccountService accountService, IUserService userService) : base(accountService, userService) { }

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
            int userId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(UserService.Get_AccountById(userId).JsonSerialize())
            };
        }


        // POST : Add Account
        [HttpPost]
        public HttpResponseMessage Add_Account(JObject jsonData) {
            var account = JEntity<Account>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(UserService.Add(account).JsonSerialize())
            };
        }

        // POST : Update Account
        [HttpPost]
        public HttpResponseMessage Update_Account(JObject jsonData) {
            var account = JEntity<Account>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(UserService.Update(account).JsonSerialize())
            };
        }


        #endregion

        #region ACCOUNT INFO                .


        // POST : Get AccountInfo by Id
        [HttpPost]
        public HttpResponseMessage Get_AccountInfoById(JObject jsonData) {
            var idAccount = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountByAccountId(idAccount).JsonSerialize())
            };
        }


        #endregion


    }


}
