using Stormpath.SDK.Client;
using Stormpath.SDK.Http;
using Stormpath.SDK.Serialization;
using Stormpath.SDK.Sync;

namespace Ugroop.API.SQL.App_Start {

    public static class StormpathConfig {
        // Replace this with your Stormpath Application href (found in the Stormpath Admin Console)
        public static readonly string ApplicationHref = "https://api.stormpath.com/v1/applications/3fHcLh5P6R2JYq2ExmHUiz";

        // This static object will allow us to use the Stormpath client object elsewhere in the application
        public static IClient Client { get; private set; }

        public static void Initialize() {
            // Build the IClient object and make it available on StormpathConfig.Client.
            var clientBuilder = Clients.Builder()
                .SetApiKeyId("ME2ZQOJMA57VSDD8XPW1Q7B1X")
                .SetApiKeySecret("+ikOs9ltXgwKTnWXb1e28J7a/5A/VdbqU0qS9NCzXa8")
                .SetHttpClient(HttpClients.Create().RestSharpClient())
                .SetSerializer(Serializers.Create().JsonNetSerializer()
                );
            Client = clientBuilder.Build();
            Client.GetApplication(ApplicationHref); // Prime the cache
        }
    }

}