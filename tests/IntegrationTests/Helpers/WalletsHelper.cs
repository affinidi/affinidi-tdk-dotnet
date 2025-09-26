using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;
using Xunit;

namespace IntegrationTests.Helpers
{
    public static class WalletsHelper
    {
        private const int WalletsLimitThreshold = 7;
        private const int WalletsHardLimit = 10;

        public static async Task<CreateWalletResponse> CreateWallet(bool didWeb = false)
        {
            await EnsureWalletLimitNotExceeded();

            var api = GetWalletApi();

            var input = didWeb
                ? new CreateWalletInput
                {
                    DidMethod = CreateWalletInput.DidMethodEnum.Web,
                    DidWebUrl = $"{Utils.GenerateRandomString()}.com"
                }
                : new CreateWalletInput();

            var response = await api.CreateWalletAsync(input);

            Assert.NotNull(response);
            return response;
        }

        public static async Task DeleteWallet(string walletId)
        {
            var api = GetWalletApi();
            var result = await api.DeleteWalletWithHttpInfoAsync(walletId);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        public static string? ExtractRevocationStatusId(string url)
        {
            try
            {
                var uri = new Uri(url);
                var segments = uri.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
                return segments.Length > 0 ? segments[^1] : null;
            }
            catch (UriFormatException)
            {
                return null;
            }
        }

        private static async Task EnsureWalletLimitNotExceeded()
        {
            var api = GetWalletApi();
            var result = await api.ListWalletsAsync();

            if (result.Wallets.Count >= WalletsLimitThreshold)
            {
                Console.WriteLine($"❗️Number of wallets reaching the limit ({WalletsHardLimit}). Deleting all wallets.");

                foreach (var wallet in result.Wallets)
                {
                    await api.DeleteWalletAsync(wallet.Id);
                }
            }
        }

        private static WalletApi GetWalletApi()
        {
            var httpClient = AuthHelper.Instance.HttpClient;
            var config = new Configuration();
            return new WalletApi(httpClient, config);
        }
    }
}
