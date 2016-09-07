using System.Web.Http;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {

    public class BaseController : ApiController {

        #region Private Properties                  .

        private IAccountService _accountService;
        private IReferenceService _referenceService;
        private ISettingService _settingService;
        private IUserService _userService;
        private ISysAccessService _sysAccessService;

        #endregion

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

        public ISysAccessService SysAccessService {
            get { return _sysAccessService; }
        }

        #endregion

        public BaseController(IAccountService accountService) {
            _accountService = accountService;
        }

        public BaseController(IUserService userService, ISysAccessService sysAccessService) {
            _userService = userService;
            _sysAccessService = sysAccessService;
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
