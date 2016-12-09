using System.Web.Http.Filters;
using Ugroop.API.SQL.ExceptionHandler;
using UGroopData.Utilities.String;

namespace Ugroop.API.SQL.Filter {

    public class ApiExceptionFilter : ExceptionFilterAttribute {
        public override void OnException(HttpActionExecutedContext actionExecutedContext) {
            //Type realReturnType = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType;
            //var realReturnTypeX = actionExecutedContext.ActionContext.ControllerContext;
            if (actionExecutedContext.Exception != null) {
                ExceptionManagerSinglton.Instance.exceptionManager().Process(() => { throw actionExecutedContext.Exception; }
                                                            , AppSettingsConstant.LogReThrowExceptionPolicy);
            }
            base.OnException(actionExecutedContext);
        }
    }


}