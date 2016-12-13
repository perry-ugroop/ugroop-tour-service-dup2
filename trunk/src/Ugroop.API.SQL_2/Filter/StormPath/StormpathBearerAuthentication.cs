using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Stormpath.SDK.Error;
using Stormpath.SDK.Oauth;
using Stormpath.SDK;
using System.Linq;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using Ugroop.API.SQL.App_Start;
using Ugroop.API.SQL.Filter.StormPath.Results;

namespace Ugroop.API.SQL.Filter.StormPath {


    public class StormpathBearerAuthentication : Attribute, IAuthenticationFilter {

        public string Realm { get; set; }

        public bool AllowMultiple {
            get { return false; }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken) {

            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            var token = authorization.Parameter;

            if (string.IsNullOrEmpty(token)) {
                return;
            }


            // Get the Stormpath application
            var application = await StormpathConfig.Client.GetApplicationAsync(StormpathConfig.ApplicationHref);

            // Build and send a request to the Stormpath API
            var jwtValidationRequest = OauthRequests.NewJwtAuthenticationRequest()
                .SetJwt(token)
                .Build();

            try {
                var validationResult = await application.NewJwtAuthenticator()
                    .AuthenticateAsync(jwtValidationRequest, cancellationToken);

                var accountDetails = await validationResult.GetAccountAsync();

                // get account -> groups
                var accountGroups = await accountDetails
                    .GetGroups()
                    .Expand(g => g.GetCustomData())
                    .ToListAsync();
                var role = accountGroups.First().Name;

                // Build an IPrincipal and return it
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, role));
                claims.Add(new Claim(ClaimTypes.Email, accountDetails.Email));
                claims.Add(new Claim(ClaimTypes.GivenName, accountDetails.GivenName));
                claims.Add(new Claim(ClaimTypes.Surname, accountDetails.Surname));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, accountDetails.Username));
                var identity = new ClaimsIdentity(claims, AuthenticationTypes.Signature);
                context.Principal = new ClaimsPrincipal(identity);
            }
            catch (ResourceException rex) {
                //// use this code to return the specific error code from StormPath API
                //context.ErrorResult = new AuthenticationFailureResult(rex.Message, request);
                return;
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken) {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context) {
            string parameter;

            if (string.IsNullOrEmpty(Realm)) {
                parameter = null;
            }
            else {
                // A correct implementation should verify that Realm does not contain a quote character unless properly
                // escaped (precededed by a backslash that is not itself escaped).
                parameter = "realm=\"" + Realm + "\"";
            }

            context.ChallengeWith("Bearer", parameter);
        }

    }
}