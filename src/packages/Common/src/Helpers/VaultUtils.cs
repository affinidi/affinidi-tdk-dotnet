namespace Common.Helpers
{
    public static class VaultUtils
    {
        private static readonly string LOCAL_VAULT_URL = "http://localhost:3001";
        private static readonly string DEV_VAULT_URL = "https://vault.dev.affinidi.com";
        private static readonly string PROD_VAULT_URL = "https://vault.affinidi.com";

        private static readonly Dictionary<string, string> EnvToWebVaultUrlMap = new()
        {
            { Environment.LOCAL, LOCAL_VAULT_URL },
            { Environment.DEVELOPMENT, DEV_VAULT_URL },
            { Environment.PRODUCTION, PROD_VAULT_URL }
        };

        private const string SHARE_PATH = "/login";
        private const string CLAIM_PATH = "/claim";

        public static string BuildShareLink(string request, string clientId)
        {
            var env = EnvironmentUtils.FetchEnvironment();
            var queryString = new QueryStringBuilder()
                .Add("request", request)
                .Add("client_id", clientId)
                .ToString();
            return $"{EnvToWebVaultUrlMap[env] ?? PROD_VAULT_URL}{SHARE_PATH}?{queryString}";
        }

        public static string BuildClaimLink(string credentialOfferUri)
        {
            var env = EnvironmentUtils.FetchEnvironment();
            var queryString = new QueryStringBuilder()
                .Add("credential_offer_uri", credentialOfferUri)
                .ToString();
            return $"{EnvToWebVaultUrlMap[env] ?? PROD_VAULT_URL}{CLAIM_PATH}?{queryString}";
        }
    }

    // Internal helper class for building query strings
    internal class QueryStringBuilder
    {
        private readonly List<string> _queryParams = new();

        public QueryStringBuilder Add(string key, string value)
        {
            _queryParams.Add($"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}");
            return this;
        }

        public string ToString()
        {
            return string.Join("&", _queryParams);
        }
    }
}
