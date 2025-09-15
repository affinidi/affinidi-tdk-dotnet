using Xunit;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests
{
    public class LoginConfigurationClientTests
    {
        [Fact]
        public async Task ListWallets()
        {
            string token = await AuthHelper.Instance.GetProjectScopedToken();

            Configuration config = new Configuration();
            config.ApiKey.Add("authorization", token);

            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            var configurationApi = new ConfigurationApi(httpClient, config, httpClientHandler);

            ListLoginConfigurationOutput result = await configurationApi.ListLoginConfigurationsAsync();

            Assert.NotNull(result);
            Assert.IsType<ListLoginConfigurationOutput>(result);
            // Assert.Empty(result.Configurations); // for 0 items
        }
    }
}
