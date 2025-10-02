<a id="top"></a>
# Affinidi TDK .NET client for VaultDataManager

Affinidi TDK dotnet client for Affinidi VAULT DATA MANAGER


## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (minimum version: **8.0.400**)  


Check your installed version:

```bash
dotnet --version
```

### Installation

These are the steps to get you started with a dotnet project and integration with **AffinidiTdk.VaultDataManagerClient**. 
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.VaultDataManagerClient))**

```bash
dotnet add package AffinidiTdk.VaultDataManagerClient
```

<p align="right">(<a href="#top">back to top</a>)</p>


## Usage

1. **Import the required dependencies**

The dependencies required may differ based on the Client Api used in your application. 

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.VaultDataManagerClient.Api;
using AffinidiTdk.VaultDataManagerClient.Client;
using AffinidiTdk.VaultDataManagerClient.Model;
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


AccountsApi api = new AccountsApi(config);

var createAccountInput = new CreateAccountInput();

CreateAccountOK result = api.CreateAccount(createAccountInput);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/vault-data-manager).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.

<p align="right">(<a href="#top">back to top</a>)</p>


## Documentation

### Client Api Documentation

ClientApi | Operation | Description
------------ | ------------- | -------------
[*AccountsApi*](docs/AccountsApi.md) | [*CreateAccount*](docs/AccountsApi.md#createaccount) | 
[*AccountsApi*](docs/AccountsApi.md) | [*DeleteAccount*](docs/AccountsApi.md#deleteaccount) | 
[*AccountsApi*](docs/AccountsApi.md) | [*ListAccounts*](docs/AccountsApi.md#listaccounts) | 
[*AccountsApi*](docs/AccountsApi.md) | [*UpdateAccount*](docs/AccountsApi.md#updateaccount) | 
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*GetConfiguration*](docs/ConfigurationApi.md#getconfiguration) | 
[*FilesApi*](docs/FilesApi.md) | [*GetScannedFileInfo*](docs/FilesApi.md#getscannedfileinfo) | 
[*FilesApi*](docs/FilesApi.md) | [*ListScannedFiles*](docs/FilesApi.md#listscannedfiles) | 
[*FilesApi*](docs/FilesApi.md) | [*StartFileScan*](docs/FilesApi.md#startfilescan) | 
[*NodesApi*](docs/NodesApi.md) | [*CreateChildNode*](docs/NodesApi.md#createchildnode) | 
[*NodesApi*](docs/NodesApi.md) | [*CreateNode*](docs/NodesApi.md#createnode) | 
[*NodesApi*](docs/NodesApi.md) | [*DeleteNode*](docs/NodesApi.md#deletenode) | 
[*NodesApi*](docs/NodesApi.md) | [*GetDetailedNodeInfo*](docs/NodesApi.md#getdetailednodeinfo) | 
[*NodesApi*](docs/NodesApi.md) | [*InitNodes*](docs/NodesApi.md#initnodes) | 
[*NodesApi*](docs/NodesApi.md) | [*ListNodeChildren*](docs/NodesApi.md#listnodechildren) | 
[*NodesApi*](docs/NodesApi.md) | [*ListRootNodeChildren*](docs/NodesApi.md#listrootnodechildren) | 
[*NodesApi*](docs/NodesApi.md) | [*MoveNode*](docs/NodesApi.md#movenode) | 
[*NodesApi*](docs/NodesApi.md) | [*PermanentlyDeleteNode*](docs/NodesApi.md#permanentlydeletenode) | 
[*NodesApi*](docs/NodesApi.md) | [*RestoreNodeFromTrashbin*](docs/NodesApi.md#restorenodefromtrashbin) | 
[*NodesApi*](docs/NodesApi.md) | [*UpdateNode*](docs/NodesApi.md#updatenode) | 
[*ProfileDataApi*](docs/ProfileDataApi.md) | [*QueryProfileData*](docs/ProfileDataApi.md#queryprofiledata) | 
[*ProfileDataApi*](docs/ProfileDataApi.md) | [*UpdateProfileData*](docs/ProfileDataApi.md#updateprofiledata) | 
[*WellKnownApi*](docs/WellKnownApi.md) | [*GetWellKnownJwks*](docs/WellKnownApi.md#getwellknownjwks) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [AccountDto](docs/AccountDto.md)
 - [AwsCredentialExchangeOperationOK](docs/AwsCredentialExchangeOperationOK.md)
 - [ConsumerMetadataDto](docs/ConsumerMetadataDto.md)
 - [CorsAwsCredentialExchangeOK](docs/CorsAwsCredentialExchangeOK.md)
 - [CorsDeleteAccountOK](docs/CorsDeleteAccountOK.md)
 - [CorsDeleteNodeOK](docs/CorsDeleteNodeOK.md)
 - [CorsGetConfigOK](docs/CorsGetConfigOK.md)
 - [CorsGetConfigurationOK](docs/CorsGetConfigurationOK.md)
 - [CorsGetScannedFileInfoOK](docs/CorsGetScannedFileInfoOK.md)
 - [CorsGetWellKnownJwksOK](docs/CorsGetWellKnownJwksOK.md)
 - [CorsInitNodesOK](docs/CorsInitNodesOK.md)
 - [CorsListAccountsOK](docs/CorsListAccountsOK.md)
 - [CorsListNodeChildrenOK](docs/CorsListNodeChildrenOK.md)
 - [CorsListRootNodeChildrenOK](docs/CorsListRootNodeChildrenOK.md)
 - [CorsListScannedFilesOK](docs/CorsListScannedFilesOK.md)
 - [CorsMoveNodeOK](docs/CorsMoveNodeOK.md)
 - [CorsPermanentlyDeleteNodeOK](docs/CorsPermanentlyDeleteNodeOK.md)
 - [CorsRestoreNodeFromTrashbinOK](docs/CorsRestoreNodeFromTrashbinOK.md)
 - [CorsStartFileScanOK](docs/CorsStartFileScanOK.md)
 - [CorsUpdateProfileDataOK](docs/CorsUpdateProfileDataOK.md)
 - [CreateAccountInput](docs/CreateAccountInput.md)
 - [CreateAccountOK](docs/CreateAccountOK.md)
 - [CreateChildNodeInput](docs/CreateChildNodeInput.md)
 - [CreateNodeInput](docs/CreateNodeInput.md)
 - [CreateNodeOK](docs/CreateNodeOK.md)
 - [DeleteAccountDto](docs/DeleteAccountDto.md)
 - [DeleteNodeDto](docs/DeleteNodeDto.md)
 - [EdekInfo](docs/EdekInfo.md)
 - [GetConfigOK](docs/GetConfigOK.md)
 - [GetDetailedNodeInfoOK](docs/GetDetailedNodeInfoOK.md)
 - [GetScannedFileInfoOK](docs/GetScannedFileInfoOK.md)
 - [InitNodesOK](docs/InitNodesOK.md)
 - [InvalidParameterError](docs/InvalidParameterError.md)
 - [InvalidParameterErrorDetailsInner](docs/InvalidParameterErrorDetailsInner.md)
 - [JsonWebKeyDto](docs/JsonWebKeyDto.md)
 - [JsonWebKeySetDto](docs/JsonWebKeySetDto.md)
 - [ListAccountsDto](docs/ListAccountsDto.md)
 - [ListNodeChildrenOK](docs/ListNodeChildrenOK.md)
 - [ListRootNodeChildrenOK](docs/ListRootNodeChildrenOK.md)
 - [ListScannedFilesOK](docs/ListScannedFilesOK.md)
 - [ListScannedFilesOKScannedFilesInner](docs/ListScannedFilesOKScannedFilesInner.md)
 - [MoveNodeDto](docs/MoveNodeDto.md)
 - [MoveNodeInput](docs/MoveNodeInput.md)
 - [NodeDto](docs/NodeDto.md)
 - [NodeStatus](docs/NodeStatus.md)
 - [NodeType](docs/NodeType.md)
 - [NotFoundError](docs/NotFoundError.md)
 - [QueryProfileDataOK](docs/QueryProfileDataOK.md)
 - [RestoreNodeFromTrashbin](docs/RestoreNodeFromTrashbin.md)
 - [StartFileScanInput](docs/StartFileScanInput.md)
 - [StartFileScanOK](docs/StartFileScanOK.md)
 - [UnexpectedError](docs/UnexpectedError.md)
 - [UpdateAccountDto](docs/UpdateAccountDto.md)
 - [UpdateAccountInput](docs/UpdateAccountInput.md)
 - [UpdateNodeInput](docs/UpdateNodeInput.md)
 - [UpdateProfileDataInput](docs/UpdateProfileDataInput.md)
 - [UpdateProfileDataOK](docs/UpdateProfileDataOK.md)


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
