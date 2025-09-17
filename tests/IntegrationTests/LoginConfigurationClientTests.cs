using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;
using IntegrationTests.Helpers;
using Xunit;

namespace IntegrationTests
{
    public class LoginConfigurationClientTests
    {
        [Fact]
        public async Task ListWallets()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var configurationApi = new ConfigurationApi(httpClient, config);

            ListLoginConfigurationOutput result = await configurationApi.ListLoginConfigurationsAsync();

            Assert.NotNull(result);
            Assert.IsType<ListLoginConfigurationOutput>(result);
            // Assert.Empty(result.Configurations); // for 0 items
        }
    }
}
