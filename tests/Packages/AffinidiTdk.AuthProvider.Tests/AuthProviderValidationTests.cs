using System;
using AffinidiTdk.AuthProvider;
using Xunit;

namespace AffinidiTdk.AuthProvider.Tests
{
    public class AuthProviderValidationTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("not-a-uuid")]
        public void Constructor_ThrowsIfInvalidProjectId(string? badValue)
        {
            var ex = Assert.Throws<AuthProviderException>(() => new AuthProvider(new AuthProviderParams
            {
                ProjectId = badValue,
                TokenId = Guid.NewGuid().ToString(),
                PrivateKey = "-----BEGIN PRIVATE KEY-----\n..."
            }));

            Assert.Contains("ProjectId", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("not-a-uuid")]
        public void Constructor_ThrowsIfInvalidTokenId(string? badValue)
        {
            var ex = Assert.Throws<AuthProviderException>(() => new AuthProvider(new AuthProviderParams
            {
                ProjectId = Guid.NewGuid().ToString(),
                TokenId = badValue,
                PrivateKey = "-----BEGIN PRIVATE KEY-----\n..."
            }));

            Assert.Contains("TokenId", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("not-a-pem")]
        public void Constructor_ThrowsIfInvalidPrivateKey(string? badValue)
        {
            var ex = Assert.Throws<AuthProviderException>(() => new AuthProvider(new AuthProviderParams
            {
                ProjectId = Guid.NewGuid().ToString(),
                TokenId = Guid.NewGuid().ToString(),
                PrivateKey = badValue
            }));

            Assert.Contains("PrivateKey", ex.Message);
        }

        [Fact]
        public void Constructor_ThrowsIfKeyIdIsInvalid()
        {
            var ex = Assert.Throws<AuthProviderException>(() => new AuthProvider(new AuthProviderParams
            {
                ProjectId = Guid.NewGuid().ToString(),
                TokenId = Guid.NewGuid().ToString(),
                KeyId = "bad-key",
                PrivateKey = "-----BEGIN PRIVATE KEY-----\n..."
            }));

            Assert.Contains("KeyId", ex.Message);
        }
    }
}
