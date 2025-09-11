using Xunit;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using IntegrationTests.Helpers;

namespace IntegrationTests
{
    public class AuthProviderTests
    {
        [Fact]
        public async Task ListWallets()
        {
            string token = await AuthHelper.Instance.GetProjectScopedToken();
            Assert.NotNull(token);

            string token2 = await AuthHelper.Instance.GetProjectScopedToken();
            Assert.NotNull(token2);

            Assert.Equal(token, token2);
        }
    }
}
