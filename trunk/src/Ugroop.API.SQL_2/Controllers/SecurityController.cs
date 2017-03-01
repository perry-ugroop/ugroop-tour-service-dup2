using System.Web.Http;
using Ugroop.API.SQL.Filter.StormPath;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {

    [StormpathBearerAuthentication]
    [Authorize]
    public class SecurityController : BaseController {

        public SecurityController(ITourService tourService) : base(tourService) { }

    }

}
