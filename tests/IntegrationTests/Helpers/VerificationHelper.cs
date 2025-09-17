using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;
using Xunit;

namespace IntegrationTests.Helpers
{
    public class VerificationHelper
    {
        public static async Task<bool> IsValid(object vc)
        {
            VerifyCredentialInput verifyCredentialInput = new VerifyCredentialInput(new List<object> { vc });

            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var apiInstance = new DefaultApi(httpClient, config);

            VerifyCredentialOutput result = await apiInstance.VerifyCredentialsAsync(verifyCredentialInput);

            Assert.NotNull(result);
            Assert.IsType<VerifyCredentialOutput>(result);

            return result.IsValid;
        }
    }
}
