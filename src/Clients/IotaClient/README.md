<a id="top"></a>
# Affinidi TDK .NET client for Iota

Affinidi TDK dotnet client for Affinidi IOTA


## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (minimum version: **8.0.400**)  


Check your installed version:

```bash
dotnet --version
```

### Installation

These are the steps to get you started with a dotnet project and integration with **AffinidiTdk.IotaClient**. 
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.IotaClient))**

```bash
dotnet add package AffinidiTdk.IotaClient
```

<p align="right">(<a href="#top">back to top</a>)</p>


## Usage

1. **Import the required dependencies**

The dependencies required may differ based on the Client Api used in your application. 

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.IotaClient.Api;
using AffinidiTdk.IotaClient.Client;
using AffinidiTdk.IotaClient.Model;
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


CallbackApi api = new CallbackApi(config);

var callbackInput = new CallbackInput();

CallbackResponseOK result = api.IotOIDC4VPCallback(callbackInput);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/iota-framework).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.

<p align="right">(<a href="#top">back to top</a>)</p>


## Documentation

### Client Api Documentation

ClientApi | Operation | Description
------------ | ------------- | -------------
[*CallbackApi*](docs/CallbackApi.md) | [*IotOIDC4VPCallback*](docs/CallbackApi.md#iotoidc4vpcallback) | 
[*ConfigurationsApi*](docs/ConfigurationsApi.md) | [*CreateIotaConfiguration*](docs/ConfigurationsApi.md#createiotaconfiguration) | 
[*ConfigurationsApi*](docs/ConfigurationsApi.md) | [*DeleteIotaConfigurationById*](docs/ConfigurationsApi.md#deleteiotaconfigurationbyid) | 
[*ConfigurationsApi*](docs/ConfigurationsApi.md) | [*GetIotaConfigurationById*](docs/ConfigurationsApi.md#getiotaconfigurationbyid) | 
[*ConfigurationsApi*](docs/ConfigurationsApi.md) | [*GetIotaConfigurationMetaData*](docs/ConfigurationsApi.md#getiotaconfigurationmetadata) | 
[*ConfigurationsApi*](docs/ConfigurationsApi.md) | [*ListIotaConfigurations*](docs/ConfigurationsApi.md#listiotaconfigurations) | 
[*ConfigurationsApi*](docs/ConfigurationsApi.md) | [*UpdateIotaConfigurationById*](docs/ConfigurationsApi.md#updateiotaconfigurationbyid) | 
[*DefaultApi*](docs/DefaultApi.md) | [*ListLoggedConsents*](docs/DefaultApi.md#listloggedconsents) | 
[*IotaApi*](docs/IotaApi.md) | [*AwsExchangeCredentials*](docs/IotaApi.md#awsexchangecredentials) | 
[*IotaApi*](docs/IotaApi.md) | [*AwsExchangeCredentialsProjectToken*](docs/IotaApi.md#awsexchangecredentialsprojecttoken) | 
[*IotaApi*](docs/IotaApi.md) | [*FetchIotaVpResponse*](docs/IotaApi.md#fetchiotavpresponse) | 
[*IotaApi*](docs/IotaApi.md) | [*InitiateDataSharingRequest*](docs/IotaApi.md#initiatedatasharingrequest) | 
[*IotaApi*](docs/IotaApi.md) | [*IotaExchangeCredentials*](docs/IotaApi.md#iotaexchangecredentials) | 
[*PexQueryApi*](docs/PexQueryApi.md) | [*CreatePexQuery*](docs/PexQueryApi.md#createpexquery) | 
[*PexQueryApi*](docs/PexQueryApi.md) | [*DeletePexQueries*](docs/PexQueryApi.md#deletepexqueries) | 
[*PexQueryApi*](docs/PexQueryApi.md) | [*DeletePexQueryById*](docs/PexQueryApi.md#deletepexquerybyid) | 
[*PexQueryApi*](docs/PexQueryApi.md) | [*GetPexQueryById*](docs/PexQueryApi.md#getpexquerybyid) | 
[*PexQueryApi*](docs/PexQueryApi.md) | [*ListPexQueries*](docs/PexQueryApi.md#listpexqueries) | 
[*PexQueryApi*](docs/PexQueryApi.md) | [*SavePexQueries*](docs/PexQueryApi.md#savepexqueries) | 
[*PexQueryApi*](docs/PexQueryApi.md) | [*UpdatePexQueryById*](docs/PexQueryApi.md#updatepexquerybyid) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [AlreadyExistsError](docs/AlreadyExistsError.md)
 - [AwsExchangeCredentials](docs/AwsExchangeCredentials.md)
 - [AwsExchangeCredentialsOK](docs/AwsExchangeCredentialsOK.md)
 - [AwsExchangeCredentialsProjectToken](docs/AwsExchangeCredentialsProjectToken.md)
 - [AwsExchangeCredentialsProjectTokenOK](docs/AwsExchangeCredentialsProjectTokenOK.md)
 - [AwsExchangeCredentialsProjectTokenOKCredentials](docs/AwsExchangeCredentialsProjectTokenOKCredentials.md)
 - [CallbackInput](docs/CallbackInput.md)
 - [CallbackResponseOK](docs/CallbackResponseOK.md)
 - [ConsentDto](docs/ConsentDto.md)
 - [CorsAwsExchangeCredentialsOK](docs/CorsAwsExchangeCredentialsOK.md)
 - [CorsAwsExchangeCredentialsProjectTokenOK](docs/CorsAwsExchangeCredentialsProjectTokenOK.md)
 - [CorsFetchIotaVpResponseOK](docs/CorsFetchIotaVpResponseOK.md)
 - [CorsInitiateDataSharingRequestOK](docs/CorsInitiateDataSharingRequestOK.md)
 - [CorsIotOidc4vpcallbackOK](docs/CorsIotOidc4vpcallbackOK.md)
 - [CorsIotaExchangeCredentialsOK](docs/CorsIotaExchangeCredentialsOK.md)
 - [CreateDcqlQueryInput](docs/CreateDcqlQueryInput.md)
 - [CreateIotaConfigurationInput](docs/CreateIotaConfigurationInput.md)
 - [CreatePexQueryInput](docs/CreatePexQueryInput.md)
 - [DcqlQueryDto](docs/DcqlQueryDto.md)
 - [DeletePexQueriesInput](docs/DeletePexQueriesInput.md)
 - [FetchIOTAVPResponseInput](docs/FetchIOTAVPResponseInput.md)
 - [FetchIOTAVPResponseOK](docs/FetchIOTAVPResponseOK.md)
 - [GetIotaConfigurationMetaDataOK](docs/GetIotaConfigurationMetaDataOK.md)
 - [InitiateDataSharingRequestInput](docs/InitiateDataSharingRequestInput.md)
 - [InitiateDataSharingRequestOK](docs/InitiateDataSharingRequestOK.md)
 - [InitiateDataSharingRequestOKData](docs/InitiateDataSharingRequestOKData.md)
 - [InvalidParameterError](docs/InvalidParameterError.md)
 - [InvalidParameterErrorDetailsInner](docs/InvalidParameterErrorDetailsInner.md)
 - [IotaConfigurationDto](docs/IotaConfigurationDto.md)
 - [IotaConfigurationDtoClientMetadata](docs/IotaConfigurationDtoClientMetadata.md)
 - [IotaExchangeCredentials](docs/IotaExchangeCredentials.md)
 - [IotaExchangeCredentialsOK](docs/IotaExchangeCredentialsOK.md)
 - [IotaExchangeCredentialsOKCredentials](docs/IotaExchangeCredentialsOKCredentials.md)
 - [ListConfigurationOK](docs/ListConfigurationOK.md)
 - [ListDcqlQueriesOK](docs/ListDcqlQueriesOK.md)
 - [ListLoggedConsentsOK](docs/ListLoggedConsentsOK.md)
 - [ListPexQueriesOK](docs/ListPexQueriesOK.md)
 - [MessagePublishingError](docs/MessagePublishingError.md)
 - [NotFoundError](docs/NotFoundError.md)
 - [OperationForbiddenError](docs/OperationForbiddenError.md)
 - [PexQueryDto](docs/PexQueryDto.md)
 - [PrepareRequest](docs/PrepareRequest.md)
 - [PrepareRequestCreated](docs/PrepareRequestCreated.md)
 - [PrepareRequestCreatedData](docs/PrepareRequestCreatedData.md)
 - [ResourceLimitExceededError](docs/ResourceLimitExceededError.md)
 - [SavePexQueriesUpdateInput](docs/SavePexQueriesUpdateInput.md)
 - [SavePexQueriesUpdateInputQueriesInner](docs/SavePexQueriesUpdateInputQueriesInner.md)
 - [UpdateConfigurationByIdInput](docs/UpdateConfigurationByIdInput.md)
 - [UpdateConfigurationByIdOK](docs/UpdateConfigurationByIdOK.md)
 - [UpdateDcqlQueryInput](docs/UpdateDcqlQueryInput.md)
 - [UpdatePexQueryInput](docs/UpdatePexQueryInput.md)
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
