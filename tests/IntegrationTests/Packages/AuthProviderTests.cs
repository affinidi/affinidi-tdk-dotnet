using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AffinidiTdk.AuthProvider;
using IntegrationTests.Helpers;
using Xunit;

namespace IntegrationTests.Packages
{
    public class AuthProviderTests
    {
        [Fact]
        public async Task FetchProjectScopedTokenAsync_ShouldBeThreadSafe()
        {

            var authProvider = new AuthProvider(new AuthProviderParams
            {
                ProjectId = EnvHelper.ProjectId,
                TokenId = EnvHelper.TokenId,
                KeyId = EnvHelper.KeyId,
                PrivateKey = EnvHelper.PrivateKey,
                Passphrase = EnvHelper.Passphrase
            });

            var tasks = new List<Task<string>>();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(() => authProvider.FetchProjectScopedTokenAsync()));
            }

            var tokens = await Task.WhenAll(tasks);

            // Tokens should be equal if token caching works correctly
            Assert.All(tokens, token => Assert.Equal(tokens[0], token));
        }
    }
}
