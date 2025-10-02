# Affinidi TDK .NET client for LoginConfiguration

Affinidi TDK dotnet client for Affinidi LOGIN CONFIGURATION


## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (minimum version: **8.0.400**)  


Check your installed version:

```bash
dotnet --version
```

### Installation

These are the steps to get you started with a dotnet project and integration with **AffinidiTdk.LoginConfigurationClient**. 
> *Steps 1 & 2 are optional if you have already created a project.*

1. **Create a new project directory**

*On **macOS / Linux / Windows (Powershell)** :*

```bash
mkdir MyProject
cd MyProject
```

2. **Initialize a .NET Project (dotnet template: console)**

```bash
dotnet new console
```

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.LoginConfigurationClient))**

```bash
dotnet add package AffinidiTdk.LoginConfigurationClient
```



## Usage

The **AffinidiTdk.LoginConfigurationClient** uses authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package which is also available in [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).

> To generate a token, you first need to create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat).

1. **Import the required dependencies**

The dependencies required may differ based on the Client API used in your application. 


```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;
```

2. **Create an AuthProvider**

```csharp
var authProvider = new AuthProvider(new AuthProviderParams
{
    // Please generate your own Personal Access Tokens (PAT). 
    // Refer to https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat for the guide on creating your own PAT.    
    TokenId = "YOUR_TOKEN_ID",
    PrivateKey = "YOUR_PRIVATE_KEY",
    ProjectId = "YOUR_PROJECT_ID"
    // Passphrase = "YOUR_PASSPHRASE", // Required only if provided in the PAT
});
```

3. **Fetch the ProjectScopedToken from the AuthProvider**

```csharp
string projectScopedToken = await authProvider.FetchProjectScopedTokenAsync();
```

4. **Create an instance of the Client Configuration**

- In this step, you can set the __projectScopedToken__ in the configuration.

```csharp

Configuration config = new Configuration();

config.AddApiKey("authorization", projectScopedToken);

```

5. **Create an instance of the Client API you intend to use**

- In this step, you should pass the config as a constructor argument in the Client API.
*NOTE: Each Operation requires different input. Please refer to the [operation documentation](#documentation) for the details.*

```csharp


AllowListApi api = new AllowListApi(config);

var groupNamesInput = new GroupNamesInput?();

api.AllowGroups(groupNamesInput);



```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/login-configuration/).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


## Documentation

### Client API Documentation

