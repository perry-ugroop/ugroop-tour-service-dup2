using Microsoft.Practices.Unity;
using System.Web.Http;
using UGroopData.Mongo.Service.UGroopWeb.Concrete;
using UGroopData.Mongo.Service.UGroopWeb.Interface;
using Unity.WebApi;

namespace Ugroop.API {
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IReferenceService, ReferenceService>();
            container.RegisterType<ISettingService, SettingService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}