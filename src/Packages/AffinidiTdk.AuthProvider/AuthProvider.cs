using System;
using System.Threading.Tasks;
using AffinidiTdk.Common;

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
            _apiGatewayUrl = param.ApiGatewayUrl ?? EnvironmentUtils.FetchApiGwUrl();
            _tokenEndpoint = param.TokenEndpoint ?? EnvironmentUtils.FetchElementsAuthTokenUrl();

            _projectId = ValidateUuidOrThrow(param.ProjectId, "ProjectId");
            _tokenId = ValidateUuidOrThrow(param.TokenId, "TokenId");
            _privateKey = ValidatePemOrThrow(param.PrivateKey, "PrivateKey");

            _keyId = string.IsNullOrEmpty(param.KeyId) ? _tokenId : ValidateUuidOrThrow(param.KeyId, "KeyId");
            _passphrase = param.Passphrase;
        }

        private static string ValidateUuidOrThrow(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value) || !Guid.TryParse(value, out _))
                throw new AuthProviderException($"Invalid or missing {fieldName}. Expected a UUID.");
            return value!;
        }

        private static string ValidatePemOrThrow(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.TrimStart().StartsWith("-----BEGIN"))
                throw new AuthProviderException($"Invalid or missing {fieldName}. Expected a PEM-formatted string.");
            return value!;
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
                _projectScopedToken = (await _projectScopedTokenClient.FetchProjectScopedToken(
                    _apiGatewayUrl,
                    _projectId,
                    _tokenId,
                    _tokenEndpoint,
                    _privateKey,
                    _keyId,
                    _passphrase
                ))!;
            }

            return _projectScopedToken!;
        }
    }
}
