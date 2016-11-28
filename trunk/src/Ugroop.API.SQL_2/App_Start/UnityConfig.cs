using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Web.Http;
using Ugroop.API.SQL.ExceptionHandler;
using UGroopData.Sql.Repository2.Base;
using UGroopData.Sql.Repository2.Data;
using UGroopData.Sql.Service.UGroopWeb.Concrete;
using UGroopData.Sql.Service.UGroopWeb.Interface;
using UGroopData.Sql.Service2.UGroopWeb.Validation;
using UGroopData.Validation.Base;
using Unity.WebApi;

namespace Ugroop.API.SQL {
    public static class UnityConfig {
        public static void RegisterComponents() {
            var container = new UnityContainer();

            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IReferenceService, ReferenceService>();
            container.RegisterType<ISettingService, SettingService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ISysAccessService, SysAccessService>();
            container.RegisterType<ITourService, TourService>();

            //Validators
            container.RegisterInstance(typeof(IValidationProvider), new ValidationProvider(type => (IValidator)container.Resolve(typeof(Validator<>).MakeGenericType(type))));
            container.RegisterType(typeof(Validator<>), typeof(NullValidator<>));
            container.RegisterType<Validator<Tour>, TourValidator>();

            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>), new TransientLifetimeManager());
            //container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>), new HierarchicalLifetimeManager());

            // Interception
            container.AddNewExtension<Interception>();
            container.RegisterType<ITourService, TourService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LogInterceptionBehavior>());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

    }

}