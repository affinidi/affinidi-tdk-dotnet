using System;
using System.Threading.Tasks;

namespace AffinidiTdk.AuthProvider
{
    public class AuthProviderParams
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
        private string _publicKey = string.Empty;
        private string _projectScopedToken = string.Empty;

        private readonly string _keyId;
        private readonly string _tokenId;
        private readonly string? _passphrase;
        private readonly string _privateKey;
        private readonly string _projectId;
        private readonly string _apiGatewayUrl;
        private readonly string _tokenEndpoint;

        private readonly ProjectScopedToken _projectScopedTokenClient = new();
        private readonly Jwt _jwt = new();

        public AuthProvider(AuthProviderParams param)
        {
            _apiGatewayUrl = param.ApiGatewayUrl ?? "https://apse1.api.affinidi.io";
            _tokenEndpoint = param.TokenEndpoint ?? "https://apse1.auth.developer.affinidi.io/auth/oauth2/token";

            _projectId = param.ProjectId ?? throw new ArgumentException("Missing parameter: ProjectId");
            _tokenId = param.TokenId ?? throw new ArgumentException("Missing parameter: TokenId");
            _privateKey = param.PrivateKey ?? throw new ArgumentException("Missing parameter: PrivateKey");

            _keyId = param.KeyId ?? _tokenId;
            _passphrase = param.Passphrase;
        }

        private async Task<bool> ShouldRefreshTokenAsync()
        {
            if (string.IsNullOrEmpty(_publicKey))
            {
                _publicKey = await _jwt.FetchPublicKeyAsync(_apiGatewayUrl);
            }

            var tokenIsEmpty = string.IsNullOrEmpty(_projectScopedToken);
            var tokenExpired = !tokenIsEmpty && _jwt.ValidateToken(_projectScopedToken, _publicKey).IsExpired;

            return tokenIsEmpty || tokenExpired;
        }

        public async Task<string> FetchProjectScopedTokenAsync()
        {
            if (await ShouldRefreshTokenAsync())
            {
                _projectScopedToken = await _projectScopedTokenClient.FetchProjectScopedToken(
                    _apiGatewayUrl,
                    _projectId,
                    _tokenId,
                    _tokenEndpoint,
                    _privateKey,
                    _keyId,
                    _passphrase
                );
            }

            return _projectScopedToken;
        }
    }
}
