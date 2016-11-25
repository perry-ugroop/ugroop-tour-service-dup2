using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ugroop.API.SQL {
    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
