using Microsoft.Practices.Unity;
using System.Web.Http;
using UGroopData.PostgreSql.Service.UGroopWeb.Concrete;
using UGroopData.PostgreSql.Service.UGroopWeb.Interface;
using Unity.WebApi;

namespace Ugroop.API.PostgreSQL {
    public static class UnityConfig {
        public static void RegisterComponents() {
            var container = new UnityContainer();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IReferenceService, ReferenceService>();
            container.RegisterType<ISettingService, SettingService>();
            container.RegisterType<IUserService, UserService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
   
}