ClientAPI | Operation | Description
------------ | ------------- | -------------
[*AllowListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AllowListApi.md) | [*AllowGroups*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AllowListApi.md#allowgroups) | 
[*AllowListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AllowListApi.md) | [*DisallowGroups*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AllowListApi.md#disallowgroups) | 
[*AllowListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AllowListApi.md) | [*ListAllowedGroups*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AllowListApi.md#listallowedgroups) | 
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md) | [*CreateLoginConfigurations*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md#createloginconfigurations) | Create a new login configuration
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md) | [*DeleteLoginConfigurationsById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md#deleteloginconfigurationsbyid) | Delete login configurations by ID
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md) | [*GetClientMetadataByClientId*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md#getclientmetadatabyclientid) | Get Client Metadata By  OAuth 2.0 Client ID
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md) | [*GetLoginConfigurationsById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md#getloginconfigurationsbyid) | Get login configuration by ID
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md) | [*ListLoginConfigurations*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md#listloginconfigurations) | List login configurations
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md) | [*UpdateLoginConfigurationsById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ConfigurationApi.md#updateloginconfigurationsbyid) | Update login configurations by ID
[*DenyListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md) | [*BlockGroups*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md#blockgroups) | 
[*DenyListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md) | [*BlockUsers*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md#blockusers) | 
[*DenyListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md) | [*ListBlockedGroups*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md#listblockedgroups) | 
[*DenyListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md) | [*ListBlockedUsers*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md#listblockedusers) | 
[*DenyListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md) | [*UnblockGroups*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md#unblockgroups) | 
[*DenyListApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md) | [*UnblockUsers*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/DenyListApi.md#unblockusers) | 
[*GroupApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md) | [*AddUserToGroup*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md#addusertogroup) | 
[*GroupApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md) | [*CreateGroup*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md#creategroup) | 
[*GroupApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md) | [*DeleteGroup*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md#deletegroup) | 
[*GroupApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md) | [*GetGroupById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md#getgroupbyid) | 
[*GroupApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md) | [*ListGroupUserMappings*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md#listgroupusermappings) | 
[*GroupApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md) | [*ListGroups*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md#listgroups) | 
[*GroupApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md) | [*RemoveUserFromGroup*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupApi.md#removeuserfromgroup) | 
[*IdpApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md) | [*V1LoginProjectProjectIdOauth2AuthGet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md#v1loginprojectprojectidoauth2authget) | OAuth 2.0 Authorize Endpoint
[*IdpApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md) | [*V1LoginProjectProjectIdOauth2RevokePost*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md#v1loginprojectprojectidoauth2revokepost) | Revoke OAuth 2.0 Access or Refresh Token
[*IdpApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md) | [*V1LoginProjectProjectIdOauth2SessionsLogoutGet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md#v1loginprojectprojectidoauth2sessionslogoutget) | OpenID Connect Front- and Back-channel Enabled Logout
[*IdpApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md) | [*V1LoginProjectProjectIdOauth2TokenPost*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md#v1loginprojectprojectidoauth2tokenpost) | The OAuth 2.0 Token Endpoint
[*IdpApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md) | [*V1LoginProjectProjectIdUserinfoGet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md#v1loginprojectprojectiduserinfoget) | OpenID Connect Userinfo
[*IdpApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md) | [*V1LoginProjectProjectIdWellKnownJwksJsonGet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md#v1loginprojectprojectidwellknownjwksjsonget) | Discover Well-Known JSON Web Keys
[*IdpApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md) | [*V1LoginProjectProjectIdWellKnownOpenidConfigurationGet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdpApi.md#v1loginprojectprojectidwellknownopenidconfigurationget) | OpenID Connect Discovery


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [ActionForbiddenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ActionForbiddenError.md)
 - [AddUserToGroupInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AddUserToGroupInput.md)
 - [AuthorizationRequestDcql](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AuthorizationRequestDcql.md)
 - [AuthorizationRequestPex](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/AuthorizationRequestPex.md)
 - [BlockedUsers](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/BlockedUsers.md)
 - [BlockedUsersInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/BlockedUsersInput.md)
 - [CorsLoginSessionAcceptResponseOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CorsLoginSessionAcceptResponseOK.md)
 - [CorsLoginSessionForIdpOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CorsLoginSessionForIdpOK.md)
 - [CorsLoginSessionRejectResponseOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CorsLoginSessionRejectResponseOK.md)
 - [CreateGroupInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CreateGroupInput.md)
 - [CreateHydraNetworkError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CreateHydraNetworkError.md)
 - [CreateLoginConfigurationInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CreateLoginConfigurationInput.md)
 - [CreateLoginConfigurationOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CreateLoginConfigurationOutput.md)
 - [CreateLoginConfigurationOutputAuth](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CreateLoginConfigurationOutputAuth.md)
 - [CreateLoginConfigurations400Response](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CreateLoginConfigurations400Response.md)
 - [CreateProjectNetworkError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/CreateProjectNetworkError.md)
 - [ErrorOAuth2](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ErrorOAuth2.md)
 - [GetUserInfo](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GetUserInfo.md)
 - [GroupDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupDto.md)
 - [GroupNames](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupNames.md)
 - [GroupNamesInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupNamesInput.md)
 - [GroupUserMappingDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupUserMappingDto.md)
 - [GroupUserMappingsList](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupUserMappingsList.md)
 - [GroupsList](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupsList.md)
 - [GroupsPerUserLimitExceededError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/GroupsPerUserLimitExceededError.md)
 - [IdTokenMappingItem](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/IdTokenMappingItem.md)
 - [InlineObject](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/InlineObject.md)
 - [InvalidClaimContextError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/InvalidClaimContextError.md)
 - [InvalidGroupsError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/InvalidGroupsError.md)
 - [InvalidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/InvalidParameterError.md)
 - [InvalidParameterErrorDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/InvalidParameterErrorDetailsInner.md)
 - [InvalidVPTokenCreationTimeError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/InvalidVPTokenCreationTimeError.md)
 - [JsonWebKey](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/JsonWebKey.md)
 - [JsonWebKeyKeysInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/JsonWebKeyKeysInner.md)
 - [ListLoginConfigurationOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ListLoginConfigurationOutput.md)
 - [LoginConfigurationClientMetadataInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginConfigurationClientMetadataInput.md)
 - [LoginConfigurationClientMetadataOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginConfigurationClientMetadataOutput.md)
 - [LoginConfigurationObject](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginConfigurationObject.md)
 - [LoginConfigurationReadInvalidClientIdError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginConfigurationReadInvalidClientIdError.md)
 - [LoginSessionAcceptResponseInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginSessionAcceptResponseInput.md)
 - [LoginSessionAcceptResponseOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginSessionAcceptResponseOutput.md)
 - [LoginSessionDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginSessionDto.md)
 - [LoginSessionDtoAuthorizationRequest](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginSessionDtoAuthorizationRequest.md)
 - [LoginSessionForIDPInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginSessionForIDPInput.md)
 - [LoginSessionRejectResponseInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginSessionRejectResponseInput.md)
 - [LoginSessionRejectResponseOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/LoginSessionRejectResponseOutput.md)
 - [NotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/NotFoundError.md)
 - [OAuth2Token](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/OAuth2Token.md)
 - [OAuth2TokenAuthorizationDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/OAuth2TokenAuthorizationDetailsInner.md)
 - [OIDCConfig](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/OIDCConfig.md)
 - [OIDCConfigCredentialsSupportedDraft00Inner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/OIDCConfigCredentialsSupportedDraft00Inner.md)
 - [RedirectResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/RedirectResponse.md)
 - [RemoveUserFromGroupInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/RemoveUserFromGroupInput.md)
 - [ResourceCreationError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ResourceCreationError.md)
 - [ServiceErrorResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ServiceErrorResponse.md)
 - [ServiceErrorResponseDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/ServiceErrorResponseDetailsInner.md)
 - [TokenEndpointAuthMethod](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/TokenEndpointAuthMethod.md)
 - [UnauthorizedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/UnauthorizedError.md)
 - [UpdateLoginConfigurationInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/UpdateLoginConfigurationInput.md)
 - [VPTokenValidationError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/LoginConfigurationClient/docs/VPTokenValidationError.md)



## Support & Feedback

If you face any issues or have suggestions, please don't hesitate to contact us using [this link](https://share.hsforms.com/1i-4HKZRXSsmENzXtPdIG4g8oa2v).

### Reporting technical issues

If you have a technical issue with the Affinidi TDK's codebase, you can also create an issue directly in GitHub.

1. Ensure the bug was not already reported by searching on GitHub under [Issues](https://github.com/affinidi/affinidi-tdk-dotnet/issues).

2. If you're unable to find an open issue addressing the problem, [open a new one](https://github.com/affinidi/affinidi-tdk-dotnet/issues/new). Be sure to include a **title and clear description**, as much relevant information as possible, and a **code sample** or an **executable test case** demonstrating the expected behavior that is not occurring.



## Contributing

We enjoy community contributions! Whether it’s bug fixes, feature requests, or improving docs, your input helps shape the Affinidi TDK.

- Head over to our [CONTRIBUTING](CONTRIBUTING.md) to get started.
- Have an idea? Start a discussion in [GitHub Discussions](https://github.com/affinidi/affinidi-tdk-dotnet/issues) or [Discord](https://discord.com/invite/hGVVSEASPQ)


