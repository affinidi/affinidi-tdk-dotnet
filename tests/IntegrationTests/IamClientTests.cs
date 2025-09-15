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
            string token = await AuthHelper.Instance.GetProjectScopedToken();

            Configuration config = new Configuration();
            config.ApiKey.Add("authorization", token);

            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            var apiInstance = new ProjectsApi(httpClient, config, httpClientHandler);

            string principalId = System.Guid.NewGuid().ToString();

            var principalType = "token";

            var addUserToProjectInput = new AddUserToProjectInput(principalId, principalType);

            var addPrincipalResult = apiInstance.AddPrincipalToProjectWithHttpInfo(addUserToProjectInput);
            Assert.Equal(HttpStatusCode.NoContent, addPrincipalResult.StatusCode);

            UserList response = apiInstance.ListPrincipalsOfProject();
            Assert.NotEmpty(response.Records);

            var deletePrincipalResult = apiInstance.DeletePrincipalFromProjectWithHttpInfo(principalId, principalType);
            Assert.Equal(HttpStatusCode.NoContent, deletePrincipalResult.StatusCode);
        }
    }
}
