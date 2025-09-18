using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;
using Xunit;
using Xunit;

namespace IntegrationTests.Helpers
{
    public static class VerificationHelper
    {
        public static async Task<bool> IsValid(object vc)
        {
            var input = new VerifyCredentialInput([vc]);

            var api = GetVerificationApi();
            var result = await api.VerifyCredentialsAsync(input);

            Assert.NotNull(result);
            return result.IsValid;
        }

        private static DefaultApi GetVerificationApi()
        {
            var httpClient = AuthHelper.Instance.HttpClient;
            var config = new Configuration();
            return new DefaultApi(httpClient, config);
        }
    }
}
