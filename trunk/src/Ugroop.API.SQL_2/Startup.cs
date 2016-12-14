using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Ugroop.API.SQL.App_Start;

[assembly: OwinStartup(typeof(Ugroop.API.SQL.Startup))]

namespace Ugroop.API.SQL {
    public class Startup {

        public void Configuration(IAppBuilder app) {

            // CORS config
            var corsPolicy = new CorsPolicy {
                AllowAnyMethod = false,
                AllowAnyHeader = false,
                AllowAnyOrigin = false,
                SupportsCredentials = true
            };

            //corsPolicy.Origins.Add("http://localhost:46055"); // Your API domain

            var corsOptions = new CorsOptions {
                PolicyProvider = new CorsPolicyProvider {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };
            app.UseCors(corsOptions);
            StormpathConfig.Initialize();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityConfig.RegisterComponents();
            UnityConfig.Register(GlobalConfiguration.Configuration);
            log4net.Config.XmlConfigurator.Configure();
        }

    }
}
