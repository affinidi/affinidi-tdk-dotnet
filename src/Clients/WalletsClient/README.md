# Affinidi TDK .NET client for Wallets

Affinidi TDK dotnet client for Affinidi WALLETS


## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (minimum version: **8.0.400**)  


Check your installed version:

```bash
dotnet --version
```

### Installation

These are the steps to get you started with a dotnet project and integration with **AffinidiTdk.WalletsClient**. 
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.WalletsClient))**

```bash
dotnet add package AffinidiTdk.WalletsClient
```



## Usage

The **AffinidiTdk.WalletsClient** uses authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package which is also available in [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).

> To generate a token, you first need to create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat).

1. **Import the required dependencies**

The dependencies required may differ based on the Client API used in your application. 


```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;
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


RevocationApi api = new RevocationApi(config);

var projectId = "projectId_example";
var walletId = "walletId_example";
var statusId = "statusId_example";

GetRevocationListCredentialResultDto result = api.GetRevocationCredentialStatus(projectId, walletId, statusId);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/wallets).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


## Documentation

### Client API Documentation

ClientAPI | Operation | Description
------------ | ------------- | -------------
[*RevocationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/RevocationApi.md) | [*GetRevocationCredentialStatus*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/RevocationApi.md#getrevocationcredentialstatus) | 
[*RevocationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/RevocationApi.md) | [*GetRevocationListCredential*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/RevocationApi.md#getrevocationlistcredential) | Return revocation list credential.
[*RevocationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/RevocationApi.md) | [*RevokeCredential*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/RevocationApi.md#revokecredential) | Revoke Credential.
[*WalletApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md) | [*CreateWallet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md#createwallet) | 
[*WalletApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md) | [*DeleteWallet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md#deletewallet) | 
[*WalletApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md) | [*GetWallet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md#getwallet) | 
[*WalletApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md) | [*ListWallets*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md#listwallets) | 
[*WalletApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md) | [*SignCredential*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md#signcredential) | 
[*WalletApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md) | [*SignJwtToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md#signjwttoken) | 
[*WalletApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md) | [*UpdateWallet*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletApi.md#updatewallet) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [CreateWalletInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/CreateWalletInput.md)
 - [CreateWalletResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/CreateWalletResponse.md)
 - [CreateWalletV2Input](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/CreateWalletV2Input.md)
 - [CreateWalletV2Response](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/CreateWalletV2Response.md)
 - [EntityNotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/EntityNotFoundError.md)
 - [GetRevocationCredentialStatusOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/GetRevocationCredentialStatusOK.md)
 - [GetRevocationListCredentialResultDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/GetRevocationListCredentialResultDto.md)
 - [InvalidDidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/InvalidDidParameterError.md)
 - [InvalidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/InvalidParameterError.md)
 - [KeyNotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/KeyNotFoundError.md)
 - [NotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/NotFoundError.md)
 - [OperationForbiddenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/OperationForbiddenError.md)
 - [RevokeCredentialInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/RevokeCredentialInput.md)
 - [ServiceErrorResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/ServiceErrorResponse.md)
 - [ServiceErrorResponseDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/ServiceErrorResponseDetailsInner.md)
 - [SignCredential400Response](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredential400Response.md)
 - [SignCredentialInputDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialInputDto.md)
 - [SignCredentialInputDtoUnsignedCredentialParams](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialInputDtoUnsignedCredentialParams.md)
 - [SignCredentialResultDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialResultDto.md)
 - [SignCredentialsDm1LdInputDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialsDm1LdInputDto.md)
 - [SignCredentialsDm1LdResultDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialsDm1LdResultDto.md)
 - [SignCredentialsDm2SdJwtInputDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialsDm2SdJwtInputDto.md)
 - [SignCredentialsDm2SdJwtResultDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialsDm2SdJwtResultDto.md)
 - [SignCredentialsJwtInputDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialsJwtInputDto.md)
 - [SignCredentialsJwtResultDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialsJwtResultDto.md)
 - [SignCredentialsLdpInputDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialsLdpInputDto.md)
 - [SignCredentialsLdpResultDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignCredentialsLdpResultDto.md)
 - [SignJwtToken](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignJwtToken.md)
 - [SignJwtTokenOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignJwtTokenOK.md)
 - [SignPresentationLdpInputDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignPresentationLdpInputDto.md)
 - [SignPresentationLdpResultDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SignPresentationLdpResultDto.md)
 - [SigningFailedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/SigningFailedError.md)
 - [UpdateWalletInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/UpdateWalletInput.md)
 - [WalletDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletDto.md)
 - [WalletDtoKeysInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletDtoKeysInner.md)
 - [WalletV2Dto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletV2Dto.md)
 - [WalletsListDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient/docs/WalletsListDto.md)



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


