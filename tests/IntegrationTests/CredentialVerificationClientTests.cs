using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;
using IntegrationTests.Helpers;
using Xunit;

namespace IntegrationTests
{
    public class CredentialVerificationClientTests
    {
        [Fact]
        public async Task VerifyCredentials()
        {
            object vc = EnvHelper.VerifiableCredential;
            VerifyCredentialInput verifyCredentialInput = new VerifyCredentialInput(new List<object> { vc });

            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var apiInstance = new DefaultApi(httpClient, config);

            VerifyCredentialOutput result = await apiInstance.VerifyCredentialsAsync(verifyCredentialInput);

            Assert.NotNull(result);
            Assert.IsType<VerifyCredentialOutput>(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task VerifyPresentation()
        {
            object vp = EnvHelper.VerifiablePresentation;
            VerifyPresentationInput verifyPresentationInput = new VerifyPresentationInput(vp);

            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var apiInstance = new DefaultApi(httpClient, config);

            VerifyPresentationOutput result = await apiInstance.VerifyPresentationAsync(verifyPresentationInput);

            Assert.NotNull(result);
            Assert.IsType<VerifyPresentationOutput>(result);
            Assert.True(result.IsValid);
        }
    }
}
