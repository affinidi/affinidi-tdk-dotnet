using Xunit;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests
{
    public class CredentialIssuanceClientTests
    {
        [Fact]
        public async Task ListConfigurations()
        {
            string token = await AuthHelper.Instance.GetProjectScopedToken();

            Configuration config = new Configuration();
            config.ApiKey.Add("authorization", token);

            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            var apiInstance = new ConfigurationApi(httpClient, config, httpClientHandler);

            IssuanceConfigListResponse result = apiInstance.GetIssuanceConfigList();

            Assert.NotNull(result);
            Assert.IsType<IssuanceConfigListResponse>(result);

            // Assert.Single(result.Configurations); // for 1 item
            // Assert.NotEmpty(result); // for 1 or more items
        }
    }
}
