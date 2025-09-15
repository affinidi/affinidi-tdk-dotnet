using Xunit;

using DotNetEnv;
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
            Env.TraversePath().Load();

            var authProviderParams = new IAuthProviderParams
            {
                ProjectId = Environment.GetEnvironmentVariable("PROJECT_ID"),
                TokenId = Environment.GetEnvironmentVariable("TOKEN_ID"),
                KeyId = Environment.GetEnvironmentVariable("KEY_ID"),
                PrivateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY"),
                Passphrase = Environment.GetEnvironmentVariable("PASSPHRASE")
            };

            _authProvider = new AuthProvider(authProviderParams);

            // Set up the token handler + HttpClient
            var tokenHandler = new TokenInjectingHandler(GetProjectScopedToken, new HttpClientHandler());
            HttpClient = new HttpClient(tokenHandler);
        }

        public async Task<string> GetProjectScopedToken()
        {
            return await _authProvider.FetchProjectScopedToken();
        }
    }
}
