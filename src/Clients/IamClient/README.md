<a id="top"></a>
# Affinidi TDK .NET client for Iam

Affinidi TDK dotnet client for Affinidi IAM


## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (minimum version: **8.0.400**)  


Check your installed version:

```bash
dotnet --version
```

### Installation

These are the steps to get you started with a dotnet project and integration with **AffinidiTdk.IamClient**. 
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.IamClient))**

```bash
dotnet add package AffinidiTdk.IamClient
```

<p align="right">(<a href="#top">back to top</a>)</p>


## Usage

1. **Import the required dependencies**

The dependencies required may differ based on the Client Api used in your application. 

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.IamClient.Api;
using AffinidiTdk.IamClient.Client;
using AffinidiTdk.IamClient.Model;
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


AuthzApi api = new AuthzApi(config);

var granteeDid = "granteeDid_example";

api.DeleteAccessVfs(granteeDid);



```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.

<p align="right">(<a href="#top">back to top</a>)</p>


## Documentation

### Client Api Documentation

ClientApi | Operation | Description
------------ | ------------- | -------------
[*AuthzApi*](docs/AuthzApi.md) | [*DeleteAccessVfs*](docs/AuthzApi.md#deleteaccessvfs) | delete access of granteeDid
[*AuthzApi*](docs/AuthzApi.md) | [*GrantAccessVfs*](docs/AuthzApi.md#grantaccessvfs) | Grant access to the virtual file system
[*AuthzApi*](docs/AuthzApi.md) | [*UpdateAccessVfs*](docs/AuthzApi.md#updateaccessvfs) | Update access of granteeDid
[*ConsumerAuthApi*](docs/ConsumerAuthApi.md) | [*ConsumerAuthTokenEndpoint*](docs/ConsumerAuthApi.md#consumerauthtokenendpoint) | The Consumer OAuth 2.0 Token Endpoint
[*DefaultApi*](docs/DefaultApi.md) | [*V1AuthProxyDelete*](docs/DefaultApi.md#v1authproxydelete) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1AuthProxyGet*](docs/DefaultApi.md#v1authproxyget) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1AuthProxyPatch*](docs/DefaultApi.md#v1authproxypatch) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1AuthProxyPost*](docs/DefaultApi.md#v1authproxypost) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1AuthProxyPut*](docs/DefaultApi.md#v1authproxyput) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1IdpProxyDelete*](docs/DefaultApi.md#v1idpproxydelete) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1IdpProxyGet*](docs/DefaultApi.md#v1idpproxyget) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1IdpProxyPatch*](docs/DefaultApi.md#v1idpproxypatch) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1IdpProxyPost*](docs/DefaultApi.md#v1idpproxypost) | 
[*DefaultApi*](docs/DefaultApi.md) | [*V1IdpProxyPut*](docs/DefaultApi.md#v1idpproxyput) | 
[*PoliciesApi*](docs/PoliciesApi.md) | [*GetPolicies*](docs/PoliciesApi.md#getpolicies) | 
[*PoliciesApi*](docs/PoliciesApi.md) | [*UpdatePolicies*](docs/PoliciesApi.md#updatepolicies) | 
[*ProjectsApi*](docs/ProjectsApi.md) | [*AddPrincipalToProject*](docs/ProjectsApi.md#addprincipaltoproject) | 
[*ProjectsApi*](docs/ProjectsApi.md) | [*CreateProject*](docs/ProjectsApi.md#createproject) | 
[*ProjectsApi*](docs/ProjectsApi.md) | [*DeletePrincipalFromProject*](docs/ProjectsApi.md#deleteprincipalfromproject) | 
[*ProjectsApi*](docs/ProjectsApi.md) | [*ListPrincipalsOfProject*](docs/ProjectsApi.md#listprincipalsofproject) | 
[*ProjectsApi*](docs/ProjectsApi.md) | [*ListProject*](docs/ProjectsApi.md#listproject) | 
[*ProjectsApi*](docs/ProjectsApi.md) | [*UpdateProject*](docs/ProjectsApi.md#updateproject) | 
[*StsApi*](docs/StsApi.md) | [*CreateProjectScopedToken*](docs/StsApi.md#createprojectscopedtoken) | 
[*StsApi*](docs/StsApi.md) | [*Whoami*](docs/StsApi.md#whoami) | 
[*TokensApi*](docs/TokensApi.md) | [*CreateToken*](docs/TokensApi.md#createtoken) | 
[*TokensApi*](docs/TokensApi.md) | [*DeleteToken*](docs/TokensApi.md#deletetoken) | 
[*TokensApi*](docs/TokensApi.md) | [*GetToken*](docs/TokensApi.md#gettoken) | 
[*TokensApi*](docs/TokensApi.md) | [*ListProjectsOfToken*](docs/TokensApi.md#listprojectsoftoken) | 
[*TokensApi*](docs/TokensApi.md) | [*ListToken*](docs/TokensApi.md#listtoken) | 
[*TokensApi*](docs/TokensApi.md) | [*UpdateToken*](docs/TokensApi.md#updatetoken) | 
[*WellKnownApi*](docs/WellKnownApi.md) | [*GetWellKnownDid*](docs/WellKnownApi.md#getwellknowndid) | 
[*WellKnownApi*](docs/WellKnownApi.md) | [*GetWellKnownJwks*](docs/WellKnownApi.md#getwellknownjwks) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [ActionForbiddenError](docs/ActionForbiddenError.md)
 - [AddUserToProjectInput](docs/AddUserToProjectInput.md)
 - [ConsumerAuthTokenEndpointInput](docs/ConsumerAuthTokenEndpointInput.md)
 - [ConsumerAuthTokenEndpointOutput](docs/ConsumerAuthTokenEndpointOutput.md)
 - [CorsConsumerAuthTokenEndpointOK](docs/CorsConsumerAuthTokenEndpointOK.md)
 - [CorsGrantAccessVfsOK](docs/CorsGrantAccessVfsOK.md)
 - [CorsUpdateAccessVfsOK](docs/CorsUpdateAccessVfsOK.md)
 - [CreateProjectInput](docs/CreateProjectInput.md)
 - [CreateProjectScopedTokenInput](docs/CreateProjectScopedTokenInput.md)
 - [CreateProjectScopedTokenOutput](docs/CreateProjectScopedTokenOutput.md)
 - [CreateTokenInput](docs/CreateTokenInput.md)
 - [DeleteAccessOutput](docs/DeleteAccessOutput.md)
 - [GrantAccessInput](docs/GrantAccessInput.md)
 - [GrantAccessOutput](docs/GrantAccessOutput.md)
 - [InvalidDIDError](docs/InvalidDIDError.md)
 - [InvalidJwtTokenError](docs/InvalidJwtTokenError.md)
 - [InvalidParameterError](docs/InvalidParameterError.md)
 - [JsonWebKeyDto](docs/JsonWebKeyDto.md)
 - [JsonWebKeySetDto](docs/JsonWebKeySetDto.md)
 - [NotFoundError](docs/NotFoundError.md)
 - [PolicyDto](docs/PolicyDto.md)
 - [PolicyStatementDto](docs/PolicyStatementDto.md)
 - [PrincipalCannotBeDeletedError](docs/PrincipalCannotBeDeletedError.md)
 - [PrincipalDoesNotBelongToProjectError](docs/PrincipalDoesNotBelongToProjectError.md)
 - [ProjectDto](docs/ProjectDto.md)
 - [ProjectList](docs/ProjectList.md)
 - [ProjectWithPolicyDto](docs/ProjectWithPolicyDto.md)
 - [ProjectWithPolicyList](docs/ProjectWithPolicyList.md)
 - [PublicKeyCannotBeResolvedFromDidError](docs/PublicKeyCannotBeResolvedFromDidError.md)
 - [RightsEnum](docs/RightsEnum.md)
 - [ServiceErrorResponse](docs/ServiceErrorResponse.md)
 - [ServiceErrorResponseDetailsInner](docs/ServiceErrorResponseDetailsInner.md)
 - [TokenDto](docs/TokenDto.md)
 - [TokenList](docs/TokenList.md)
 - [TokenPrivateKeyAuthenticationMethodDto](docs/TokenPrivateKeyAuthenticationMethodDto.md)
 - [TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfo](docs/TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfo.md)
 - [TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfoOneOf](docs/TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfoOneOf.md)
 - [TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfoOneOf1](docs/TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfoOneOf1.md)
 - [TypedPrincipalId](docs/TypedPrincipalId.md)
 - [UnauthorizedError](docs/UnauthorizedError.md)
 - [UnexpectedError](docs/UnexpectedError.md)
 - [UpdateAccessInput](docs/UpdateAccessInput.md)
 - [UpdateAccessOutput](docs/UpdateAccessOutput.md)
 - [UpdateProjectInput](docs/UpdateProjectInput.md)
 - [UpdateTokenInput](docs/UpdateTokenInput.md)
 - [UpdateTokenPrivateKeyAuthenticationMethodDto](docs/UpdateTokenPrivateKeyAuthenticationMethodDto.md)
 - [UserDto](docs/UserDto.md)
 - [UserList](docs/UserList.md)
 - [WhoamiDto](docs/WhoamiDto.md)


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
