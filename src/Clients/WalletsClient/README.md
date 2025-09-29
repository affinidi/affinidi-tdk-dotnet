<a id="top"></a>
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.WalletsClient))**

```bash
dotnet add package AffinidiTdk.WalletsClient
```

<p align="right">(<a href="#top">back to top</a>)</p>


## Usage

1. **Import the required dependencies**

The dependencies required may differ based on the Client Api used in your application. 

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;
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

<p align="right">(<a href="#top">back to top</a>)</p>


## Documentation

### Client Api Documentation

ClientApi | Operation | Description
------------ | ------------- | -------------
[*RevocationApi*](docs/RevocationApi.md) | [*GetRevocationCredentialStatus*](docs/RevocationApi.md#getrevocationcredentialstatus) | 
[*RevocationApi*](docs/RevocationApi.md) | [*GetRevocationListCredential*](docs/RevocationApi.md#getrevocationlistcredential) | Return revocation list credential.
[*RevocationApi*](docs/RevocationApi.md) | [*RevokeCredential*](docs/RevocationApi.md#revokecredential) | Revoke Credential.
[*WalletApi*](docs/WalletApi.md) | [*CreateWallet*](docs/WalletApi.md#createwallet) | 
[*WalletApi*](docs/WalletApi.md) | [*DeleteWallet*](docs/WalletApi.md#deletewallet) | 
[*WalletApi*](docs/WalletApi.md) | [*GetWallet*](docs/WalletApi.md#getwallet) | 
[*WalletApi*](docs/WalletApi.md) | [*ListWallets*](docs/WalletApi.md#listwallets) | 
[*WalletApi*](docs/WalletApi.md) | [*SignCredential*](docs/WalletApi.md#signcredential) | 
[*WalletApi*](docs/WalletApi.md) | [*SignJwtToken*](docs/WalletApi.md#signjwttoken) | 
[*WalletApi*](docs/WalletApi.md) | [*UpdateWallet*](docs/WalletApi.md#updatewallet) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [CreateWalletInput](docs/CreateWalletInput.md)
 - [CreateWalletResponse](docs/CreateWalletResponse.md)
 - [EntityNotFoundError](docs/EntityNotFoundError.md)
 - [GetRevocationCredentialStatusOK](docs/GetRevocationCredentialStatusOK.md)
 - [GetRevocationListCredentialResultDto](docs/GetRevocationListCredentialResultDto.md)
 - [InvalidDidParameterError](docs/InvalidDidParameterError.md)
 - [InvalidParameterError](docs/InvalidParameterError.md)
 - [KeyNotFoundError](docs/KeyNotFoundError.md)
 - [NotFoundError](docs/NotFoundError.md)
 - [OperationForbiddenError](docs/OperationForbiddenError.md)
 - [RevokeCredentialInput](docs/RevokeCredentialInput.md)
 - [ServiceErrorResponse](docs/ServiceErrorResponse.md)
 - [ServiceErrorResponseDetailsInner](docs/ServiceErrorResponseDetailsInner.md)
 - [SignCredential400Response](docs/SignCredential400Response.md)
 - [SignCredentialInputDto](docs/SignCredentialInputDto.md)
 - [SignCredentialInputDtoUnsignedCredentialParams](docs/SignCredentialInputDtoUnsignedCredentialParams.md)
 - [SignCredentialResultDto](docs/SignCredentialResultDto.md)
 - [SignCredentialsDm1JwtInputDto](docs/SignCredentialsDm1JwtInputDto.md)
 - [SignCredentialsDm1JwtResultDto](docs/SignCredentialsDm1JwtResultDto.md)
 - [SignCredentialsDm1LdInputDto](docs/SignCredentialsDm1LdInputDto.md)
 - [SignCredentialsDm1LdResultDto](docs/SignCredentialsDm1LdResultDto.md)
 - [SignCredentialsDm2LdInputDto](docs/SignCredentialsDm2LdInputDto.md)
 - [SignCredentialsDm2LdResultDto](docs/SignCredentialsDm2LdResultDto.md)
 - [SignCredentialsDm2SdJwtInputDto](docs/SignCredentialsDm2SdJwtInputDto.md)
 - [SignCredentialsDm2SdJwtResultDto](docs/SignCredentialsDm2SdJwtResultDto.md)
 - [SignJwtToken](docs/SignJwtToken.md)
 - [SignJwtTokenOK](docs/SignJwtTokenOK.md)
 - [SignPresentationLdpInputDto](docs/SignPresentationLdpInputDto.md)
 - [SignPresentationLdpResultDto](docs/SignPresentationLdpResultDto.md)
 - [SigningFailedError](docs/SigningFailedError.md)
 - [UpdateWalletInput](docs/UpdateWalletInput.md)
 - [WalletDto](docs/WalletDto.md)
 - [WalletDtoKeysInner](docs/WalletDtoKeysInner.md)
 - [WalletsListDto](docs/WalletsListDto.md)


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
