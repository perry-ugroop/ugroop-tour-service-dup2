using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ugroop.API.Mongo.Controllers;
using Ugroop.API.Mongo.Helper.Json;
using UGroopData.Mongo.Service.UGroopWeb.Interface;

namespace Ugroop.API.Mongo.Helper.Filter {
    public class UserSessionFilter : ActionFilterAttribute {

        private string UserSessionKey;
        private IAccountService _accountService;

        public override void OnActionExecuting(HttpActionContext actionContext) {
            UserSessionKey = string.Empty;
            if (actionContext.ActionArguments.ContainsKey("UserSessionKey")) {
                UserSessionKey = actionContext.ActionArguments["UserSessionKey"].ToString();
            }
            if (actionContext.ActionArguments.ContainsKey("jsonData")) {
                var jsonData = (JObject)actionContext.ActionArguments["jsonData"];
                if (jsonData != null) {
                    UserSessionKey = JsonData.Instance(jsonData).Get_JsonObject("UserSessionKey").ToString();
                }
            }

            var baseController = ((BaseController)actionContext.ControllerContext.Controller);
            _accountService = baseController.AccountService;

            var result = !string.IsNullOrEmpty(UserSessionKey) ? _accountService.Validate_UserSession(UserSessionKey) : true;
            if (result == false) {
                var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User Session.");
                actionContext.Response = response;
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
                base.OnActionExecuting(actionContext);
        }

    }
}