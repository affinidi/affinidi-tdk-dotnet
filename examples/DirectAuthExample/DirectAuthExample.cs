using System;
using System.Threading.Tasks;

using AffinidiTdk.AuthProvider;
using AffinidiTdk.Common;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;

class DirectAuthExample
{
    // Lazy initialization of AuthProvider
    private static readonly Lazy<AuthProvider> _authProvider = new(() =>
        new AuthProvider(new AuthProviderParams
        {
            // 💡 TODO: Replace with actual secrets
            // KeyId = "YOUR_KEY_ID", // [OPTIONAL]
            // Passphrase = "YOUR_PASSPHRASE", // [OPTIONAL]
            TokenId = "YOUR_TOKEN_ID",
            PrivateKey = "YOUR_PRIVATE_KEY",
            ProjectId = "YOUR_PROJECT_ID"
        }));

    public static async Task Main(string[] args)
    {
        try
        {
            string token = await _authProvider.Value.FetchProjectScopedTokenAsync();

            HttpClient httpClient = new HttpClient();
            Configuration config = new Configuration();
            config.AddApiKey("authorization", token);

            WalletApi api = new WalletApi(httpClient, config);
            var result = await api.ListWalletsAsync();

            Logger.Info($"[DirectAuth] You have ${result.Wallets.Count} wallets.");
        }
        catch (Exception ex)
        {
            Logger.Exception(ex, showStackTrace: false); // showStackTrace: true by default
        }
    }
}
