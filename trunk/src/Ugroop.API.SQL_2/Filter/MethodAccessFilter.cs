using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ugroop.API.SQL_2.Helper;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Filter {


    public class MethodAccessFilter : ActionFilterAttribute {

        [Dependency]
        public ISysAccessService _sysAccessService { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext) {

            string methodName = actionContext.ActionDescriptor.ActionName;
            string controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            int roleId = Identity.RoleId();

            var hasMethodCallAccess = _sysAccessService.Check_RoleMethodAccess(roleId, controllerName, methodName);

            base.OnActionExecuting(actionContext);

        }
    }

    public class UnityFilterProvider : IFilterProvider {
        private IUnityContainer _container;
        private readonly ActionDescriptorFilterProvider _defaultProvider = new ActionDescriptorFilterProvider();

        public UnityFilterProvider(IUnityContainer container) {
            _container = container;
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor) {
            var attributes = _defaultProvider.GetFilters(configuration, actionDescriptor);

            foreach (var attr in attributes) {
                _container.BuildUp(attr.Instance.GetType(), attr.Instance);
            }
            return attributes;
        }
    }

}