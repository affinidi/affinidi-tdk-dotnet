using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;
using IntegrationTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests.Fixtures
{
    public class LoginConfigurationApiFixture : IAsyncLifetime
    {
        public ConfigurationApi ConfigurationApi { get; private set; }
        public AllowListApi AllowListApi { get; private set; }
        public DenyListApi DenyListApi { get; private set; }
        public GroupApi GroupApi { get; private set; }

        public string? LoginConfigurationId { get; private set; }
        public string? GroupName { get; private set; }

        public LoginConfigurationApiFixture()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;
            Configuration config = new Configuration();

            ConfigurationApi = new ConfigurationApi(httpClient, config);
            AllowListApi = new AllowListApi(httpClient, config);
            DenyListApi = new DenyListApi(httpClient, config);
            GroupApi = new GroupApi(httpClient, config);
        }

        // Runs BEFORE any tests (init shared resources)
        public async Task InitializeAsync()
        {
            var config = new CreateLoginConfigurationInput(
                name: "TestConfig",
                redirectUris: new List<string> { "http://localhost:3000/api/auth/callback/affinidi" }
            );

            CreateLoginConfigurationOutput result = ConfigurationApi.CreateLoginConfigurations(config);
            LoginConfigurationId = result.ConfigurationId;

            GroupName = Utils.GenerateRandomString()!;

            var createGroupInput = new CreateGroupInput(
                groupName: GroupName,
                name: "TestGroup"
            );

            ApiResponse<GroupDto> createGroupResult = await GroupApi.CreateGroupWithHttpInfoAsync(createGroupInput);
            Assert.Equal(HttpStatusCode.Created, createGroupResult.StatusCode);
        }

        // Runs AFTER all tests are done (clean up)
        public async Task DisposeAsync()
        {
            ApiResponse<object> deleteGroupResult = await GroupApi.DeleteGroupWithHttpInfoAsync(GroupName!);
            Assert.Equal(HttpStatusCode.NoContent, deleteGroupResult.StatusCode);

            var deleteConfigResponse = await ConfigurationApi.DeleteLoginConfigurationsByIdWithHttpInfoAsync(LoginConfigurationId!);
            Assert.Equal(HttpStatusCode.NoContent, deleteConfigResponse.StatusCode);
        }
    }
}
