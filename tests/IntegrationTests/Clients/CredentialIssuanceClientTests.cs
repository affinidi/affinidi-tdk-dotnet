using System;
using System.Net;
using System.Threading.Tasks;
using AffinidiTdk.CredentialIssuanceClient.Model;
using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace IntegrationTests
{
    [Collection("CredentialIssuanceClientTests")]
    [TestCaseOrderer("IntegrationTests.Helpers.AlphabeticalOrderer", "IntegrationTests")]
    public class CredentialIssuanceClientTests
    {
        private readonly CredentialIssuanceApiFixture _fixture;

        public CredentialIssuanceClientTests(CredentialIssuanceApiFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Test_ListConfigurations()
        {
            IssuanceConfigListResponse result = await _fixture.ConfigurationApi.GetIssuanceConfigListAsync();

            Assert.NotNull(result);
            Assert.IsType<IssuanceConfigListResponse>(result);
            Assert.Single(result.Configurations);
        }

        [Fact]
        public async Task Test_UpdateConfiguration()
        {
            string newDescription = Utils.GenerateRandomString();
            var updateIssuanceConfigInput = new UpdateIssuanceConfigInput(
                description: newDescription
            );

            IssuanceConfigDto result = await _fixture.ConfigurationApi.UpdateIssuanceConfigByIdAsync(_fixture.ConfigurationId, updateIssuanceConfigInput);

            Assert.NotNull(result);
            Assert.IsType<IssuanceConfigDto>(result);
            Assert.Equal(newDescription, result.Description);
        }

        [Fact]
        public async Task Test_ReadsConfiguration()
        {
            IssuanceConfigDto result = await _fixture.ConfigurationApi.GetIssuanceConfigByIdAsync(_fixture.ConfigurationId);

            Assert.NotNull(result);
            Assert.IsType<IssuanceConfigDto>(result);
        }

        [Fact]
        public async Task Test_StartIssuance()
        {
            var startIssuanceInput = JsonConvert.DeserializeObject<StartIssuanceInput>(EnvHelper.CredentialIssuanceData);
            startIssuanceInput.ClaimMode = StartIssuanceInput.ClaimModeEnum.TXCODE;

            StartIssuanceResponse startIssuanceResult = await _fixture.IssuanceApi.StartIssuanceAsync(EnvHelper.ProjectId, startIssuanceInput);
            Console.WriteLine(startIssuanceResult);

            Assert.NotNull(startIssuanceResult);
            Assert.IsType<StartIssuanceResponse>(startIssuanceResult);
            Assert.NotEmpty(startIssuanceResult.CredentialOfferUri);
            Assert.NotEmpty(startIssuanceResult.TxCode);

            var issuanceId = startIssuanceResult.IssuanceId.ToString();

            ListIssuanceResponse listIssuanceResult = await _fixture.IssuanceApi.ListIssuanceAsync(EnvHelper.ProjectId);

            Assert.NotNull(listIssuanceResult);
            Assert.IsType<ListIssuanceResponse>(listIssuanceResult);
            Assert.NotNull(listIssuanceResult.Issuances);

            CredentialOfferResponse credentialOfferResponse = await _fixture.OfferApi.GetCredentialOfferAsync(EnvHelper.ProjectId, issuanceId);
            Assert.NotNull(credentialOfferResponse);
            Assert.IsType<CredentialOfferResponse>(credentialOfferResponse);
        }
    }
}
