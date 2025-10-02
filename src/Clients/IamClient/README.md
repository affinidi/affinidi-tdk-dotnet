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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.IamClient))**

```bash
dotnet add package AffinidiTdk.IamClient
```



## Usage

The **AffinidiTdk.IamClient** uses authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package which is also available in [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).

> To generate a token, you first need to create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat).

1. **Import the required dependencies**

The dependencies required may differ based on the Client API used in your application. 


```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.IamClient.Api;
using AffinidiTdk.IamClient.Client;
using AffinidiTdk.IamClient.Model;
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


AuthzApi api = new AuthzApi(config);

var granteeDid = "granteeDid_example";

api.DeleteAccessVfs(granteeDid);



```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


## Documentation

### Client API Documentation

ClientAPI | Operation | Description
------------ | ------------- | -------------
[*AuthzApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/AuthzApi.md) | [*DeleteAccessVfs*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/AuthzApi.md#deleteaccessvfs) | delete access of granteeDid
[*AuthzApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/AuthzApi.md) | [*GrantAccessVfs*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/AuthzApi.md#grantaccessvfs) | Grant access to the virtual file system
[*AuthzApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/AuthzApi.md) | [*UpdateAccessVfs*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/AuthzApi.md#updateaccessvfs) | Update access of granteeDid
[*ConsumerAuthApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ConsumerAuthApi.md) | [*ConsumerAuthTokenEndpoint*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ConsumerAuthApi.md#consumerauthtokenendpoint) | The Consumer OAuth 2.0 Token Endpoint
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1AuthProxyDelete*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1authproxydelete) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1AuthProxyGet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1authproxyget) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1AuthProxyPatch*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1authproxypatch) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1AuthProxyPost*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1authproxypost) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1AuthProxyPut*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1authproxyput) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1IdpProxyDelete*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1idpproxydelete) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1IdpProxyGet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1idpproxyget) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1IdpProxyPatch*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1idpproxypatch) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1IdpProxyPost*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1idpproxypost) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md) | [*V1IdpProxyPut*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DefaultApi.md#v1idpproxyput) | 
[*PoliciesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PoliciesApi.md) | [*GetPolicies*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PoliciesApi.md#getpolicies) | 
[*PoliciesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PoliciesApi.md) | [*UpdatePolicies*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PoliciesApi.md#updatepolicies) | 
[*ProjectsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md) | [*AddPrincipalToProject*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md#addprincipaltoproject) | 
[*ProjectsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md) | [*CreateProject*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md#createproject) | 
[*ProjectsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md) | [*DeletePrincipalFromProject*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md#deleteprincipalfromproject) | 
[*ProjectsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md) | [*ListPrincipalsOfProject*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md#listprincipalsofproject) | 
[*ProjectsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md) | [*ListProject*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md#listproject) | 
[*ProjectsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md) | [*UpdateProject*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectsApi.md#updateproject) | 
[*StsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/StsApi.md) | [*CreateProjectScopedToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/StsApi.md#createprojectscopedtoken) | 
[*StsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/StsApi.md) | [*Whoami*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/StsApi.md#whoami) | 
[*TokensApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md) | [*CreateToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md#createtoken) | 
[*TokensApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md) | [*DeleteToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md#deletetoken) | 
[*TokensApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md) | [*GetToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md#gettoken) | 
[*TokensApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md) | [*ListProjectsOfToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md#listprojectsoftoken) | 
[*TokensApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md) | [*ListToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md#listtoken) | 
[*TokensApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md) | [*UpdateToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokensApi.md#updatetoken) | 
[*WellKnownApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/WellKnownApi.md) | [*GetWellKnownDid*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/WellKnownApi.md#getwellknowndid) | 
[*WellKnownApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/WellKnownApi.md) | [*GetWellKnownJwks*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/WellKnownApi.md#getwellknownjwks) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [ActionForbiddenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ActionForbiddenError.md)
 - [AddUserToProjectInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/AddUserToProjectInput.md)
 - [ConsumerAuthTokenEndpointInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ConsumerAuthTokenEndpointInput.md)
 - [ConsumerAuthTokenEndpointOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ConsumerAuthTokenEndpointOutput.md)
 - [CorsConsumerAuthTokenEndpointOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/CorsConsumerAuthTokenEndpointOK.md)
 - [CorsGrantAccessVfsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/CorsGrantAccessVfsOK.md)
 - [CorsUpdateAccessVfsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/CorsUpdateAccessVfsOK.md)
 - [CreateProjectInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/CreateProjectInput.md)
 - [CreateProjectScopedTokenInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/CreateProjectScopedTokenInput.md)
 - [CreateProjectScopedTokenOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/CreateProjectScopedTokenOutput.md)
 - [CreateTokenInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/CreateTokenInput.md)
 - [DeleteAccessOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/DeleteAccessOutput.md)
 - [GrantAccessInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/GrantAccessInput.md)
 - [GrantAccessOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/GrantAccessOutput.md)
 - [InvalidDIDError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/InvalidDIDError.md)
 - [InvalidJwtTokenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/InvalidJwtTokenError.md)
 - [InvalidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/InvalidParameterError.md)
 - [JsonWebKeyDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/JsonWebKeyDto.md)
 - [JsonWebKeySetDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/JsonWebKeySetDto.md)
 - [NotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/NotFoundError.md)
 - [PolicyDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PolicyDto.md)
 - [PolicyStatementDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PolicyStatementDto.md)
 - [PrincipalCannotBeDeletedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PrincipalCannotBeDeletedError.md)
 - [PrincipalDoesNotBelongToProjectError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PrincipalDoesNotBelongToProjectError.md)
 - [ProjectDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectDto.md)
 - [ProjectList](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectList.md)
 - [ProjectWithPolicyDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectWithPolicyDto.md)
 - [ProjectWithPolicyList](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ProjectWithPolicyList.md)
 - [PublicKeyCannotBeResolvedFromDidError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/PublicKeyCannotBeResolvedFromDidError.md)
 - [RightsEnum](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/RightsEnum.md)
 - [ServiceErrorResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ServiceErrorResponse.md)
 - [ServiceErrorResponseDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/ServiceErrorResponseDetailsInner.md)
 - [TokenDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokenDto.md)
 - [TokenList](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokenList.md)
 - [TokenPrivateKeyAuthenticationMethodDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokenPrivateKeyAuthenticationMethodDto.md)
 - [TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfo](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfo.md)
 - [TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfoOneOf](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfoOneOf.md)
 - [TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfoOneOf1](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TokenPrivateKeyAuthenticationMethodDtoPublicKeyInfoOneOf1.md)
 - [TypedPrincipalId](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/TypedPrincipalId.md)
 - [UnauthorizedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UnauthorizedError.md)
 - [UnexpectedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UnexpectedError.md)
 - [UpdateAccessInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UpdateAccessInput.md)
 - [UpdateAccessOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UpdateAccessOutput.md)
 - [UpdateProjectInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UpdateProjectInput.md)
 - [UpdateTokenInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UpdateTokenInput.md)
 - [UpdateTokenPrivateKeyAuthenticationMethodDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UpdateTokenPrivateKeyAuthenticationMethodDto.md)
 - [UserDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UserDto.md)
 - [UserList](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/UserList.md)
 - [WhoamiDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IamClient/docs/WhoamiDto.md)



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


