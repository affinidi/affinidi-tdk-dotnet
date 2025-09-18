using Xunit;
using Xunit.Abstractions;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests.Fixtures
{
    public class CredentialIssuanceApiFixture : IAsyncLifetime
    {
        public ConfigurationApi ConfigurationApi { get; private set; }
        public IssuanceApi IssuanceApi { get; private set; }
        public OfferApi OfferApi { get; private set; }
        public CredentialsApi CredentialsApi { get; private set; }

        public string ConfigurationId { get; private set; }

        public CredentialIssuanceApiFixture()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;
            Configuration config = new Configuration();

            ConfigurationApi = new ConfigurationApi(httpClient, config);
            IssuanceApi = new IssuanceApi(httpClient, config);
            OfferApi = new OfferApi(httpClient, config);
            CredentialsApi = new CredentialsApi(httpClient, config);
        }

        // Runs BEFORE any tests (init shared resources)
        public async Task InitializeAsync()
        {
            IssuanceConfigListResponse configs = await ConfigurationApi.GetIssuanceConfigListAsync();

            if (configs?.Configurations != null && configs.Configurations.Count > 0)
            {
                ConfigurationId = configs.Configurations[0].Id;
            }
            else
            {
                var wallet = await WalletsHelper.CreateWallet();

                var issuanceConfigurationString = EnvHelper.CredentialIssuanceConfiguration;
                CreateIssuanceConfigInput issuanceConfig = JsonConvert.DeserializeObject<CreateIssuanceConfigInput>(issuanceConfigurationString);
                issuanceConfig.IssuerWalletId = wallet.Wallet.Id;

                var createResult = await ConfigurationApi.CreateIssuanceConfigAsync(issuanceConfig);
                ConfigurationId = createResult.Id;
            }

        }

        // Runs AFTER all tests are done (clean up)
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
