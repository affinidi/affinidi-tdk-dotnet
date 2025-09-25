using AffinidiTdk.Common;
using Xunit;

namespace UnitTests.Packages
{
    public class VaultUtilsTests
    {
        [Fact]
        public void BuildShareLink_ReturnsCorrectUrl()
        {
            string request = "sampleRequest";
            string clientId = "sampleClientId";

            var url = VaultUtils.BuildShareLink(request, clientId);

            Assert.Contains("request=sampleRequest", url);
            Assert.Contains("client_id=sampleClientId", url);
            Assert.Contains("/login?", url);
        }

        [Fact]
        public void BuildClaimLink_ReturnsCorrectUrl()
        {
            string credentialOfferUri = "sampleCredentialOfferUri";

            var url = VaultUtils.BuildClaimLink(credentialOfferUri);

            Assert.Contains("credential_offer_uri=sampleCredentialOfferUri", url);
            Assert.Contains("/claim?", url);
        }
    }
}
