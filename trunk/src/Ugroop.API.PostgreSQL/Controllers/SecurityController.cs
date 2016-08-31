using Ugroop.API.PostgreSQL.Helper.Filter;
using UGroopData.PostgreSql.Service.UGroopWeb.Interface;

namespace Ugroop.API.PostgreSQL.Controllers {

    [UserSessionFilter]
    public class SecurityController : BaseController {
        public SecurityController(IAccountService accountService, IUserService userService) : base(accountService, userService) { }
    }

}
