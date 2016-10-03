using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Ugroop.API.SQL.Helper.Filter {

    public class ApiExceptionFilter : ExceptionFilterAttribute {
        public override void OnException(HttpActionExecutedContext actionExecutedContext) {
            //Type realReturnType = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType;
            //var realReturnTypeX = actionExecutedContext.ActionContext.ControllerContext;

            if (actionExecutedContext.Exception != null) {
                var exName = actionExecutedContext.Exception.GetBaseException().GetType().Name;
                var exDetails = actionExecutedContext.Exception.GetBaseException().InnerException.Message;

                actionExecutedContext.Response = new HttpResponseMessage() {
                    //Content = new StringContent(actionExecutedContext.Exception.GetBaseException().InnerException.Message, System.Text.Encoding.UTF8, "text/plain")
                    Content = new StringContent(exName + " || " + exDetails, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
            base.OnException(actionExecutedContext);
        }
    }

}