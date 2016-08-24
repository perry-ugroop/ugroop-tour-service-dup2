using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using UGroopData.Sql.Service.UGroopWeb.Concrete;
using UGroopData.Sql.Service.UGroopWeb.Interface;
using Unity.WebApi;
using System.Net.Http;
using System.Web.Mvc;

namespace Ugroop.API.SQL {
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