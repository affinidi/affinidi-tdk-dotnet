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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.VaultDataManagerClient))**

```bash
dotnet add package AffinidiTdk.VaultDataManagerClient
```



## Usage

The **AffinidiTdk.VaultDataManagerClient** uses authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package which is also available in [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).

> To generate a token, you first need to create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat).

1. **Import the required dependencies**

The dependencies required may differ based on the Client API used in your application. 


```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.VaultDataManagerClient.Api;
using AffinidiTdk.VaultDataManagerClient.Client;
using AffinidiTdk.VaultDataManagerClient.Model;
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


AccountsApi api = new AccountsApi(config);

var createAccountInput = new CreateAccountInput();

CreateAccountOK result = api.CreateAccount(createAccountInput);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/vault-data-manager).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


## Documentation

### Client API Documentation

ClientAPI | Operation | Description
------------ | ------------- | -------------
[*AccountsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountsApi.md) | [*CreateAccount*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountsApi.md#createaccount) | 
[*AccountsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountsApi.md) | [*DeleteAccount*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountsApi.md#deleteaccount) | 
[*AccountsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountsApi.md) | [*ListAccounts*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountsApi.md#listaccounts) | 
[*AccountsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountsApi.md) | [*UpdateAccount*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountsApi.md#updateaccount) | 
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ConfigurationApi.md) | [*GetConfiguration*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ConfigurationApi.md#getconfiguration) | 
[*FilesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/FilesApi.md) | [*GetScannedFileInfo*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/FilesApi.md#getscannedfileinfo) | 
[*FilesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/FilesApi.md) | [*ListScannedFiles*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/FilesApi.md#listscannedfiles) | 
[*FilesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/FilesApi.md) | [*StartFileScan*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/FilesApi.md#startfilescan) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*CreateChildNode*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#createchildnode) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*CreateNode*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#createnode) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*DeleteNode*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#deletenode) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*GetDetailedNodeInfo*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#getdetailednodeinfo) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*InitNodes*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#initnodes) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*ListNodeChildren*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#listnodechildren) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*ListRootNodeChildren*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#listrootnodechildren) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*MoveNode*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#movenode) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*PermanentlyDeleteNode*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#permanentlydeletenode) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*RestoreNodeFromTrashbin*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#restorenodefromtrashbin) | 
[*NodesApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md) | [*UpdateNode*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodesApi.md#updatenode) | 
[*ProfileDataApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ProfileDataApi.md) | [*QueryProfileData*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ProfileDataApi.md#queryprofiledata) | 
[*ProfileDataApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ProfileDataApi.md) | [*UpdateProfileData*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ProfileDataApi.md#updateprofiledata) | 
[*WellKnownApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/WellKnownApi.md) | [*GetWellKnownJwks*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/WellKnownApi.md#getwellknownjwks) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [AccountDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AccountDto.md)
 - [AwsCredentialExchangeOperationOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/AwsCredentialExchangeOperationOK.md)
 - [ConsumerMetadataDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ConsumerMetadataDto.md)
 - [CorsAwsCredentialExchangeOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsAwsCredentialExchangeOK.md)
 - [CorsDeleteAccountOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsDeleteAccountOK.md)
 - [CorsDeleteNodeOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsDeleteNodeOK.md)
 - [CorsGetConfigOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsGetConfigOK.md)
 - [CorsGetConfigurationOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsGetConfigurationOK.md)
 - [CorsGetScannedFileInfoOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsGetScannedFileInfoOK.md)
 - [CorsGetWellKnownJwksOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsGetWellKnownJwksOK.md)
 - [CorsInitNodesOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsInitNodesOK.md)
 - [CorsListAccountsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsListAccountsOK.md)
 - [CorsListNodeChildrenOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsListNodeChildrenOK.md)
 - [CorsListRootNodeChildrenOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsListRootNodeChildrenOK.md)
 - [CorsListScannedFilesOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsListScannedFilesOK.md)
 - [CorsMoveNodeOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsMoveNodeOK.md)
 - [CorsPermanentlyDeleteNodeOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsPermanentlyDeleteNodeOK.md)
 - [CorsRestoreNodeFromTrashbinOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsRestoreNodeFromTrashbinOK.md)
 - [CorsStartFileScanOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsStartFileScanOK.md)
 - [CorsUpdateProfileDataOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CorsUpdateProfileDataOK.md)
 - [CreateAccountInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CreateAccountInput.md)
 - [CreateAccountOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CreateAccountOK.md)
 - [CreateChildNodeInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CreateChildNodeInput.md)
 - [CreateNodeInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CreateNodeInput.md)
 - [CreateNodeOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/CreateNodeOK.md)
 - [DeleteAccountDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/DeleteAccountDto.md)
 - [DeleteNodeDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/DeleteNodeDto.md)
 - [EdekInfo](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/EdekInfo.md)
 - [GetConfigOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/GetConfigOK.md)
 - [GetDetailedNodeInfoOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/GetDetailedNodeInfoOK.md)
 - [GetScannedFileInfoOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/GetScannedFileInfoOK.md)
 - [InitNodesOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/InitNodesOK.md)
 - [InvalidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/InvalidParameterError.md)
 - [InvalidParameterErrorDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/InvalidParameterErrorDetailsInner.md)
 - [JsonWebKeyDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/JsonWebKeyDto.md)
 - [JsonWebKeySetDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/JsonWebKeySetDto.md)
 - [ListAccountsDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ListAccountsDto.md)
 - [ListNodeChildrenOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ListNodeChildrenOK.md)
 - [ListRootNodeChildrenOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ListRootNodeChildrenOK.md)
 - [ListScannedFilesOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ListScannedFilesOK.md)
 - [ListScannedFilesOKScannedFilesInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/ListScannedFilesOKScannedFilesInner.md)
 - [MoveNodeDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/MoveNodeDto.md)
 - [MoveNodeInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/MoveNodeInput.md)
 - [NodeDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodeDto.md)
 - [NodeStatus](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodeStatus.md)
 - [NodeType](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NodeType.md)
 - [NotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/NotFoundError.md)
 - [QueryProfileDataOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/QueryProfileDataOK.md)
 - [RestoreNodeFromTrashbin](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/RestoreNodeFromTrashbin.md)
 - [StartFileScanInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/StartFileScanInput.md)
 - [StartFileScanOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/StartFileScanOK.md)
 - [UnexpectedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/UnexpectedError.md)
 - [UpdateAccountDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/UpdateAccountDto.md)
 - [UpdateAccountInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/UpdateAccountInput.md)
 - [UpdateNodeInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/UpdateNodeInput.md)
 - [UpdateProfileDataInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/UpdateProfileDataInput.md)
 - [UpdateProfileDataOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/VaultDataManagerClient/docs/UpdateProfileDataOK.md)



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


