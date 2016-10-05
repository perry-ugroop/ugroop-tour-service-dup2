using Ugroop.API.SQL.Helper.Filter;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {

    [UserSessionFilter]
    public class SecurityController : BaseController {
        public SecurityController(IAccountService accountService, IUserService userService) : base(accountService, userService) { }

        public SecurityController(IUserService userService, ISysAccessService sysAccessService) : base(userService, sysAccessService) { }

        public SecurityController(IUserService userService, IReferenceService referenceService) : base(userService, referenceService) { }

        public SecurityController(IUserService userService, ISettingService settingService) : base(userService, settingService) { }

        public SecurityController(IUserService userService, ITourService tourService) : base(userService, tourService) { }

    }

}
