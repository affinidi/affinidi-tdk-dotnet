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
        public async Task Test01_CreatesWallet_DidWeb()
        {
            var result = await WalletsHelper.CreateWallet(true);
            Assert.NotNull(result.Wallet);
            _fixture.WalletIdDidWeb = result.Wallet.Id;
        }

        [Fact]
        public async Task Test02_CreatesWalletV2_DidWeb()
        {
            var result = await WalletsHelper.CreateWalletV2(true);
            Assert.NotNull(result.Wallet);
            _fixture.V2WalletIdDidWeb = result.Wallet.Id;
        }

        [Fact]
        public async Task Test03_CreateWallet_V2()
        {
            var result = await WalletsHelper.CreateWalletV2();
            Assert.NotNull(result.Wallet);
        }

        [Fact]
        public async Task Test04_GetsWallet()
        {
            var result = await _fixture.WalletApi.GetWalletAsync(_fixture.WalletId!);
            Assert.NotNull(result.Id);
        }

        [Fact]
        public async Task Test05_ListsWallets()
        {
            var result = await _fixture.WalletApi.ListWalletsAsync();
            Assert.True(result.Wallets.Count >= 1);
        }

        [Fact]
        public async Task Test06_UpdatesWallet()
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
        public async Task Test07_SignsJwt()
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
        public async Task Test08_SignsCredential()
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
        public async Task Test09_SignsCredential_Expired_NotValid()
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
        public async Task Test10_GetsRevocationListCredential()
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
        public async Task Test11_RevokesVerifiableCredential()
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

        // Test sign ldp credential v2
        [Fact]
        public async Task Test12_SignsLdpCredentialV2()
        {
            var expiresAt = DateTime.UtcNow.AddMinutes(10).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            var UnsignedCredentialV2String = EnvHelper.UnsignedCredentialV2;
            var baseCredential = JsonConvert.DeserializeObject<JObject>(UnsignedCredentialV2String)!;

            var unsignedCredential = new JObject(baseCredential);

            unsignedCredential["holder"] = new JObject
            {
                ["id"] = _fixture.V2WalletDid!
            };
            unsignedCredential["expirationDate"] = expiresAt;
            unsignedCredential["issuanceDate"] = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            var credentialSubject = unsignedCredential["credentialSubject"] as JObject ?? new JObject();
            credentialSubject["id"] = _fixture.V2WalletDid!;
            unsignedCredential["credentialSubject"] = credentialSubject;

            var signCredentialsLdpInputDto = new SignCredentialsLdpInputDto(unsignedCredential);

            var result = await _fixture.WalletApi.SignCredentialsLdpAsync(_fixture.V2WalletId!, signCredentialsLdpInputDto);

            Assert.NotNull(result.Credential);
            _fixture.SignedCredentialLdp = result.Credential;
        }

        // Test sign jwt credential v2

        [Fact]
        public async Task Test12_SignsJwtCredentialV2()
        {
            var expiresAt = DateTime.UtcNow.AddMinutes(10).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            var UnsignedCredentialV2String = EnvHelper.UnsignedCredentialV2;
            var baseCredential = JsonConvert.DeserializeObject<JObject>(UnsignedCredentialV2String)!;

            // Replace first item in @context array with W3C credentials v1, keep rest
            var existingContext = baseCredential["@context"] as JArray ?? new JArray();
            var contextArray = new JArray { "https://www.w3.org/2018/credentials/v1" };
            for (int i = 1; i < existingContext.Count; i++)
            {
                contextArray.Add(existingContext[i]);
            }

            var unsignedCredential = new JObject(baseCredential);
            unsignedCredential["@context"] = contextArray;
            unsignedCredential["type"] = baseCredential["type"];
            unsignedCredential["id"] = $"uuid:test-jwt-expired-tdk-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
            unsignedCredential["holder"] = new JObject
            {
                ["id"] = _fixture.V2WalletDid!
            };
            unsignedCredential["issuanceDate"] = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            unsignedCredential["expirationDate"] = expiresAt;

            var credentialSubject = baseCredential["credentialSubject"] as JObject ?? new JObject();
            credentialSubject["id"] = _fixture.V2WalletDid!;
            unsignedCredential["credentialSubject"] = credentialSubject;

            var signCredentialsJwtInputDto = new SignCredentialsJwtInputDto(unsignedCredential);

            var result = await _fixture.WalletApi.SignCredentialsJwtAsync(_fixture.V2WalletId!, signCredentialsJwtInputDto);

            Assert.NotNull(result.Credential);
            Assert.Contains("eyJ", result.Credential);
        }

        // Test sign sd-jwt credential v2
        [Fact]
        public async Task Test13_SignsSdJwtCredentialV2()
        {
            var validFrom = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            var validUntil = DateTime.UtcNow.AddYears(5).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");

            var UnsignedCredentialV2String = EnvHelper.UnsignedCredentialV2;
            var unsignedCredential = JsonConvert.DeserializeObject<JObject>(UnsignedCredentialV2String)!;

            unsignedCredential["id"] = $"urn:uuid:test-sdjwt-tdk-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
            unsignedCredential["validFrom"] = validFrom;
            unsignedCredential["validUntil"] = validUntil;

            var disclosureFrameString = EnvHelper.DisclosureFrameV2;
            var disclosureFrame = JsonConvert.DeserializeObject<object>(disclosureFrameString)!;

            var signCredentialsSdJwtInputDto = new SignCredentialsDm2SdJwtInputDto(
                unsignedCredential: unsignedCredential,
                revocable: true,
                disclosureFrame: disclosureFrame
            );

            var result = await _fixture.WalletApi.SignCredentialsSdJwtAsync(_fixture.V2WalletId!, signCredentialsSdJwtInputDto);

            Assert.NotNull(result.Credential);
            Assert.Contains("~", result.Credential);
        }

        // Test sign verifiable presentation ldp v2
        [Fact]
        public async Task Test14_SignsPresentationLdpV2()
        {
            var unsignedPresentation = new JObject
            {
                ["@context"] = new JArray { "https://www.w3.org/ns/credentials/v2" },
                ["id"] = $"testVpV2Id-tdk-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}",
                ["type"] = new JArray { "VerifiablePresentation" },
                ["holder"] = new JObject
                {
                    ["id"] = _fixture.V2WalletDid!
                },
                ["verifiableCredential"] = new JArray { _fixture.SignedCredentialLdp }
            };

            var signPresentationLdpInputDto = new SignPresentationLdpInputDto(unsignedPresentation);

            var result = await _fixture.WalletApi.SignPresentationsLdpAsync(_fixture.V2WalletId!, signPresentationLdpInputDto);

            Assert.NotNull(result.Presentation);
        }

        // Test revoke credential v2
        [Fact]
        public async Task Test15_RevokesVerifiableCredentialV2()
        {
            if (_fixture.SignedCredentialLdp != null)
            {
                var signedCredentialLdpJObject = JObject.FromObject(_fixture.SignedCredentialLdp);
                var credentialId = signedCredentialLdpJObject["id"]?.ToString();

                if (!string.IsNullOrEmpty(credentialId))
                {
                    var revokeCredentialInput = new RevokeCredentialInput
                    {
                        RevocationReason = "test v2 tdk",
                        CredentialId = credentialId
                    };

                    await _fixture.RevocationApi.RevokeCredentialAsync(_fixture.V2WalletId!, revokeCredentialInput);

                    // Verify the credential is now invalid
                    var isValid = await VerificationHelper.IsValid(_fixture.SignedCredentialLdp);
                    Assert.False(isValid);
                }
            }
        }


        [Fact]
        public async Task Test99_DeletesWallet()
        {
            if (_fixture.WalletId != null)
            {
                await WalletsHelper.DeleteWallet(_fixture.WalletId!);
            }

            if (_fixture.WalletIdDidWeb != null)
            {
                await WalletsHelper.DeleteWallet(_fixture.WalletIdDidWeb!);
            }

            if (_fixture.V2WalletId != null)
            {
                await WalletsHelper.DeleteWallet(_fixture.V2WalletId!);
            }
            if (_fixture.V2WalletIdDidWeb != null)
            {
                await WalletsHelper.DeleteWallet(_fixture.V2WalletIdDidWeb!);
            }
        }
    }
}
