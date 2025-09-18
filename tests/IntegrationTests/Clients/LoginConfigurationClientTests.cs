using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;
using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;
using Xunit;

namespace IntegrationTests
{
    [Collection("LoginConfigurationClientTests")]
    [TestCaseOrderer("IntegrationTests.Helpers.AlphabeticalOrderer", "IntegrationTests")]
    public class LoginConfigurationClientTests
    {
        private readonly LoginConfigurationApiFixture _fixture;

        public LoginConfigurationClientTests(LoginConfigurationApiFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task TestListLoginConfigurations()
        {
            ListLoginConfigurationOutput result = await _fixture.ConfigurationApi.ListLoginConfigurationsAsync();

            Assert.NotNull(result);
            Assert.IsType<ListLoginConfigurationOutput>(result);
            Assert.NotEmpty(result.Configurations);
        }

        [Fact]
        public async Task TestReadLoginConfiguration()
        {
            LoginConfigurationObject result = await _fixture.ConfigurationApi.GetLoginConfigurationsByIdAsync(_fixture.LoginConfigurationId);

            Assert.NotNull(result);
            Assert.IsType<LoginConfigurationObject>(result);
        }

        [Fact]
        public async Task TestUpdateLoginConfiguration()
        {
            string newName = Utils.GenerateRandomString();
            var input = new UpdateLoginConfigurationInput(
                name: newName
            );

            LoginConfigurationObject result = await _fixture.ConfigurationApi.UpdateLoginConfigurationsByIdAsync(_fixture.LoginConfigurationId, input);

            Assert.NotNull(result);
            Assert.IsType<LoginConfigurationObject>(result);
            Assert.Equal(result.Name, newName);

        }

        [Fact]
        public async Task TestListGroups()
        {
            GroupsList result = await _fixture.GroupApi.ListGroupsAsync();

            Assert.NotNull(result);
            Assert.IsType<GroupsList>(result);
            Assert.NotEmpty(result.Groups);
        }

        [Fact]
        public async Task TestReadGroup()
        {
            GroupDto result = await _fixture.GroupApi.GetGroupByIdAsync(_fixture.GroupName);

            Assert.NotNull(result);
            Assert.IsType<GroupDto>(result);
        }

        [Fact]
        public async Task TestAllowList()
        {
            var groupNamesInput = new GroupNamesInput(
                groupNames: new List<string> { _fixture.GroupName }
            );

            ApiResponse<object> allowGroupsResponse = await _fixture.AllowListApi.AllowGroupsWithHttpInfoAsync(groupNamesInput);
            Assert.Equal(HttpStatusCode.OK, allowGroupsResponse.StatusCode);

            GroupNames listAllowGroupsResponse = await _fixture.AllowListApi.ListAllowedGroupsAsync();
            Assert.NotNull(listAllowGroupsResponse);
            Assert.IsType<GroupNames>(listAllowGroupsResponse);
            Assert.NotEmpty(listAllowGroupsResponse.VarGroupNames);

            ApiResponse<object> disallowGroupsResponse = await _fixture.AllowListApi.DisallowGroupsWithHttpInfoAsync(groupNamesInput);
            Assert.Equal(HttpStatusCode.OK, disallowGroupsResponse.StatusCode);
        }

        [Fact]
        public async Task TestDenyList()
        {
            string blockUserId = "test";

            var groupNamesInput = new GroupNamesInput(
                groupNames: new List<string> { _fixture.GroupName }
            );

            var blockedUsersInput = new BlockedUsersInput(
                userIds: new List<string> { blockUserId }
            );

            ApiResponse<object> blockGroupsResponse = await _fixture.DenyListApi.BlockGroupsWithHttpInfoAsync(groupNamesInput);
            Assert.Equal(HttpStatusCode.OK, blockGroupsResponse.StatusCode);

            GroupNames listBlockedGroupsResponse = await _fixture.DenyListApi.ListBlockedGroupsAsync();
            Assert.NotNull(listBlockedGroupsResponse);
            Assert.IsType<GroupNames>(listBlockedGroupsResponse);
            Assert.NotEmpty(listBlockedGroupsResponse.VarGroupNames);

            ApiResponse<object> unblockGroupsResponse = await _fixture.DenyListApi.UnblockGroupsWithHttpInfoAsync(groupNamesInput);
            Assert.Equal(HttpStatusCode.OK, unblockGroupsResponse.StatusCode);

            ApiResponse<object> blockUsersResponse = await _fixture.DenyListApi.BlockUsersWithHttpInfoAsync(blockedUsersInput);
            Assert.Equal(HttpStatusCode.OK, blockUsersResponse.StatusCode);

            BlockedUsers listBlockedUsersResponse = await _fixture.DenyListApi.ListBlockedUsersAsync();
            Assert.NotNull(listBlockedUsersResponse);
            Assert.IsType<BlockedUsers>(listBlockedUsersResponse);
            Assert.NotEmpty(listBlockedUsersResponse.UserIds);

            ApiResponse<object> unblockUsersResponse = await _fixture.DenyListApi.UnblockUsersWithHttpInfoAsync(blockedUsersInput);
            Assert.Equal(HttpStatusCode.OK, unblockUsersResponse.StatusCode);
        }
    }
}
