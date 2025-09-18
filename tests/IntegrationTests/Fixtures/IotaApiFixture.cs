using Xunit;
using Xunit.Abstractions;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using AffinidiTdk.IotaClient.Api;
using AffinidiTdk.IotaClient.Client;
using AffinidiTdk.IotaClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests.Fixtures
{
    public class IotaApiFixture : IAsyncLifetime
    {
        public CallbackApi CallbackApi { get; private set; }
        public ConfigurationsApi ConfigurationsApi { get; private set; }
        public IotaApi IotaApi { get; private set; }
        public PexQueryApi PexQueryApi { get; private set; }

        public string WalletId { get; set; }
        public string WalletAri { get; set; }
        public string ConfigurationId { get; set; }
        public string IotaRedirectUri { get; set; }
        public string QueryId { get; set; }

        public IotaApiFixture()
        {
            HttpClient simpleHttpClient = new HttpClient();
            HttpClient httpClient = AuthHelper.Instance.HttpClient;
            Configuration config = new Configuration();

            CallbackApi = new CallbackApi(simpleHttpClient, config);
            ConfigurationsApi = new ConfigurationsApi(httpClient, config);
            IotaApi = new IotaApi(httpClient, config);
            PexQueryApi = new PexQueryApi(httpClient, config);
        }

        // Runs BEFORE any tests (init shared resources)
        public async Task InitializeAsync()
        {
            var createWalletResult = await WalletsHelper.CreateWallet();

            WalletId = createWalletResult.Wallet.Id;
            WalletAri = createWalletResult.Wallet.Ari;

            var iotaConfigurationString = EnvHelper.IotaConfiguration;
            CreateIotaConfigurationInput iotaConfiguration = JsonConvert.DeserializeObject<CreateIotaConfigurationInput>(iotaConfigurationString);

            iotaConfiguration.WalletAri = WalletAri;

            IotaConfigurationDto createIotaConfigurationResult = await ConfigurationsApi.CreateIotaConfigurationAsync(iotaConfiguration);
            ConfigurationId = createIotaConfigurationResult.ConfigurationId.ToString();
            IotaRedirectUri = createIotaConfigurationResult.RedirectUris[0].ToString();

            var presentationDefinitionString = EnvHelper.IotaPresentationDefinition;

            var createPexQueryInput = new CreatePexQueryInput("TestQuery", presentationDefinitionString);

            PexQueryDto createPexQueryResult = await PexQueryApi.CreatePexQueryAsync(ConfigurationId, createPexQueryInput);

            QueryId = createPexQueryResult.QueryId;
        }

        // Runs AFTER all tests are done (clean up)
        public async Task DisposeAsync()
        {
            await WalletsHelper.DeleteWallet(WalletId);
            await PexQueryApi.DeletePexQueryByIdAsync(ConfigurationId, QueryId);
            await ConfigurationsApi.DeleteIotaConfigurationByIdAsync(ConfigurationId);
        }
    }
}
