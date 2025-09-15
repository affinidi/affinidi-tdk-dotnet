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

            string token = await AuthHelper.Instance.GetProjectScopedToken();

            Configuration config = new Configuration();
            config.ApiKey.Add("authorization", token);

            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);

            var credential = Environment.GetEnvironmentVariable("VERIFIABLE_CREDENTIAL");
            JObject vc = JObject.Parse(credential);

            VerifyCredentialInput verifyCredentialInput = new VerifyCredentialInput(new List<object> { vc });
            VerifyCredentialOutput result = await apiInstance.VerifyCredentialsAsync(verifyCredentialInput);

            Assert.NotNull(result);
            Assert.IsType<VerifyCredentialOutput>(result);
            Assert.True(result.IsValid);
        }
    }
}
