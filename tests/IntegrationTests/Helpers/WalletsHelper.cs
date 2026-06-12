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


        public static async Task<CreateWalletV2Response> CreateWalletV2(bool didWeb = false)
        {
            var api = GetWalletApi();

            var input = didWeb
                ? new CreateWalletV2Input
                {
                    DidMethod = CreateWalletV2Input.DidMethodEnum.Web,
                    DidWebUrl = $"https://{Utils.GenerateRandomString()}.com"
                }
                : new CreateWalletV2Input();

            var response = await api.CreateWalletV2Async(input);

            Assert.NotNull(response);
            return response;
        }

        public static async Task DeleteWallet(string walletId)
        {
            var api = GetWalletApi();
            var result = await api.DeleteWalletWithHttpInfoAsync(walletId);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        public static async Task<WalletDto> GetWalletById(string walletId)
        {
            if (string.IsNullOrWhiteSpace(walletId))
            {
                throw new ArgumentException("Wallet ID cannot be null or empty", nameof(walletId));
            }
            
            var api = GetWalletApi();
            return await api.GetWalletAsync(walletId);
        }

        public static async Task EnsureConfigWalletExists(string configurationId)
        {
            var httpClient = AuthHelper.Instance.HttpClient;
            var cisConfig = new AffinidiTdk.CredentialIssuanceClient.Client.Configuration();
            var cisConfigApi = new AffinidiTdk.CredentialIssuanceClient.Api.ConfigurationApi(httpClient, cisConfig);
            
            var config = await cisConfigApi.GetIssuanceConfigByIdAsync(configurationId);
            string? issuerWalletId = config.IssuerWalletId;
            
            if (!string.IsNullOrWhiteSpace(issuerWalletId))
            {
                try
                {
                    await GetWalletById(issuerWalletId);
                }
                catch (AffinidiTdk.WalletsClient.Client.ApiException ex) when (ex.ErrorCode == 404)
                {
                    var newWallet = await CreateWallet();
                    var updateInput = new AffinidiTdk.CredentialIssuanceClient.Model.UpdateIssuanceConfigInput(issuerWalletId: newWallet.Wallet.Id);
                    await cisConfigApi.UpdateIssuanceConfigByIdAsync(configurationId, updateInput);
                }
            }
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

                // Get protected wallet ID from issuance configuration
                string? protectedWalletId = null;
                try
                {
                    var httpClient = AuthHelper.Instance.HttpClient;
                    var cisConfig = new AffinidiTdk.CredentialIssuanceClient.Client.Configuration();
                    var cisConfigApi = new AffinidiTdk.CredentialIssuanceClient.Api.ConfigurationApi(httpClient, cisConfig);
                    var configList = await cisConfigApi.GetIssuanceConfigListAsync();
                    
                    if (configList?.Configurations != null && configList.Configurations.Count > 0)
                    {
                        protectedWalletId = configList.Configurations[0].IssuerWalletId;
                    }
                }
                catch
                {
                    // Proceed without protection if config unavailable
                }

                foreach (var wallet in result.Wallets)
                {
                    // Skip deleting the wallet used by the issuance configuration
                    if (wallet.Id != protectedWalletId)
                    {
                        await api.DeleteWalletAsync(wallet.Id);
                    }
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
