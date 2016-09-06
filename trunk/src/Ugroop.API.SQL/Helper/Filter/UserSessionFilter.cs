using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ugroop.API.SQL.Controllers;
using Ugroop.API.SQL.Helper.Json;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Helper.Filter {
    public class UserSessionFilter : ActionFilterAttribute {

        private string UserSessionKey;
        private IAccountService _accountService;

        public override void OnActionExecuting(HttpActionContext actionContext) {
            UserSessionKey = string.Empty;

            if (actionContext.ActionArguments.ContainsKey("UserSessionKey")) {
                UserSessionKey = actionContext.ActionArguments["UserSessionKey"].ToString();
            }
            if (actionContext.ActionArguments.ContainsKey("jsonData")) {
                try {
                    var jsonData = (JObject)actionContext.ActionArguments["jsonData"];
                    if (jsonData != null) {
                        UserSessionKey = JsonData.Instance(jsonData).Get_JsonObject("UserSessionKey").ToString();
                    }
                }
                catch {
                    var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, "Missing : UserSessionKey.");
                    actionContext.Response = response;
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