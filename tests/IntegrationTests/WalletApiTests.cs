using Xunit;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests
{
    public class WalletApiTests
    {
        [Fact]
        public async Task ListWallets()
        {
            string token = await AuthHelper.Instance.GetProjectScopedToken();

            Configuration config = new Configuration();
            config.ApiKey.Add("authorization", token);

            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            var walletApi = new WalletApi(httpClient, config, httpClientHandler);

            WalletsListDto wallets = await walletApi.ListWalletsAsync();

            Assert.NotNull(wallets);
            Assert.IsType<WalletsListDto>(wallets);
        }
    }
}
