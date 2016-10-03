using Ugroop.API.SQL.Helper.Filter;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {

    [UserSessionFilter]
    public class SecurityController : BaseController {
        public SecurityController(IAccountService accountService, IUserService userService) : base(accountService, userService) { }

        public SecurityController(IUserService userService, ISysAccessService sysAccessService) : base(userService, sysAccessService) { }

    }

}
