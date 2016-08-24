using System.Web.Http;
using System.Web.Http.Cors;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {

    [EnableCors(origins: "http://localhost:46013", headers: " * ", methods: "*")]
    public class BaseController : ApiController {

        private IAccountService _accountService;
        private IReferenceService _referenceService;
        private ISettingService _settingService;
        private IUserService _userService;

        #region Public Properties                   .

        public IAccountService AccountService {
            get { return _accountService; }
        }

        public IReferenceService ReferenceService {
            get { return _referenceService; }
        }

        public ISettingService SettingService {
            get { return _settingService; }
        }

        public IUserService UserService {
            get { return _userService; }
        }

        #endregion

        public BaseController(IAccountService accountService) {
            _accountService = accountService;
        }

        public BaseController(IAccountService accountService, IUserService userService) {
            _accountService = accountService;
            _userService = userService;
        }

        public BaseController(IAccountService accountService, IReferenceService referenceService) {
            _accountService = accountService;
            _referenceService = referenceService;
        }

        public BaseController(IAccountService accountService, IReferenceService referenceService, ISettingService settingService) {
            _accountService = accountService;
            _referenceService = referenceService;
            _settingService = settingService;
        }

        public BaseController(IAccountService accountService, IReferenceService referenceService,
                              ISettingService settingService, IUserService userService) {
            _accountService = accountService;
            _referenceService = referenceService;
            _settingService = settingService;
            _userService = userService;
        }

    }

}
