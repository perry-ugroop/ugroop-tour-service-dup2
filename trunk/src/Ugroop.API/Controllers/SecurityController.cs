using Ugroop.API.Helper.Filter;
using UGroopData.Mongo.Service.UGroopWeb.Interface;

namespace Ugroop.API.Controllers {

    [UserSessionFilter]
    public class SecurityController : BaseController {

        public SecurityController(IAccountService accountService) : base(accountService) { }

    }

}
