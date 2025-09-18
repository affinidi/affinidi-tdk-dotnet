using System;
using System.Threading.Tasks;
using AffinidiTdk.AuthProvider;
using DotNetEnv;
using Xunit;

namespace AffinidiTdk.AuthProvider.Tests.Helpers
{
    public class AuthHelper
    {
        private static readonly Lazy<AuthHelper> _instance = new(() => new AuthHelper());
        public static AuthHelper Instance => _instance.Value;

        private readonly AuthProvider _authProvider;

        private AuthHelper()
        {
            Env.TraversePath().Load();

            var authProviderParams = new AuthProviderParams
            {
                ProjectId = Environment.GetEnvironmentVariable("PROJECT_ID"),
                TokenId = Environment.GetEnvironmentVariable("TOKEN_ID"),
                KeyId = Environment.GetEnvironmentVariable("KEY_ID"),
                PrivateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY"),
                Passphrase = Environment.GetEnvironmentVariable("PASSPHRASE")
            };

            _authProvider = new AuthProvider(authProviderParams);
        }

        public async Task<string> GetProjectScopedToken()
        {
            return await _authProvider.FetchProjectScopedTokenAsync();
        }
    }
}
