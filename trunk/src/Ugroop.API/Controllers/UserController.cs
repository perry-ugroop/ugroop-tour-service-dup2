using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using Ugroop.API.Helper.Filter;
using Ugroop.API.Helper.Json;
using UgroopData.Entity;
using UGroopData.Mongo.Service.UGroopWeb.Interface;

namespace Ugroop.API.Controllers {

    public class UserController : SecurityController {

        public UserController(IAccountService accountService) : base(accountService) { }

        // GET : Login -> Token / API Key
        [HttpGet]
        public string ValidateUser(string username, string password) {
            try {
                return JsonConvert.SerializeObject(AccountService.ValidateUser(username, password));
            }
            catch (Exception ex) {
                return ex.InnerException.Message;
            }
        }

        // POST : Get Account by Id
        //public string Get_AccountById(string id) {
        [HttpPost]
        public string Get_AccountById(JObject jsonData) {
            var idAccount = JsonData.Instance(jsonData).Get_JsonObject("id").ToString();
            //var data = JsonConvert.SerializeObject(AccountService.Get_AccountById(idAccount));
            return JsonConvert.SerializeObject(AccountService.Get_AccountById(idAccount));
        }

        // POST : Add Account
        [HttpPost]
        public bool Add_Account(JObject jsonData) {
            var account = JEntity<Account>.Instance().Get_Entity(jsonData);
            return AccountService.Add(account);
        }


        // POST : Get AccountInfo by Id
        [HttpPost]
        public string Get_AccountInfoById(JObject jsonData) {
            var idAccount = JsonData.Instance(jsonData).Get_JsonObject("id").ToString();
            var data = JsonConvert.SerializeObject(AccountService.Get_AccountInfoById(idAccount));
            return JsonConvert.SerializeObject(AccountService.Get_AccountInfoById(idAccount));
        }



    }


}
