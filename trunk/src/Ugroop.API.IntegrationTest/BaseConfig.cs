﻿using System.Configuration;
using Stormpath.SDK.Client;
using Stormpath.SDK.Oauth;
using System.Threading.Tasks;
using Stormpath.SDK.Application;
using Stormpath.SDK.Http;
using Stormpath.SDK.Serialization;
using Stormpath.SDK.Sync;

namespace Ugroop.API.IntegrationTest {

    public static class TokenHandler {
        public static string AccessToken { get; set; }

        public static async Task<bool> ValidateAccessToken() {
            try {
                var app = StormpathConfig.Application;
                string access_token = AccessToken;

                var validationRequest = OauthRequests.NewJwtAuthenticationRequest()
                    .SetJwt(access_token)
                    .Build();

                var accessToken = await app.NewJwtAuthenticator()
                        .AuthenticateAsync(validationRequest);
                return true;
            }
            catch { return false; }
        }
    }

    public static class StormpathConfig {
        // Replace this with your Stormpath Application href (found in the Stormpath Admin Console)
        //public static readonly string ApplicationHref = "https://api.stormpath.com/v1/applications/3fHcLh5P6R2JYq2ExmHUiz";
        public static readonly string ApplicationHref = ConfigurationManager.AppSettings["ApplicationHref"].ToString();
        private static readonly string SetApiKeyId = ConfigurationManager.AppSettings["SetApiKeyId"].ToString();
        private static readonly string SetApiKeySecret = ConfigurationManager.AppSettings["SetApiKeySecret"].ToString();

        // This static object will allow us to use the Stormpath client object elsewhere in the application
        public static IClient Client { get; private set; }
        public static IApplication Application { get; private set; }

        public static void Initialize() {
            if (Application == null) {
                // Build the IClient object and make it available on StormpathConfig.Client.
                var clientBuilder = Clients.Builder()
                    .SetApiKeyId(SetApiKeyId)
                    .SetApiKeySecret(SetApiKeySecret)
                    //.SetApiKeyId("ME2ZQOJMA57VSDD8XPW1Q7B1X")
                    //.SetApiKeySecret("+ikOs9ltXgwKTnWXb1e28J7a/5A/VdbqU0qS9NCzXa8")
                    .SetHttpClient(HttpClients.Create().RestSharpClient())
                    .SetSerializer(Serializers.Create().JsonNetSerializer()
                    );
                Client = clientBuilder.Build();
                Application = Client.GetApplication(ApplicationHref); // Prime the cache
            }
        }
    }

}
