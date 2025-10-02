# Affinidi TDK .NET client for CredentialIssuance

Affinidi TDK dotnet client for Affinidi CREDENTIAL ISSUANCE


## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (minimum version: **8.0.400**)  


Check your installed version:

```bash
dotnet --version
```

### Installation

These are the steps to get you started with a dotnet project and integration with **AffinidiTdk.CredentialIssuanceClient**. 
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.CredentialIssuanceClient))**

```bash
dotnet add package AffinidiTdk.CredentialIssuanceClient
```



## Usage

The **AffinidiTdk.CredentialIssuanceClient** uses authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package which is also available in [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).

> To generate a token, you first need to create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat).

1. **Import the required dependencies**

The dependencies required may differ based on the Client API used in your application. 


```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;
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


ConfigurationApi api = new ConfigurationApi(config);

var createIssuanceConfigInput = new CreateIssuanceConfigInput();

IssuanceConfigDto result = api.CreateIssuanceConfig(createIssuanceConfigInput);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/credential-issuance/).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


## Documentation

### Client API Documentation

ClientAPI | Operation | Description
------------ | ------------- | -------------
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md) | [*CreateIssuanceConfig*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md#createissuanceconfig) | 
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md) | [*DeleteIssuanceConfigById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md#deleteissuanceconfigbyid) | 
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md) | [*GetIssuanceConfigById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md#getissuanceconfigbyid) | 
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md) | [*GetIssuanceConfigList*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md#getissuanceconfiglist) | 
[*ConfigurationApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md) | [*UpdateIssuanceConfigById*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ConfigurationApi.md#updateissuanceconfigbyid) | 
[*CredentialsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialsApi.md) | [*BatchCredential*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialsApi.md#batchcredential) | Allows wallets to claim multiple credentials at once.
[*CredentialsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialsApi.md) | [*GenerateCredentials*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialsApi.md#generatecredentials) | 
[*CredentialsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialsApi.md) | [*GetClaimedCredentials*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialsApi.md#getclaimedcredentials) | Get claimed credential in the specified range
[*CredentialsApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialsApi.md) | [*GetIssuanceIdClaimedCredential*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialsApi.md#getissuanceidclaimedcredential) | Get claimed VC linked to the issuanceId
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/DefaultApi.md) | [*ChangeCredentialStatus*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/DefaultApi.md#changecredentialstatus) | change credential status.
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/DefaultApi.md) | [*ListIssuanceDataRecords*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/DefaultApi.md#listissuancedatarecords) | List records
[*IssuanceApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceApi.md) | [*IssuanceState*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceApi.md#issuancestate) | 
[*IssuanceApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceApi.md) | [*IssueCredentials*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceApi.md#issuecredentials) | 
[*IssuanceApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceApi.md) | [*ListIssuance*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceApi.md#listissuance) | 
[*IssuanceApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceApi.md) | [*StartIssuance*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceApi.md#startissuance) | 
[*OfferApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/OfferApi.md) | [*GetCredentialOffer*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/OfferApi.md#getcredentialoffer) | 
[*WellKnownApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/WellKnownApi.md) | [*GetWellKnownOpenIdCredentialIssuer*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/WellKnownApi.md#getwellknownopenidcredentialissuer) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [ActionForbiddenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ActionForbiddenError.md)
 - [ActionForbiddenErrorDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ActionForbiddenErrorDetailsInner.md)
 - [BatchCredentialInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/BatchCredentialInput.md)
 - [BatchCredentialInputCredentialRequestsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/BatchCredentialInputCredentialRequestsInner.md)
 - [BatchCredentialResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/BatchCredentialResponse.md)
 - [BatchCredentialResponseCredentialResponsesInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/BatchCredentialResponseCredentialResponsesInner.md)
 - [ChangeCredentialStatus400Response](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ChangeCredentialStatus400Response.md)
 - [ChangeCredentialStatusInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ChangeCredentialStatusInput.md)
 - [ChangeStatusForbiddenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ChangeStatusForbiddenError.md)
 - [CisConfigurationWebhookSetting](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CisConfigurationWebhookSetting.md)
 - [CisConfigurationWebhookSettingEndpoint](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CisConfigurationWebhookSettingEndpoint.md)
 - [ClaimedCredentialListResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ClaimedCredentialListResponse.md)
 - [ClaimedCredentialResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ClaimedCredentialResponse.md)
 - [CorsBatchCredentialOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CorsBatchCredentialOK.md)
 - [CorsGenerateCredentialsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CorsGenerateCredentialsOK.md)
 - [CorsGetClaimedCredentialsOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CorsGetClaimedCredentialsOK.md)
 - [CorsGetCredentialOfferOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CorsGetCredentialOfferOK.md)
 - [CorsGetIssuanceIdClaimedCredentialOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CorsGetIssuanceIdClaimedCredentialOK.md)
 - [CorsGetWellKnownOpenIdCredentialIssuerOK](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CorsGetWellKnownOpenIdCredentialIssuerOK.md)
 - [CreateCredentialInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CreateCredentialInput.md)
 - [CreateIssuanceConfig400Response](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CreateIssuanceConfig400Response.md)
 - [CreateIssuanceConfigInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CreateIssuanceConfigInput.md)
 - [CredentialIssuanceIdExistError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialIssuanceIdExistError.md)
 - [CredentialOfferClaimedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialOfferClaimedError.md)
 - [CredentialOfferExpiredError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialOfferExpiredError.md)
 - [CredentialOfferResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialOfferResponse.md)
 - [CredentialOfferResponseGrants](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialOfferResponseGrants.md)
 - [CredentialOfferResponseGrantsUrnIetfParamsOauthGrantTypePreAuthorizedCode](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialOfferResponseGrantsUrnIetfParamsOauthGrantTypePreAuthorizedCode.md)
 - [CredentialOfferResponseGrantsUrnIetfParamsOauthGrantTypePreAuthorizedCodeTxCode](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialOfferResponseGrantsUrnIetfParamsOauthGrantTypePreAuthorizedCodeTxCode.md)
 - [CredentialProof](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialProof.md)
 - [CredentialResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialResponse.md)
 - [CredentialResponseDeferred](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialResponseDeferred.md)
 - [CredentialResponseImmediate](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialResponseImmediate.md)
 - [CredentialResponseImmediateCNonceExpiresIn](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialResponseImmediateCNonceExpiresIn.md)
 - [CredentialResponseImmediateCredential](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialResponseImmediateCredential.md)
 - [CredentialSubjectNotValidError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialSubjectNotValidError.md)
 - [CredentialSupportedObject](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/CredentialSupportedObject.md)
 - [DeferredCredentialInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/DeferredCredentialInput.md)
 - [FlowData](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/FlowData.md)
 - [FlowDataStatusListsDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/FlowDataStatusListsDetailsInner.md)
 - [GenerateCredentials400Response](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/GenerateCredentials400Response.md)
 - [GetCredentialOffer400Response](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/GetCredentialOffer400Response.md)
 - [InvalidCredentialRequestError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/InvalidCredentialRequestError.md)
 - [InvalidCredentialTypeError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/InvalidCredentialTypeError.md)
 - [InvalidIssuerWalletError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/InvalidIssuerWalletError.md)
 - [InvalidJwtTokenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/InvalidJwtTokenError.md)
 - [InvalidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/InvalidParameterError.md)
 - [InvalidProofError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/InvalidProofError.md)
 - [IssuanceConfigDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceConfigDto.md)
 - [IssuanceConfigListResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceConfigListResponse.md)
 - [IssuanceConfigMiniDto](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceConfigMiniDto.md)
 - [IssuanceStateResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/IssuanceStateResponse.md)
 - [ListIssuanceRecordResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ListIssuanceRecordResponse.md)
 - [ListIssuanceResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ListIssuanceResponse.md)
 - [ListIssuanceResponseIssuancesInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ListIssuanceResponseIssuancesInner.md)
 - [MissingHolderDidError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/MissingHolderDidError.md)
 - [NotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/NotFoundError.md)
 - [ProjectCredentialConfigExistError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ProjectCredentialConfigExistError.md)
 - [ProjectCredentialConfigNotExistError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/ProjectCredentialConfigNotExistError.md)
 - [RevocationForbiddenError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/RevocationForbiddenError.md)
 - [StartIssuance400Response](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/StartIssuance400Response.md)
 - [StartIssuanceInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/StartIssuanceInput.md)
 - [StartIssuanceInputDataInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/StartIssuanceInputDataInner.md)
 - [StartIssuanceInputDataInnerMetaData](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/StartIssuanceInputDataInnerMetaData.md)
 - [StartIssuanceInputDataInnerStatusListDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/StartIssuanceInputDataInnerStatusListDetailsInner.md)
 - [StartIssuanceResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/StartIssuanceResponse.md)
 - [SupportedCredentialMetadata](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/SupportedCredentialMetadata.md)
 - [SupportedCredentialMetadataDisplayInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/SupportedCredentialMetadataDisplayInner.md)
 - [SupportedCredentialMetadataItemLogo](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/SupportedCredentialMetadataItemLogo.md)
 - [UpdateIssuanceConfigInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/UpdateIssuanceConfigInput.md)
 - [VcClaimedError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/VcClaimedError.md)
 - [WellKnownOpenIdCredentialIssuerResponse](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/WellKnownOpenIdCredentialIssuerResponse.md)
 - [WellKnownOpenIdCredentialIssuerResponseCredentialsSupportedInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/WellKnownOpenIdCredentialIssuerResponseCredentialsSupportedInner.md)
 - [WellKnownOpenIdCredentialIssuerResponseDisplay](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/WellKnownOpenIdCredentialIssuerResponseDisplay.md)
 - [WellKnownOpenIdCredentialIssuerResponseDisplayLogo](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialIssuanceClient/docs/WellKnownOpenIdCredentialIssuerResponseDisplayLogo.md)



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


