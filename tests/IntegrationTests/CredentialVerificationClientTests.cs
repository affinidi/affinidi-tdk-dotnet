using Xunit;

using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests
{
    public class CredentialVerificationClientTests
    {
        [Fact]
        public async Task VerifyCredentials()
        {
            Env.TraversePath().Load();

            var credential = Environment.GetEnvironmentVariable("VERIFIABLE_CREDENTIAL");
            JObject vc = JObject.Parse(credential);
            VerifyCredentialInput verifyCredentialInput = new VerifyCredentialInput(new List<object> { vc });

            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var apiInstance = new DefaultApi(httpClient, config);

            VerifyCredentialOutput result = await apiInstance.VerifyCredentialsAsync(verifyCredentialInput);

            Assert.NotNull(result);
            Assert.IsType<VerifyCredentialOutput>(result);
            Assert.True(result.IsValid);
        }
    }
}
