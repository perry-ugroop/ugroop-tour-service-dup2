using Microsoft.Owin;
using Owin;
using Stormpath.AspNet;
using Stormpath.Configuration.Abstractions;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Ugroop.API.SQL.App_Start;

[assembly: OwinStartup(typeof(Ugroop.API.SQL.Startup))]
namespace Ugroop.API.SQL {
    public class Startup {

        public void Configuration(IAppBuilder app) {

            #region CORS Configuration                  .

            //// CORS config
            //var corsPolicy = new CorsPolicy {
            //    AllowAnyMethod = true,
            //    AllowAnyHeader = true,
            //    AllowAnyOrigin = true,
            //    SupportsCredentials = true
            //};

            ////corsPolicy.Origins.Add("http://localhost:46055"); // Your API domain

            //var corsOptions = new CorsOptions {
            //    PolicyProvider = new CorsPolicyProvider {
            //        PolicyResolver = context => Task.FromResult(corsPolicy)
            //    }
            //};
            //app.UseCors(corsOptions);

            #endregion

            StormpathConfig.Initialize();

            #region StormPath Configuration                        .

            app.UseStormpath(new StormpathConfiguration {
                Application = new ApplicationConfiguration {
                    Href = StormpathConfig.Client.Configuration.Application.Href
                },
                Client = new ClientConfiguration {
                    ApiKey = new ClientApiKeyConfiguration {
                        Id = StormpathConfig.Client.Configuration.Client.ApiKey.Id,
                        Secret = StormpathConfig.Client.Configuration.Client.ApiKey.Secret,
                    }
                },
                //StormPath Login -> NOTE : Comment this code on Production
                Web = new WebConfiguration {
                    Login = new WebLoginRouteConfiguration {
                        Form = new WebLoginRouteFormConfiguration {
                            Fields = new Dictionary<string, WebFieldConfiguration> {
                                ["login"] = new WebFieldConfiguration {
                                    Label = "Email",
                                    Placeholder = "you@yourdomain.com"
                                },
                                ["password"] = new WebFieldConfiguration {
                                    Placeholder = "Tip: Use a strong password!"
                                }
                            }
                        }
                    }
                }
                //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            });

            #endregion

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityConfig.RegisterComponents();
            UnityConfig.Register(GlobalConfiguration.Configuration);
            log4net.Config.XmlConfigurator.Configure();
        }

    }
}
