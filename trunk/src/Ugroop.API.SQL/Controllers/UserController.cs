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

        ///<summary>
        ///GET : Login -> Token / API Key
        ///</summary>
        ///<remarks>
        ///Validate username and password. Create session key as additional parameter for upcoming transactions.
        ///</remarks>
        [HttpGet]
        public HttpResponseMessage ValidateUser(string username, string password) {
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.ValidateUser(username, password).JsonSerialize())
            };
        }


        #region ACCOUNT                 .

        ///<summary>
        ///POST : Get Account By Id
        ///</summary>
        ///<remarks>
        ///Find Account record by Id.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AccountById(JObject jsonData) {
            int userId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(UserService.Get_AccountById(userId).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Add Account
        ///</summary>
        ///<remarks>
        ///Add new Account in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_Account(JObject jsonData) {
            var account = JEntity<Account>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(UserService.Add(account).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update_Account
        ///</summary>
        ///<remarks>
        ///Update existing Account in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_Account(JObject jsonData) {
            var account = JEntity<Account>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(UserService.Update(account).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : LogUser(username,pass)
        ///</summary>
        ///<remarks>
        ///Returns Account in JSON format by given username and password.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage LogUser(JObject jsonData) {
            var username = JsonData.Instance(jsonData).Get_JsonObject("username").ToString();
            var pass = JsonData.Instance(jsonData).Get_JsonObject("pass").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(UserService.LogUser(username, pass).JsonSerialize())
            };
        }


        #endregion




        #region ACCOUNT INFO                .



        ///<summary>
        ///POST : Add AccountInfo
        ///</summary>
        ///<remarks>
        ///Add new AccountInfo in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_AccountInfo(JObject jsonData) {
            var accountInfo = JEntity<Account_Info>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(accountInfo).JsonSerialize())
            };
        }


        ///<summary>
        ///POST : Get AccountInfo by Id
        ///</summary>
        ///<remarks>
        ///Find AccountInfo record by Id.
        ///</remarks>
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
