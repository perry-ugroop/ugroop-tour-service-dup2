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

        // GET : Account by Id
        public string Get_AccountById(string id) {
            return JsonConvert.SerializeObject(AccountService.Get_AccountById(id));
        }

        // POST : Add Account
        [HttpPost]
        public bool Add_Account(JObject jsonData) {

            var account = JEntity<Account>.Instance().Get_Entity(jsonData);
            //return _accountService.Add(account);

            return AccountService.Add(account);

        }

    }


}
