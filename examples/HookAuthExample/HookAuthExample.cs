using System;
using System.Net.Http;
using System.Threading.Tasks;

using AffinidiTdk.AuthProvider;
using AffinidiTdk.Common;
using AffinidiTdk.Common.Http;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.IotaClient.Api;
using WalletsConfiguration = AffinidiTdk.WalletsClient.Client.Configuration;
using IotaConfiguration = AffinidiTdk.IotaClient.Client.Configuration;

class HookAuthExample
{
    private static HttpClient CreateSharedHttpClient(AuthProvider authProvider)
    {
        var tokenHandler = new TokenInjectingHandler(
            () => authProvider.FetchProjectScopedTokenAsync(),
            new HttpClientHandler()
        );

        return new HttpClient(tokenHandler);
    }

    public static async Task Main(string[] args)
    {
        try
        {
            // Hook approach: TokenHandler handles fetching + injecting token
            var authProvider = new AuthProvider(new AuthProviderParams
            {
                // 💡 TODO: Replace with actual values or environment lookup
                KeyId = "YOUR_KEY_ID", // [OPTIONAL]
                Passphrase = "YOUR_PASSPHRASE", // [OPTIONAL]
                TokenId = "YOUR_TOKEN_ID",
                PrivateKey = "YOUR_PRIVATE_KEY",
                ProjectId = "YOUR_PROJECT_ID"
            });

            // Shared HttpClient
            using var httpClient = CreateSharedHttpClient(authProvider);

            WalletApi walletsApi = new WalletApi(httpClient, new WalletsConfiguration());
            ConfigurationsApi iotaApi = new ConfigurationsApi(httpClient, new IotaConfiguration());

            var walletsResult = await walletsApi.ListWalletsAsync();
            Logger.Info($"[HookAuth] You have ${walletsResult.Wallets.Count} wallets.");

            var configurationsResult = await iotaApi.ListIotaConfigurationsAsync();
            Logger.Info($"[HookAuth] You have ${configurationsResult.Configurations.Count} Iota configurations.");

        }
        catch (Exception ex)
        {
            Logger.Exception(ex, showStackTrace: false);  // showStackTrace: true by default
        }
    }
}
