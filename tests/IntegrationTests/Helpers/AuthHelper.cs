using Xunit;

using AffinidiTdk.AuthProvider;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests.Helpers
{
    public class AuthHelper
    {
        private static readonly Lazy<AuthHelper> _instance = new(() => new AuthHelper());
        public static AuthHelper Instance => _instance.Value;

        private readonly AuthProvider _authProvider;

        // Expose the shared HttpClient instance
        public HttpClient HttpClient { get; }

        private AuthHelper()
        {
            var authProviderParams = new AuthProviderParams
            {
                ProjectId = EnvHelper.ProjectId,
                TokenId = EnvHelper.TokenId,
                KeyId = EnvHelper.KeyId,
                PrivateKey = EnvHelper.PrivateKey,
                Passphrase = EnvHelper.Passphrase
            };

            _authProvider = new AuthProvider(authProviderParams);

            // Set up the token handler + HttpClient
            var tokenHandler = new TokenInjectingHandler(GetProjectScopedToken, new HttpClientHandler());
            HttpClient = new HttpClient(tokenHandler);
        }

        public async Task<string> GetProjectScopedToken()
        {
            return await _authProvider.FetchProjectScopedTokenAsync();
        }
    }
}
