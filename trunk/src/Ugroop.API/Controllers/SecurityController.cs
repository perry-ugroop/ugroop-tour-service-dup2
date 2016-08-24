using Ugroop.API.Mongo.Helper.Filter;
using UGroopData.Mongo.Service.UGroopWeb.Interface;

namespace Ugroop.API.Mongo.Controllers {

    [UserSessionFilter]
    public class SecurityController : BaseController {

        public SecurityController(IAccountService accountService) : base(accountService) { }

    }

}
