using System;
using System.Threading.Tasks;

using AffinidiTdk.AuthProvider;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;

class Example
{
    public static async Task Main(string[] args)
    {
        AuthProvider authProvider = new AuthProvider(new AuthProviderParams
        {
            // 💡 TODO: update with your Affinidi ProjectId and PAT secrets
            ProjectId = "YOUR_PROJECT_ID",
            TokenId = "YOUR_TOKEN_ID",
            PrivateKey = "YOUR_PRIVATE_KEY",
            KeyId = "YOUR_KEY_ID", // [OPTIONAL] unless unique value used on for the PAT
            Passphrase = "YOUR_PASSPHRASE" // [OPTIONAL] unless private key is encrypted
        });

        try
        {
            string authToken = await authProvider.FetchProjectScopedTokenAsync();

            HttpClient httpClient = new HttpClient();
            Configuration config = new Configuration();
            config.AddApiKey("authorization", authToken);

            WalletApi api = new WalletApi(httpClient, config);

            var result = await api.ListWalletsAsync();

            Console.WriteLine($"❤️ You have ${result.Wallets.Count} wallets.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"💔 Oops: {ex.Message}");
        }
    }
}
