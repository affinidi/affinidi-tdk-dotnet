using System;
using System.Net.Http;
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

    /// <summary>
    /// AuthProvider is thread-safe. It caches the public key and project-scoped token
    /// and synchronizes token refresh using an internal SemaphoreSlim.
    /// Safe for use in multi-threaded applications.
    /// </summary>
    public class AuthProvider
    {
        private readonly SemaphoreSlim _tokenLock = new(1, 1);
        private readonly HttpClient _httpClient = new HttpClient();

        private string? _publicKey;
        private string? _projectScopedToken;

        private readonly string _keyId;
        private readonly string _tokenId;
        private readonly string? _passphrase;
        private readonly string _privateKey;
        private readonly string _projectId;
        private readonly string _apiGatewayUrl;
        private readonly string _tokenEndpoint;

        private readonly ProjectScopedToken _projectScopedTokenClient;
        private readonly Jwt _jwt;

        public AuthProvider(AuthProviderParams param)
        {
            _apiGatewayUrl = param.ApiGatewayUrl ?? EnvironmentUtils.FetchApiGwUrl();
            _tokenEndpoint = param.TokenEndpoint ?? EnvironmentUtils.FetchElementsAuthTokenUrl();

            _projectId = ValidateUuidOrThrow(param.ProjectId, "ProjectId");
            _tokenId = ValidateUuidOrThrow(param.TokenId, "TokenId");
            _privateKey = ValidatePemOrThrow(param.PrivateKey, "PrivateKey");

            _keyId = string.IsNullOrEmpty(param.KeyId) ? _tokenId : ValidateUuidOrThrow(param.KeyId, "KeyId");
            _passphrase = param.Passphrase;

            _projectScopedTokenClient = new ProjectScopedToken(_httpClient);
            _jwt = new Jwt(_httpClient);
        }

        private static string ValidateUuidOrThrow(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value) || !Guid.TryParse(value, out _))
                throw new AuthProviderException(
                    $"[AuthProvider:InvalidParam] {fieldName} is missing or invalid. Expected a UUID."
                );
            return value!;
        }

        private static string ValidatePemOrThrow(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.TrimStart().StartsWith("-----BEGIN"))
                throw new AuthProviderException(
                    $"[AuthProvider:InvalidParam] {fieldName} is missing or invalid. Expected a PEM-formatted string."
                );
            return value!;
        }

        public async Task<string> FetchProjectScopedTokenAsync()
        {
            await _tokenLock.WaitAsync();
            try
            {
                if (string.IsNullOrEmpty(_publicKey))
                {
                    _publicKey = await _jwt.FetchPublicKeyAsync(_apiGatewayUrl);
                }

                var shouldFetchNewToken =
                    string.IsNullOrEmpty(_projectScopedToken) ||
                    _jwt.ValidateToken(_projectScopedToken, _publicKey).IsExpired;

                if (shouldFetchNewToken)
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

                return _projectScopedToken!;
            }
            finally
            {
                _tokenLock.Release();
            }
        }
    }
}
