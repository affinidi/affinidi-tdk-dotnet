using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;
using IntegrationTests.Helpers;
using Xunit;

namespace IntegrationTests
{
    public class WalletsClientTests
    {
        [Fact]
        public async Task ListWallets()
        {
            // create
            var result = await WalletsHelper.CreateWallet(true);
            string walletId = result.Wallet.Id;
            // delete
            await WalletsHelper.DeleteWallet(walletId);

            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var walletApi = new WalletApi(httpClient, config);

            WalletsListDto wallets = await walletApi.ListWalletsAsync();

            Assert.NotNull(wallets);
            Assert.IsType<WalletsListDto>(wallets);
        }
    }
}
