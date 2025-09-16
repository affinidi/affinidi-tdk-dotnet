using Xunit;

using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AffinidiTdk.IamClient.Api;
using AffinidiTdk.IamClient.Client;
using AffinidiTdk.IamClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests
{
    public class IamClientTests
    {
        [Fact]
        public async Task ManagePrincipals()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;

            string principalId = System.Guid.NewGuid().ToString();
            var principalType = "token";
            var addUserToProjectInput = new AddUserToProjectInput(principalId, principalType);

            Configuration config = new Configuration();
            var apiInstance = new ProjectsApi(httpClient, config);

            var addPrincipalResult = await apiInstance.AddPrincipalToProjectWithHttpInfoAsync(addUserToProjectInput);
            Assert.Equal(HttpStatusCode.NoContent, addPrincipalResult.StatusCode);

            UserList response = await apiInstance.ListPrincipalsOfProjectAsync();
            Assert.NotEmpty(response.Records);

            var deletePrincipalResult = await apiInstance.DeletePrincipalFromProjectWithHttpInfoAsync(principalId, principalType);
            Assert.Equal(HttpStatusCode.NoContent, deletePrincipalResult.StatusCode);
        }
    }
}
