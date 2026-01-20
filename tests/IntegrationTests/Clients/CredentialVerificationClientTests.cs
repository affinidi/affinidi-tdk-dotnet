using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.CredentialVerificationClient.Model;
using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;
using Newtonsoft.Json.Linq;
using Xunit;

namespace IntegrationTests
{
    [Collection("CredentialVerificationClientTests")]
    [TestCaseOrderer("IntegrationTests.Helpers.AlphabeticalOrderer", "IntegrationTests")]
    public class CredentialVerificationClientTests
    {
        private readonly CredentialVerificationApiFixture _fixture;

        public CredentialVerificationClientTests(CredentialVerificationApiFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task VerifyCredentials()
        {
            object vc = EnvHelper.VerifiableCredential;
            VerifyCredentialInput verifyCredentialInput = new VerifyCredentialInput(new List<object> { vc });

            VerifyCredentialOutput result = await _fixture.DefaultApi.VerifyCredentialsAsync(verifyCredentialInput);

            Assert.NotNull(result);
            Assert.IsType<VerifyCredentialOutput>(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task VerifyPresentation()
        {
            object vp = JObject.Parse(EnvHelper.VerifiablePresentation);
            VerifyPresentationInput verifyPresentationInput = new VerifyPresentationInput(vp);

            VerifyPresentationOutput result = await _fixture.DefaultApi.VerifyPresentationAsync(verifyPresentationInput);

            Assert.NotNull(result);
            Assert.IsType<VerifyPresentationOutput>(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task VerifyCredentialsV2_LdpFormat()
        {


            var verifyCredentialV2Input = new VerifyCredentialV2Input
            {
                LdpVcs = new List<Dictionary<string, object>> { EnvHelper.VerifiableCredential.ToObject<Dictionary<string, object>>()! }
            };

            VerifyCredentialOutput result = await _fixture.DefaultApi.VerifyCredentialsV2Async(verifyCredentialV2Input);

            Assert.NotNull(result);
            Assert.IsType<VerifyCredentialOutput>(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task VerifyCredentialsV2_JwtFormat()
        {
            var verifyCredentialV2Input = new VerifyCredentialV2Input
            {
                JwtVcs = new List<string> { EnvHelper.JwtCredentialV2 }
            };

            VerifyCredentialOutput result = await _fixture.DefaultApi.VerifyCredentialsV2Async(verifyCredentialV2Input);

            Assert.NotNull(result);
            Assert.IsType<VerifyCredentialOutput>(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task VerifyPresentationV2()
        {
            object vp = JObject.Parse(EnvHelper.VerifiablePresentation);
            var verifyPresentationV2Input = new VerifyPresentationV2Input(vp);

            VerifyPresentationOutput result = await _fixture.DefaultApi.VerifyPresentationV2Async(verifyPresentationV2Input);

            Assert.NotNull(result);
            Assert.IsType<VerifyPresentationOutput>(result);
            Assert.True(result.IsValid);
        }
    }
}
