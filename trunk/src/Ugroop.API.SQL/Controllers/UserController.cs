using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web.Http;
using Ugroop.API.SQL.Helper.Filter;
using Ugroop.API.SQL.Helper.Json;
using UGroopData.Sql.Repository.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {

    [ApiExceptionFilter]
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
                Content = new StringContent(UserService.ValidateUser(username, password).JsonSerialize())
            };
        }

        #region ACCOUNT                     .

        ///<summary>
        ///POST : Get Account By Id (id)
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

        ///<summary>
        ///POST : AccountExistsByEmail(email)
        ///</summary>
        ///<remarks>
        ///Check if email exists in user database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage AccountExistsByEmail(JObject jsonData) {
            var email = JsonData.Instance(jsonData).Get_JsonObject("email").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(UserService.AccountExistsByEmail(email).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : AccountExistsByEmailPassword(email,password)
        ///</summary>
        ///<remarks>
        ///Check if email and password exists in user database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage AccountExistsByEmailPassword(JObject jsonData) {
            var email = JsonData.Instance(jsonData).Get_JsonObject("email").ToString();
            var password = JsonData.Instance(jsonData).Get_JsonObject("password").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(UserService.AccountExistsByEmailPassword(email, password).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : ActivateSignUp(email)
        ///</summary>
        ///<remarks>
        ///Check if account is active by email.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage ActivateSignUp(JObject jsonData) {
            var email = JsonData.Instance(jsonData).Get_JsonObject("email").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(UserService.ActivateSignUp(email).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : ActivateSignUpByVerficationCode(email,verificationcode)
        ///</summary>
        ///<remarks>
        ///Check if account is active by email and verificationcode.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage ActivateSignUpByVerficationCode(JObject jsonData) {
            var email = JsonData.Instance(jsonData).Get_JsonObject("email").ToString();
            var verificationcode = JsonData.Instance(jsonData).Get_JsonObject("verificationcode").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(UserService.ActivateSignUp(email).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : GetAccountByEmail(email)
        ///</summary>
        ///<remarks>
        ///Get Account by email.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage GetAccountByEmail(JObject jsonData) {
            var email = JsonData.Instance(jsonData).Get_JsonObject("email").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(UserService.GetAccountByEmail(email).JsonSerialize())
            };
        }

        #endregion

        

    }

}
