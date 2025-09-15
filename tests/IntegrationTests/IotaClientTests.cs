using Xunit;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AffinidiTdk.IotaClient.Api;
using AffinidiTdk.IotaClient.Client;
using AffinidiTdk.IotaClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests
{
    public class IotaClientTests
    {
        [Fact]
        public async Task ListWallets()
        {
            string token = await AuthHelper.Instance.GetProjectScopedToken();

            Configuration config = new Configuration();
            config.ApiKey.Add("authorization", token);

            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            var apiInstance = new ConfigurationsApi(httpClient, config, httpClientHandler);
            ListConfigurationOK result = apiInstance.ListIotaConfigurations();

            Assert.NotNull(result);
            Assert.IsType<ListConfigurationOK>(result);

            // Assert.Empty(result.Configurations); // for 0 items
            // Assert.Single(result); // for 1 item
            // Assert.NotEmpty(result.Configurations); // for 1 or more items
        }
    }
}
