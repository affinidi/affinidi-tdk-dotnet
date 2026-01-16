using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;
using Newtonsoft.Json.Linq;
using Xunit;

namespace IntegrationTests.Helpers
{
    public static class VerificationHelper
    {
        public static async Task<bool> IsValidV2(object? ldpVc = null, string? jwtVc = null)
        {
            var input = new VerifyCredentialV2Input();

            if (ldpVc != null)
            {
                var dict = JObject.FromObject(ldpVc).ToObject<Dictionary<string, object>>()!;
                input.LdpVcs = new List<Dictionary<string, object>> { dict };
            }

            if (jwtVc != null)
            {
                input.JwtVcs = new List<string> { jwtVc };
            }

            var api = GetVerificationApi();
            var result = await api.VerifyCredentialsV2Async(input);

            Assert.NotNull(result);
            return result.IsValid;
        }

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
