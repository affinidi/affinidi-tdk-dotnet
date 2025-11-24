# Affinidi TDK .NET client for ConsumerIam

Affinidi TDK dotnet client for Affinidi CONSUMER IAM


## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (minimum version: **8.0.400**)  


Check your installed version:

```bash
dotnet --version
```

### Installation

These are the steps to get you started with a dotnet project and integration with **AffinidiTdk.ConsumerIamClient**. 
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.ConsumerIamClient))**

```bash
dotnet add package AffinidiTdk.ConsumerIamClient
```



## Usage

The **AffinidiTdk.ConsumerIamClient** uses authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package which is also available in [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).

> To generate a token, you first need to create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat).

1. **Import the required dependencies**

The dependencies required may differ based on the Client API used in your application. 


```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.ConsumerIamClient.Api;
using AffinidiTdk.ConsumerIamClient.Client;
using AffinidiTdk.ConsumerIamClient.Model;
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


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/consumer-iam).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


## Documentation

### Client API Documentation

ClientAPI | Operation | Description
------------ | ------------- | -------------
[*AuthzApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/AuthzApi.md) | [*DeleteAccessVfs*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/AuthzApi.md#deleteaccessvfs) | delete access of granteeDid
[*AuthzApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/AuthzApi.md) | [*GrantAccessVfs*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/AuthzApi.md#grantaccessvfs) | Grant access to the virtual file system
[*AuthzApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/AuthzApi.md) | [*UpdateAccessVfs*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/AuthzApi.md#updateaccessvfs) | Update access of granteeDid
[*ConsumerAuthApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/ConsumerAuthApi.md) | [*ConsumerAuthTokenEndpoint*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/ConsumerAuthApi.md#consumerauthtokenendpoint) | The Consumer OAuth 2.0 Token Endpoint
[*WellKnownApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/WellKnownApi.md) | [*GetWellKnownJwks*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/WellKnownApi.md#getwellknownjwks) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [ConsumerAuthTokenEndpointInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/ConsumerAuthTokenEndpointInput.md)
 - [ConsumerAuthTokenEndpointOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/ConsumerAuthTokenEndpointOutput.md)
 - [CorsConsumerAuthTokenEndpointOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/CorsConsumerAuthTokenEndpointOK.md)
 - [GrantAccessInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/GrantAccessInput.md)
 - [GrantAccessOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/GrantAccessOutput.md)
 - [InvalidDIDError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/InvalidDIDError.md)
 - [InvalidJwtTokenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/InvalidJwtTokenError.md)
 - [InvalidJwtTokenErrorDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/InvalidJwtTokenErrorDetailsInner.md)
 - [InvalidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/InvalidParameterError.md)
 - [JsonWebKeyDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/JsonWebKeyDto.md)
 - [JsonWebKeySetDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/JsonWebKeySetDto.md)
 - [Permission](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/Permission.md)
 - [RightsEnum](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/RightsEnum.md)
 - [UnauthorizedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/UnauthorizedError.md)
 - [UnexpectedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/UnexpectedError.md)
 - [UpdateAccessInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/UpdateAccessInput.md)
 - [UpdateAccessOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/ConsumerIamClient/docs/UpdateAccessOutput.md)



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


