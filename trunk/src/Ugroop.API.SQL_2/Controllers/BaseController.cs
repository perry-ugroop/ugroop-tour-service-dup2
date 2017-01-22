using System.Web.Http;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {

    public class BaseController : ApiController {

        #region Private Properties                  .

        private ITourService _tourService;

        #endregion

        #region Public Properties                   .

        public ITourService TourService {
            get { return _tourService; }
        }

        #endregion

        public BaseController(ITourService tourService) {
            _tourService = tourService;
        }

    }

}
