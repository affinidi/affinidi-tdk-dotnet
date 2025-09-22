using System;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;
using IntegrationTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests.Fixtures
{
    public class WalletsApiFixture : IAsyncLifetime
    {
        public WalletApi WalletApi { get; private set; }
        public RevocationApi RevocationApi { get; private set; }

        public SignCredentialResultDto? SignedCredential { get; set; }
        public string? WalletId { get; set; }
        public string? WalletDid { get; set; }
        public string? WalletIdDidWeb { get; set; }

        public WalletsApiFixture()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;
            Configuration config = new Configuration();

            WalletApi = new WalletApi(httpClient, config);
            RevocationApi = new RevocationApi(httpClient, config);
        }

        // Runs BEFORE any tests (init shared resources)
        public async Task InitializeAsync()
        {
            var createWalletResult = await WalletsHelper.CreateWallet();

            WalletId = createWalletResult.Wallet.Id;
            WalletDid = createWalletResult.Wallet.Did;
        }

        // Runs AFTER all tests are done (clean up)
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
