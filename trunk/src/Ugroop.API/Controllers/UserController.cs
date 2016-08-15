using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using Ugroop.API.Helper.Filter;
using Ugroop.API.Helper.Json;
using UgroopData.Entity;
using UGroopData.Mongo.Service.UGroopWeb.Interface;

namespace Ugroop.API.Controllers {

    public class UserController : ApiController {

        private IAccountService _accountService;
        private IReferenceService _referenceService;
        private ISettingService _settingService;

        private string UserSessionKey;

        public IAccountService AccountService {
            get { return _accountService; }
        }

        public UserController(IAccountService accountService, IReferenceService referenceService, ISettingService settingService) {
            _accountService = accountService;
            _referenceService = referenceService;
            _settingService = settingService;

            //Request.Properties["UserSessionId"] = UserSessionKey;
            //Request.Properties["AccountService"] = _accountService;
        }



        // GET : Login -> Token / API Key
        [HttpGet]
        public string ValidateUser(string username, string password) {
            try {
                return JsonConvert.SerializeObject(_accountService.ValidateUser(username, password));
            }
            catch (Exception ex) {
                return ex.InnerException.Message;
            }
        }

        // GET : Account by Id
        public string Get_AccountById(string id) {
            return JsonConvert.SerializeObject(_accountService.Get_AccountById(id));
        }

        //// POST : Add Account
        //[HttpPost]
        //public bool Add_Account(Account account) {
        //    return _accountService.Add(account);
        //}

        // POST : Add Account
        [UserSessionFilter]
        [HttpPost]
        public bool Add_Account(JObject jsonData) {

            var account = JEntity<Account>.Instance().Get_Entity(jsonData);

            return _accountService.Add(account);
        }

    }


}
