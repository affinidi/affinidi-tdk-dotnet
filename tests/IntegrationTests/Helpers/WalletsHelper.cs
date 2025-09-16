using Xunit;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;

namespace IntegrationTests.Helpers
{
    public class WalletsHelper
    {
        public static async Task<CreateWalletResponse> CreateWallet(bool didWeb = false)
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var apiInstance = new WalletApi(httpClient, config);

            CreateWalletInput createWalletInput;

            if (didWeb)
            {
                var randomName = Utils.GenerateRandomString();
                createWalletInput = new CreateWalletInput
                {
                    DidMethod = CreateWalletInput.DidMethodEnum.Web,
                    DidWebUrl = $"{randomName}.com"
                };
            }
            else
            {
                createWalletInput = new CreateWalletInput
                {
                    // DidMethod = "key"
                };
            }

            CreateWalletResponse result = await apiInstance.CreateWalletAsync(createWalletInput);

            Assert.NotNull(result);
            Assert.IsType<CreateWalletResponse>(result);

            Console.WriteLine($"CreateWallet result: {result}");

            return result;
        }

        public static async Task DeleteWallet(string walletId)
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            Configuration config = new Configuration();
            var apiInstance = new WalletApi(httpClient, config);

            var result = await apiInstance.DeleteWalletWithHttpInfoAsync(walletId);

            // Assert.NotNull(result);
            // Assert.IsType<CreateWalletResponse>(result);

            Console.WriteLine($"DeleteWallet result: {result}");
            Console.WriteLine($"DeleteWallet result: {result.StatusCode}");
            // return result;
        }
    }
}
