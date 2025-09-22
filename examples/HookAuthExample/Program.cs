using System;
using System.Net.Http;
using System.Threading.Tasks;

using AffinidiTdk.AuthProvider;
using AffinidiTdk.Common;
using AffinidiTdk.Common.Http;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;

class HookAuthExample
{
    public static async Task Main(string[] args)
    {
        try
        {
            // Hook approach: TokenHandler handles fetching + injecting token
            var authProvider = new AuthProvider(new AuthProviderParams
            {
                // 💡 TODO: Replace with actual values or environment lookup
                // KeyId = "YOUR_KEY_ID", // [OPTIONAL]
                // Passphrase = "YOUR_PASSPHRASE", // [OPTIONAL]
                TokenId = "YOUR_TOKEN_ID",
                PrivateKey = "YOUR_PRIVATE_KEY",
                ProjectId = "YOUR_PROJECT_ID"
            });

            var tokenHandler = new TokenInjectingHandler(
                () => authProvider.FetchProjectScopedTokenAsync(),
                new HttpClientHandler()
            );

            HttpClient httpClient = new HttpClient(tokenHandler);
            Configuration config = new Configuration();

            WalletApi api = new WalletApi(httpClient, config);
            var result = await api.ListWalletsAsync();

            Logger.Success($"[HookAuth] You have ${result.Wallets.Count} wallets.");
        }
        catch (Exception ex)
        {
            Logger.Exception(ex/*, showStackTrace: true*/);
        }
    }
}
