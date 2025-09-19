using System;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AffinidiTdk.AuthProvider.Tests.Helpers;

using Xunit;

namespace AffinidiTdk.AuthProvider.Tests
{
    public class AuthProviderTests
    {
        [Fact]
        public async Task GetProjectScopedToken()
        {
            string token = await AuthHelper.Instance.GetProjectScopedToken();
            Assert.NotNull(token);

            string token2 = await AuthHelper.Instance.GetProjectScopedToken();
            Assert.NotNull(token2);

            Assert.Equal(token, token2);
        }
    }
}
