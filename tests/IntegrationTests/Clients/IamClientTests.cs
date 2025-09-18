using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.IamClient.Model;
using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;
using Xunit;

namespace IntegrationTests
{
    [Collection("IamClientTests")]
    [TestCaseOrderer("IntegrationTests.Helpers.AlphabeticalOrderer", "IntegrationTests")]
    public class IamClientTests
    {
        private readonly IamApiFixture _fixture;
        private readonly string _principalType = "token";

        public IamClientTests(IamApiFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Test_ReadsPatPolicies()
        {
            PolicyDto result = await _fixture.PoliciesApi.GetPoliciesAsync(EnvHelper.TokenId, _principalType);
            Assert.NotNull(result.VarVersion);
            Assert.NotNull(result.Statement);
        }

        [Fact]
        public async Task Test_ManagePrincipals()
        {
            string principalId = System.Guid.NewGuid().ToString();
            var addUserToProjectInput = new AddUserToProjectInput(principalId, _principalType);

            var addPrincipalResult = await _fixture.ProjectsApi.AddPrincipalToProjectWithHttpInfoAsync(addUserToProjectInput);
            Assert.Equal(HttpStatusCode.NoContent, addPrincipalResult.StatusCode);

            UserList response = await _fixture.ProjectsApi.ListPrincipalsOfProjectAsync();
            Assert.NotEmpty(response.Records);

            var deletePrincipalResult = await _fixture.ProjectsApi.DeletePrincipalFromProjectWithHttpInfoAsync(principalId, _principalType);
            Assert.Equal(HttpStatusCode.NoContent, deletePrincipalResult.StatusCode);
        }
    }
}
