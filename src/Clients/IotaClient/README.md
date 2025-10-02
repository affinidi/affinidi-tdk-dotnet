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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.IotaClient))**

```bash
dotnet add package AffinidiTdk.IotaClient
```



## Usage

The **AffinidiTdk.IotaClient** uses authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package which is also available in [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).

> To generate a token, you first need to create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat).

1. **Import the required dependencies**

The dependencies required may differ based on the Client API used in your application. 


```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.IotaClient.Api;
using AffinidiTdk.IotaClient.Client;
using AffinidiTdk.IotaClient.Model;
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


CallbackApi api = new CallbackApi(config);

var callbackInput = new CallbackInput();

CallbackResponseOK result = api.IotOIDC4VPCallback(callbackInput);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/iota-framework).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


## Documentation

### Client API Documentation

ClientAPI | Operation | Description
------------ | ------------- | -------------
[*CallbackApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CallbackApi.md) | [*IotOIDC4VPCallback*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CallbackApi.md#iotoidc4vpcallback) | 
[*ConfigurationsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md) | [*CreateIotaConfiguration*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md#createiotaconfiguration) | 
[*ConfigurationsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md) | [*DeleteIotaConfigurationById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md#deleteiotaconfigurationbyid) | 
[*ConfigurationsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md) | [*GetIotaConfigurationById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md#getiotaconfigurationbyid) | 
[*ConfigurationsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md) | [*GetIotaConfigurationMetaData*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md#getiotaconfigurationmetadata) | 
[*ConfigurationsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md) | [*ListIotaConfigurations*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md#listiotaconfigurations) | 
[*ConfigurationsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md) | [*UpdateIotaConfigurationById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConfigurationsApi.md#updateiotaconfigurationbyid) | 
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/DefaultApi.md) | [*ListLoggedConsents*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/DefaultApi.md#listloggedconsents) | 
[*IotaApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md) | [*AwsExchangeCredentials*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md#awsexchangecredentials) | 
[*IotaApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md) | [*AwsExchangeCredentialsProjectToken*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md#awsexchangecredentialsprojecttoken) | 
[*IotaApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md) | [*FetchIotaVpResponse*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md#fetchiotavpresponse) | 
[*IotaApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md) | [*InitiateDataSharingRequest*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md#initiatedatasharingrequest) | 
[*IotaApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md) | [*IotaExchangeCredentials*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaApi.md#iotaexchangecredentials) | 
[*PexQueryApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md) | [*CreatePexQuery*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md#createpexquery) | 
[*PexQueryApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md) | [*DeletePexQueries*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md#deletepexqueries) | 
[*PexQueryApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md) | [*DeletePexQueryById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md#deletepexquerybyid) | 
[*PexQueryApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md) | [*GetPexQueryById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md#getpexquerybyid) | 
[*PexQueryApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md) | [*ListPexQueries*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md#listpexqueries) | 
[*PexQueryApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md) | [*SavePexQueries*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md#savepexqueries) | 
[*PexQueryApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md) | [*UpdatePexQueryById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryApi.md#updatepexquerybyid) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [AlreadyExistsError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/AlreadyExistsError.md)
 - [AwsExchangeCredentials](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/AwsExchangeCredentials.md)
 - [AwsExchangeCredentialsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/AwsExchangeCredentialsOK.md)
 - [AwsExchangeCredentialsProjectToken](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/AwsExchangeCredentialsProjectToken.md)
 - [AwsExchangeCredentialsProjectTokenOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/AwsExchangeCredentialsProjectTokenOK.md)
 - [AwsExchangeCredentialsProjectTokenOKCredentials](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/AwsExchangeCredentialsProjectTokenOKCredentials.md)
 - [CallbackInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CallbackInput.md)
 - [CallbackResponseOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CallbackResponseOK.md)
 - [ConsentDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ConsentDto.md)
 - [CorsAwsExchangeCredentialsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CorsAwsExchangeCredentialsOK.md)
 - [CorsAwsExchangeCredentialsProjectTokenOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CorsAwsExchangeCredentialsProjectTokenOK.md)
 - [CorsFetchIotaVpResponseOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CorsFetchIotaVpResponseOK.md)
 - [CorsInitiateDataSharingRequestOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CorsInitiateDataSharingRequestOK.md)
 - [CorsIotOidc4vpcallbackOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CorsIotOidc4vpcallbackOK.md)
 - [CorsIotaExchangeCredentialsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CorsIotaExchangeCredentialsOK.md)
 - [CreateDcqlQueryInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CreateDcqlQueryInput.md)
 - [CreateIotaConfigurationInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CreateIotaConfigurationInput.md)
 - [CreatePexQueryInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/CreatePexQueryInput.md)
 - [DcqlQueryDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/DcqlQueryDto.md)
 - [DeletePexQueriesInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/DeletePexQueriesInput.md)
 - [FetchIOTAVPResponseInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/FetchIOTAVPResponseInput.md)
 - [FetchIOTAVPResponseOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/FetchIOTAVPResponseOK.md)
 - [GetIotaConfigurationMetaDataOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/GetIotaConfigurationMetaDataOK.md)
 - [InitiateDataSharingRequestInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/InitiateDataSharingRequestInput.md)
 - [InitiateDataSharingRequestOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/InitiateDataSharingRequestOK.md)
 - [InitiateDataSharingRequestOKData](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/InitiateDataSharingRequestOKData.md)
 - [InvalidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/InvalidParameterError.md)
 - [InvalidParameterErrorDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/InvalidParameterErrorDetailsInner.md)
 - [IotaConfigurationDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaConfigurationDto.md)
 - [IotaConfigurationDtoClientMetadata](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaConfigurationDtoClientMetadata.md)
 - [IotaExchangeCredentials](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaExchangeCredentials.md)
 - [IotaExchangeCredentialsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaExchangeCredentialsOK.md)
 - [IotaExchangeCredentialsOKCredentials](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/IotaExchangeCredentialsOKCredentials.md)
 - [ListConfigurationOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ListConfigurationOK.md)
 - [ListDcqlQueriesOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ListDcqlQueriesOK.md)
 - [ListLoggedConsentsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ListLoggedConsentsOK.md)
 - [ListPexQueriesOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ListPexQueriesOK.md)
 - [MessagePublishingError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/MessagePublishingError.md)
 - [NotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/NotFoundError.md)
 - [OperationForbiddenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/OperationForbiddenError.md)
 - [PexQueryDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PexQueryDto.md)
 - [PrepareRequest](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PrepareRequest.md)
 - [PrepareRequestCreated](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PrepareRequestCreated.md)
 - [PrepareRequestCreatedData](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/PrepareRequestCreatedData.md)
 - [ResourceLimitExceededError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/ResourceLimitExceededError.md)
 - [SavePexQueriesUpdateInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/SavePexQueriesUpdateInput.md)
 - [SavePexQueriesUpdateInputQueriesInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/SavePexQueriesUpdateInputQueriesInner.md)
 - [UpdateConfigurationByIdInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/UpdateConfigurationByIdInput.md)
 - [UpdateConfigurationByIdOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/UpdateConfigurationByIdOK.md)
 - [UpdateDcqlQueryInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/UpdateDcqlQueryInput.md)
 - [UpdatePexQueryInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/UpdatePexQueryInput.md)
 - [VPTokenValidationError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/IotaClient/docs/VPTokenValidationError.md)



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


