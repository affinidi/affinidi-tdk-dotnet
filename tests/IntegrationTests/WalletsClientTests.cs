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
    public class WalletsClientTests
    {
        [Fact]
        public async Task ListWallets()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var walletApi = new WalletApi(httpClient, config);

            WalletsListDto wallets = await walletApi.ListWalletsAsync();

            Assert.NotNull(wallets);
            Assert.IsType<WalletsListDto>(wallets);
        }
    }
}
