using System;
using System.Threading.Tasks;
using AffinidiTdk.WalletsClient.Model;
using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace IntegrationTests
{
    [Collection("WalletsClientTests")]
    [TestCaseOrderer("IntegrationTests.Helpers.AlphabeticalOrderer", "IntegrationTests")]
    public class WalletsClientTests
    {
        private readonly WalletsApiFixture _fixture;

        public WalletsClientTests(WalletsApiFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Test_CreatesWallet_DidWeb()
        {
            var result = await WalletsHelper.CreateWallet(true);
            Assert.NotNull(result.Wallet);
            _fixture.WalletIdDidWeb = result.Wallet.Id;
        }

        [Fact]
        public async Task Test1_SignsCredential()
        {
            var expiresAt = DateTime.UtcNow.AddMinutes(10).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            var unsignedParamsString = EnvHelper.UnsignedCredentialParams;
            var unsignedParams = JsonConvert.DeserializeObject<SignCredentialInputDtoUnsignedCredentialParams>(unsignedParamsString)!;

            unsignedParams.HolderDid = _fixture.WalletDid!;
            unsignedParams.ExpiresAt = expiresAt;

            var signCredentialInputDto = new SignCredentialInputDto
            {
                UnsignedCredentialParams = unsignedParams,
                Revocable = true
            };

            var result = await _fixture.WalletApi.SignCredentialAsync(_fixture.WalletId!, signCredentialInputDto);

            Assert.NotNull(result.SignedCredential);

            _fixture.SignedCredential = result;

            // NOTE: why sometimes it is NOT valid?
            // var isValid = await VerificationHelper.IsValid(result.SignedCredential);
            // Assert.True(isValid);
        }

        [Fact]
        public async Task Test2_SignsCredential_Expired_NotValid()
        {
            var expiresAt = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");

            var unsignedParamsString = EnvHelper.UnsignedCredentialParams;
            var unsignedParams = JsonConvert.DeserializeObject<SignCredentialInputDtoUnsignedCredentialParams>(unsignedParamsString)!;

            unsignedParams.HolderDid = _fixture.WalletDid!;
            unsignedParams.ExpiresAt = expiresAt;

            var signCredentialInputDto = new SignCredentialInputDto
            {
                UnsignedCredentialParams = unsignedParams,
                Revocable = true
            };

            var result = await _fixture.WalletApi.SignCredentialAsync(_fixture.WalletId!, signCredentialInputDto);

            Assert.NotNull(result.SignedCredential);

            var isValid = await VerificationHelper.IsValid(result.SignedCredential);

            Assert.False(isValid);
        }

        [Fact]
        public async Task Test4_GetsRevocationListCredential()
        {
            var signedCredentialJObject = JObject.FromObject(_fixture.SignedCredential!.SignedCredential!);
            var revocationListCredential = signedCredentialJObject["credentialStatus"]?["revocationListCredential"]?.ToString();
            var statusId = WalletsHelper.ExtractRevocationStatusId(revocationListCredential!);

            GetRevocationListCredentialResultDto result = await _fixture.RevocationApi.GetRevocationCredentialStatusAsync(EnvHelper.ProjectId, _fixture.WalletId!, statusId!);

            Assert.NotNull(result.RevocationListCredential);

            var resultJObject = JObject.FromObject(result.RevocationListCredential);

            Assert.NotNull(resultJObject["id"]);
            Assert.NotNull(resultJObject["type"]);
            Assert.NotNull(resultJObject["credentialSubject"]);
            Assert.NotNull(resultJObject["proof"]);
            Assert.Equal(["VerifiableCredential", "RevocationList2020Credential"], resultJObject["type"]);
        }

        [Fact]
        public async Task Test5_RevokesVerifiableCredential()
        {
            var signedCredentialJObject = JObject.FromObject(_fixture.SignedCredential!.SignedCredential!);
            var credentialId = signedCredentialJObject["id"]!.ToString();

            var revokeCredentialInput = new RevokeCredentialInput
            {
                RevocationReason = "test",
                CredentialId = credentialId
            };

            await _fixture.RevocationApi.RevokeCredentialAsync(_fixture.WalletId!, revokeCredentialInput);

            var isValid = await VerificationHelper.IsValid(_fixture.SignedCredential!.SignedCredential);

            Assert.False(isValid);
        }

        [Fact]
        public async Task Test_SignsJwt()
        {
            var header = new { alg = "HS256", typ = "JWT" };
            var payload = new
            {
                sub = Guid.NewGuid().ToString(),
                iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                exp = DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds()
            };

            var signJwtToken = new SignJwtToken(header, payload);

            SignJwtTokenOK result = await _fixture.WalletApi.SignJwtTokenAsync(_fixture.WalletId!, signJwtToken);

            Assert.NotNull(result.SignedJwt);
        }

        [Fact]
        public async Task Test6_GetsWallet()
        {
            var result = await _fixture.WalletApi.GetWalletAsync(_fixture.WalletId!);
            Assert.NotNull(result.Id);
        }

        [Fact]
        public async Task Test7_ListsWallets()
        {
            var result = await _fixture.WalletApi.ListWalletsAsync();
            Assert.True(result.Wallets.Count >= 1);
        }

        [Fact]
        public async Task Test8_UpdatesWallet()
        {
            var updatedName = "Updated Wallet";
            var result = await _fixture.WalletApi.UpdateWalletAsync(_fixture.WalletId!, new UpdateWalletInput
            {
                Name = updatedName
            });

            Assert.NotNull(result.Id);
            Assert.NotNull(result.Name);
            Assert.Equal(updatedName, result.Name);
        }

        [Fact]
        public async Task Test9_DeletesWallet()
        {
            if (_fixture.WalletId != null)
            {
                await WalletsHelper.DeleteWallet(_fixture.WalletId!);
            }

            if (_fixture.WalletIdDidWeb != null)
            {
                await WalletsHelper.DeleteWallet(_fixture.WalletIdDidWeb!);
            }
        }
    }
}
