using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.IotaClient.Model;
using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;
using Newtonsoft.Json.Linq;
using Xunit;

namespace IntegrationTests
{
    [Collection("IotaClientTests")]
    [TestCaseOrderer("IntegrationTests.Helpers.AlphabeticalOrderer", "IntegrationTests")]
    public class IotaClientTests
    {
        private readonly IotaApiFixture _fixture;

        public IotaClientTests(IotaApiFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Test_ListConfigurations()
        {
            ListConfigurationOK result = await _fixture.ConfigurationsApi.ListIotaConfigurationsAsync();

            Assert.NotNull(result);
            Assert.IsType<ListConfigurationOK>(result);
            Assert.NotEmpty(result.Configurations);
        }

        [Fact]
        public async Task Test_GetIotaConfiguration()
        {
            IotaConfigurationDto result = _fixture.ConfigurationsApi.GetIotaConfigurationById(_fixture.ConfigurationId);

            Assert.NotNull(result);
            Assert.IsType<IotaConfigurationDto>(result);
        }

        [Fact]
        public async Task Test_UpdateIotaConfiguration()
        {
            string newName = "UpdatedName";

            var updateConfigurationByIdInput = new UpdateConfigurationByIdInput(
                name: newName
            );
            IotaConfigurationDto result = _fixture.ConfigurationsApi.UpdateIotaConfigurationById(_fixture.ConfigurationId, updateConfigurationByIdInput);

            Assert.NotNull(result);
            Assert.IsType<IotaConfigurationDto>(result);
            Assert.Equal(newName, result.Name);
        }

        [Fact]
        public async Task Test_IotaRedirectFlow()
        {
            InitiateDataSharingRequestInput initiateDataSharingRequestInput = new InitiateDataSharingRequestInput
            (
                queryId: _fixture.QueryId,
                correlationId: Guid.NewGuid().ToString(),
                nonce: Guid.NewGuid().ToString().Substring(0, 10),
                redirectUri: _fixture.IotaRedirectUri,
                configurationId: _fixture.ConfigurationId,
                mode: InitiateDataSharingRequestInput.ModeEnum.Redirect
            );

            InitiateDataSharingRequestOK dataSharingRequest = await _fixture.IotaApi.InitiateDataSharingRequestAsync(initiateDataSharingRequestInput);

            string jwt = dataSharingRequest.Data.Jwt;
            string correlationId = dataSharingRequest.Data.CorrelationId;
            string transactionId = dataSharingRequest.Data.TransactionId;

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            var state = token.Payload["state"]?.ToString();

            var callbackInput = new CallbackInput(
                state: state,
                presentationSubmission: EnvHelper.IotaPresentationSubmission,
                vpToken: EnvHelper.VerifiablePresentation
            );
            CallbackResponseOK callbackResult = await _fixture.CallbackApi.IotOIDC4VPCallbackAsync(callbackInput);

            string responseCode = callbackResult.ResponseCode;

            var fetchIOTAVPResponseInput = new FetchIOTAVPResponseInput(
                correlationId: correlationId,
                transactionId: transactionId,
                responseCode: responseCode,
                configurationId: _fixture.ConfigurationId
            );

            FetchIOTAVPResponseOK iotaResponse = await _fixture.IotaApi.FetchIotaVpResponseAsync(fetchIOTAVPResponseInput);

            var vpToken = JObject.Parse(iotaResponse.VpToken);

            Assert.NotNull(vpToken["verifiableCredential"]);
            Assert.Single(vpToken["verifiableCredential"]);
        }
    }
}
