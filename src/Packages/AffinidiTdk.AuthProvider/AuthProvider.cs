using System;
using System.Threading.Tasks;

namespace AffinidiTdk.AuthProvider
{
    public class IAuthProviderParams
    {
        public string? ProjectId { get; set; }
        public string? TokenId { get; set; }
        public string? KeyId { get; set; }
        public string? PrivateKey { get; set; }
        public string? Passphrase { get; set; }
        public string? ApiGatewayUrl { get; set; }
        public string? TokenEndpoint { get; set; }
    }

    public class AuthProvider
    {
        private string publicKey = string.Empty;
        private string projectScopedToken = string.Empty;

        private readonly string keyId;
        private readonly string tokenId;
        private readonly string passphrase;
        private readonly string privateKey;
        private readonly string projectId;

        private readonly string apiGatewayUrl;
        private readonly string tokenEndpoint;

        private readonly ProjectScopedToken projectScopedTokenInstance;
        private readonly Jwt jwt;

        public AuthProvider(IAuthProviderParams param)
        {
            apiGatewayUrl = param.ApiGatewayUrl ?? "https://apse1.api.affinidi.io";
            tokenEndpoint = param.TokenEndpoint ?? "https://apse1.auth.developer.affinidi.io/auth/oauth2/token";

            if (string.IsNullOrEmpty(param.PrivateKey) || string.IsNullOrEmpty(param.ProjectId) || string.IsNullOrEmpty(param.TokenId))
            {
                throw new ArgumentException("Missing parameters. Please provide privateKey, projectId, and tokenId.");
            }

            projectId = param.ProjectId;
            tokenId = param.TokenId;
            keyId = param.KeyId ?? param.TokenId;
            privateKey = param.PrivateKey;
            passphrase = param.Passphrase;

            projectScopedTokenInstance = new ProjectScopedToken();
            jwt = new Jwt();
        }

        private async Task<bool> ShouldRefreshToken()
        {
            if (string.IsNullOrEmpty(publicKey))
            {
                publicKey = await jwt.FetchPublicKey(apiGatewayUrl);
            }

            var isTokenExpired = !string.IsNullOrEmpty(projectScopedToken) &&
                                 jwt.ValidateToken(projectScopedToken, publicKey).IsExpired;

            return string.IsNullOrEmpty(projectScopedToken) || isTokenExpired;
        }

        public async Task<string> FetchProjectScopedToken()
        {
            bool shouldRefresh = await ShouldRefreshToken();

            if (shouldRefresh)
            {
                projectScopedToken = await projectScopedTokenInstance.FetchProjectScopedToken(apiGatewayUrl, projectId, tokenId, tokenEndpoint, privateKey, keyId, passphrase);
            }

            return projectScopedToken;
        }
    }
}
