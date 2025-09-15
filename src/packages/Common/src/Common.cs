namespace Common
{
    using Helpers;

    public static class Common
    {
        public static string FetchApiGwUrl(string env = "prod")
        {
            return EnvironmentUtils.FetchApiGwUrl(env);
        }

        public static string FetchElementsAuthTokenUrl(string env = "prod")
        {
            return EnvironmentUtils.FetchElementsAuthTokenUrl(env);
        }

        public static string FetchRegion()
        {
            return EnvironmentUtils.FetchRegion();
        }

        public static string FetchIotUrl(string env = "prod")
        {
            return EnvironmentUtils.FetchIotUrl(env);
        }

        public static string BuildShareLink(string request, string clientId)
        {
            return VaultUtils.BuildShareLink(request, clientId);
        }

        public static string BuildClaimLink(string credentialOfferUri)
        {
            return VaultUtils.BuildClaimLink(credentialOfferUri);
        }
    }
}
