<a id="top"></a>
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
**Note:** *Steps 1 & 2 are optional if you have already created a project.*

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

<p align="right">(<a href="#top">back to top</a>)</p>


## Usage

1. **Import the required dependencies**

The dependencies required may differ based on the Client Api used in your application. 

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;
```

2. **Create an AuthProvider**

- The **AuthProvider** is a separate package which you will need to install. Get it from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).
*NOTE: This step requires you to first create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat)*

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

5. **Create an instance of the Client Api you intend to use**

- In this step, you should pass the config as a constructor argument in the Client Api.
*NOTE: Each Operation requires different input. Please refer to the <a href="#documentation">operation documentation</a> for the details.*

```csharp


AllowListApi api = new AllowListApi(config);

var groupNamesInput = new GroupNamesInput?();

api.AllowGroups(groupNamesInput);



```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/login-configuration/).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.

<p align="right">(<a href="#top">back to top</a>)</p>


## Documentation

### Client Api Documentation

ClientApi | Operation | Description
------------ | ------------- | -------------
[*AllowListApi*](docs/AllowListApi.md) | [*AllowGroups*](docs/AllowListApi.md#allowgroups) | 
[*AllowListApi*](docs/AllowListApi.md) | [*DisallowGroups*](docs/AllowListApi.md#disallowgroups) | 
[*AllowListApi*](docs/AllowListApi.md) | [*ListAllowedGroups*](docs/AllowListApi.md#listallowedgroups) | 
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*CreateLoginConfigurations*](docs/ConfigurationApi.md#createloginconfigurations) | Create a new login configuration
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*DeleteLoginConfigurationsById*](docs/ConfigurationApi.md#deleteloginconfigurationsbyid) | Delete login configurations by ID
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*GetClientMetadataByClientId*](docs/ConfigurationApi.md#getclientmetadatabyclientid) | Get Client Metadata By  OAuth 2.0 Client ID
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*GetLoginConfigurationsById*](docs/ConfigurationApi.md#getloginconfigurationsbyid) | Get login configuration by ID
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*ListLoginConfigurations*](docs/ConfigurationApi.md#listloginconfigurations) | List login configurations
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*UpdateLoginConfigurationsById*](docs/ConfigurationApi.md#updateloginconfigurationsbyid) | Update login configurations by ID
[*DenyListApi*](docs/DenyListApi.md) | [*BlockGroups*](docs/DenyListApi.md#blockgroups) | 
[*DenyListApi*](docs/DenyListApi.md) | [*BlockUsers*](docs/DenyListApi.md#blockusers) | 
[*DenyListApi*](docs/DenyListApi.md) | [*ListBlockedGroups*](docs/DenyListApi.md#listblockedgroups) | 
[*DenyListApi*](docs/DenyListApi.md) | [*ListBlockedUsers*](docs/DenyListApi.md#listblockedusers) | 
[*DenyListApi*](docs/DenyListApi.md) | [*UnblockGroups*](docs/DenyListApi.md#unblockgroups) | 
[*DenyListApi*](docs/DenyListApi.md) | [*UnblockUsers*](docs/DenyListApi.md#unblockusers) | 
[*GroupApi*](docs/GroupApi.md) | [*AddUserToGroup*](docs/GroupApi.md#addusertogroup) | 
[*GroupApi*](docs/GroupApi.md) | [*CreateGroup*](docs/GroupApi.md#creategroup) | 
[*GroupApi*](docs/GroupApi.md) | [*DeleteGroup*](docs/GroupApi.md#deletegroup) | 
[*GroupApi*](docs/GroupApi.md) | [*GetGroupById*](docs/GroupApi.md#getgroupbyid) | 
[*GroupApi*](docs/GroupApi.md) | [*ListGroupUserMappings*](docs/GroupApi.md#listgroupusermappings) | 
[*GroupApi*](docs/GroupApi.md) | [*ListGroups*](docs/GroupApi.md#listgroups) | 
[*GroupApi*](docs/GroupApi.md) | [*RemoveUserFromGroup*](docs/GroupApi.md#removeuserfromgroup) | 
[*IdpApi*](docs/IdpApi.md) | [*V1LoginProjectProjectIdOauth2AuthGet*](docs/IdpApi.md#v1loginprojectprojectidoauth2authget) | OAuth 2.0 Authorize Endpoint
[*IdpApi*](docs/IdpApi.md) | [*V1LoginProjectProjectIdOauth2RevokePost*](docs/IdpApi.md#v1loginprojectprojectidoauth2revokepost) | Revoke OAuth 2.0 Access or Refresh Token
[*IdpApi*](docs/IdpApi.md) | [*V1LoginProjectProjectIdOauth2SessionsLogoutGet*](docs/IdpApi.md#v1loginprojectprojectidoauth2sessionslogoutget) | OpenID Connect Front- and Back-channel Enabled Logout
[*IdpApi*](docs/IdpApi.md) | [*V1LoginProjectProjectIdOauth2TokenPost*](docs/IdpApi.md#v1loginprojectprojectidoauth2tokenpost) | The OAuth 2.0 Token Endpoint
[*IdpApi*](docs/IdpApi.md) | [*V1LoginProjectProjectIdUserinfoGet*](docs/IdpApi.md#v1loginprojectprojectiduserinfoget) | OpenID Connect Userinfo
[*IdpApi*](docs/IdpApi.md) | [*V1LoginProjectProjectIdWellKnownJwksJsonGet*](docs/IdpApi.md#v1loginprojectprojectidwellknownjwksjsonget) | Discover Well-Known JSON Web Keys
[*IdpApi*](docs/IdpApi.md) | [*V1LoginProjectProjectIdWellKnownOpenidConfigurationGet*](docs/IdpApi.md#v1loginprojectprojectidwellknownopenidconfigurationget) | OpenID Connect Discovery


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [ActionForbiddenError](docs/ActionForbiddenError.md)
 - [AddUserToGroupInput](docs/AddUserToGroupInput.md)
 - [AuthorizationRequestDcql](docs/AuthorizationRequestDcql.md)
 - [AuthorizationRequestPex](docs/AuthorizationRequestPex.md)
 - [BlockedUsers](docs/BlockedUsers.md)
 - [BlockedUsersInput](docs/BlockedUsersInput.md)
 - [CorsLoginSessionAcceptResponseOK](docs/CorsLoginSessionAcceptResponseOK.md)
 - [CorsLoginSessionForIdpOK](docs/CorsLoginSessionForIdpOK.md)
 - [CorsLoginSessionRejectResponseOK](docs/CorsLoginSessionRejectResponseOK.md)
 - [CreateGroupInput](docs/CreateGroupInput.md)
 - [CreateHydraNetworkError](docs/CreateHydraNetworkError.md)
 - [CreateLoginConfigurationInput](docs/CreateLoginConfigurationInput.md)
 - [CreateLoginConfigurationOutput](docs/CreateLoginConfigurationOutput.md)
 - [CreateLoginConfigurationOutputAuth](docs/CreateLoginConfigurationOutputAuth.md)
 - [CreateLoginConfigurations400Response](docs/CreateLoginConfigurations400Response.md)
 - [CreateProjectNetworkError](docs/CreateProjectNetworkError.md)
 - [ErrorOAuth2](docs/ErrorOAuth2.md)
 - [GetUserInfo](docs/GetUserInfo.md)
 - [GroupDto](docs/GroupDto.md)
 - [GroupNames](docs/GroupNames.md)
 - [GroupNamesInput](docs/GroupNamesInput.md)
 - [GroupUserMappingDto](docs/GroupUserMappingDto.md)
 - [GroupUserMappingsList](docs/GroupUserMappingsList.md)
 - [GroupsList](docs/GroupsList.md)
 - [GroupsPerUserLimitExceededError](docs/GroupsPerUserLimitExceededError.md)
 - [IdTokenMappingItem](docs/IdTokenMappingItem.md)
 - [InlineObject](docs/InlineObject.md)
 - [InvalidClaimContextError](docs/InvalidClaimContextError.md)
 - [InvalidGroupsError](docs/InvalidGroupsError.md)
 - [InvalidParameterError](docs/InvalidParameterError.md)
 - [InvalidParameterErrorDetailsInner](docs/InvalidParameterErrorDetailsInner.md)
 - [InvalidVPTokenCreationTimeError](docs/InvalidVPTokenCreationTimeError.md)
 - [JsonWebKey](docs/JsonWebKey.md)
 - [JsonWebKeyKeysInner](docs/JsonWebKeyKeysInner.md)
 - [ListLoginConfigurationOutput](docs/ListLoginConfigurationOutput.md)
 - [LoginConfigurationClientMetadataInput](docs/LoginConfigurationClientMetadataInput.md)
 - [LoginConfigurationClientMetadataOutput](docs/LoginConfigurationClientMetadataOutput.md)
 - [LoginConfigurationObject](docs/LoginConfigurationObject.md)
 - [LoginConfigurationReadInvalidClientIdError](docs/LoginConfigurationReadInvalidClientIdError.md)
 - [LoginSessionAcceptResponseInput](docs/LoginSessionAcceptResponseInput.md)
 - [LoginSessionAcceptResponseOutput](docs/LoginSessionAcceptResponseOutput.md)
 - [LoginSessionDto](docs/LoginSessionDto.md)
 - [LoginSessionDtoAuthorizationRequest](docs/LoginSessionDtoAuthorizationRequest.md)
 - [LoginSessionForIDPInput](docs/LoginSessionForIDPInput.md)
 - [LoginSessionRejectResponseInput](docs/LoginSessionRejectResponseInput.md)
 - [LoginSessionRejectResponseOutput](docs/LoginSessionRejectResponseOutput.md)
 - [NotFoundError](docs/NotFoundError.md)
 - [OAuth2Token](docs/OAuth2Token.md)
 - [OAuth2TokenAuthorizationDetailsInner](docs/OAuth2TokenAuthorizationDetailsInner.md)
 - [OIDCConfig](docs/OIDCConfig.md)
 - [OIDCConfigCredentialsSupportedDraft00Inner](docs/OIDCConfigCredentialsSupportedDraft00Inner.md)
 - [RedirectResponse](docs/RedirectResponse.md)
 - [RemoveUserFromGroupInput](docs/RemoveUserFromGroupInput.md)
 - [ResourceCreationError](docs/ResourceCreationError.md)
 - [ServiceErrorResponse](docs/ServiceErrorResponse.md)
 - [ServiceErrorResponseDetailsInner](docs/ServiceErrorResponseDetailsInner.md)
 - [TokenEndpointAuthMethod](docs/TokenEndpointAuthMethod.md)
 - [UnauthorizedError](docs/UnauthorizedError.md)
 - [UpdateLoginConfigurationInput](docs/UpdateLoginConfigurationInput.md)
 - [VPTokenValidationError](docs/VPTokenValidationError.md)


<p align="right">(<a href="#top">back to top</a>)</p>


## Support & Feedback

If you face any issues or have suggestions, please don't hesitate to contact us using [this link](https://share.hsforms.com/1i-4HKZRXSsmENzXtPdIG4g8oa2v).

### Reporting technical issues

If you have a technical issue with the Affinidi TDK's codebase, you can also create an issue directly in GitHub.

1. Ensure the bug was not already reported by searching on GitHub under [Issues](https://github.com/affinidi/affinidi-tdk-dotnet/issues).

2. If you're unable to find an open issue addressing the problem, [open a new one](https://github.com/affinidi/affinidi-tdk-dotnet/issues/new). Be sure to include a **title and clear description**, as much relevant information as possible, and a **code sample** or an **executable test case** demonstrating the expected behavior that is not occurring.

<p align="right">(<a href="#top">back to top</a>)</p>


## Contributing

We enjoy community contributions! Whether it’s bug fixes, feature requests, or improving docs, your input helps shape the Affinidi TDK.

- Head over to our [CONTRIBUTING](CONTRIBUTING.md) to get started.
- Have an idea? Start a discussion in [GitHub Discussions](https://github.com/affinidi/affinidi-tdk-dotnet/issues) or [Discord](https://discord.com/invite/hGVVSEASPQ)

<p align="right">(<a href="#top">back to top</a>)</p>
