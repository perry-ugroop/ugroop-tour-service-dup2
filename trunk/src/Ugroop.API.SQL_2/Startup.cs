using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Stormpath.AspNet;
using Stormpath.Configuration.Abstractions;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Ugroop.API.SQL;

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

            // IClient config
            app.UseStormpath(new StormpathConfiguration {
                Application = new ApplicationConfiguration {
                    Href = "https://api.stormpath.com/v1/applications/3fHcLh5P6R2JYq2ExmHUiz"
                },
                Client = new ClientConfiguration {
                    ApiKey = new ClientApiKeyConfiguration {
                        Id = "2D8LSSZDDIRHGSFW2B6U9MJ5D",
                        Secret = "smPaqk+n4V4Rvsf5XJ2hfFTNREILLLPEVy23hNXemJw"
                    }
                }
            });

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityConfig.RegisterComponents();
            log4net.Config.XmlConfigurator.Configure();
        }

    }
}
