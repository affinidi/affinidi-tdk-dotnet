using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AffinidiTdk.IotaClient.Api;
using AffinidiTdk.IotaClient.Client;
using AffinidiTdk.IotaClient.Model;
using IntegrationTests.Helpers;
using Xunit;

namespace IntegrationTests
{
    public class IotaClientTests
    {
        [Fact]
        public async Task ListWallets()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var apiInstance = new ConfigurationsApi(httpClient, config);

            ListConfigurationOK result = await apiInstance.ListIotaConfigurationsAsync();

            Assert.NotNull(result);
            Assert.IsType<ListConfigurationOK>(result);

            // Assert.Empty(result.Configurations); // for 0 items
            // Assert.Single(result); // for 1 item
            // Assert.NotEmpty(result.Configurations); // for 1 or more items
        }
    }
}
