<a id="top"></a>
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.CredentialIssuanceClient))**

```bash
dotnet add package AffinidiTdk.CredentialIssuanceClient
```

<p align="right">(<a href="#top">back to top</a>)</p>


## Usage

1. **Import the required dependencies**

The dependencies required may differ based on the Client Api used in your application. 

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;
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


ConfigurationApi api = new ConfigurationApi(config);

var createIssuanceConfigInput = new CreateIssuanceConfigInput();

IssuanceConfigDto result = api.CreateIssuanceConfig(createIssuanceConfigInput);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/credential-issuance/).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.

<p align="right">(<a href="#top">back to top</a>)</p>


## Documentation

### Client Api Documentation

ClientApi | Operation | Description
------------ | ------------- | -------------
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*CreateIssuanceConfig*](docs/ConfigurationApi.md#createissuanceconfig) | 
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*DeleteIssuanceConfigById*](docs/ConfigurationApi.md#deleteissuanceconfigbyid) | 
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*GetIssuanceConfigById*](docs/ConfigurationApi.md#getissuanceconfigbyid) | 
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*GetIssuanceConfigList*](docs/ConfigurationApi.md#getissuanceconfiglist) | 
[*ConfigurationApi*](docs/ConfigurationApi.md) | [*UpdateIssuanceConfigById*](docs/ConfigurationApi.md#updateissuanceconfigbyid) | 
[*CredentialsApi*](docs/CredentialsApi.md) | [*BatchCredential*](docs/CredentialsApi.md#batchcredential) | Allows wallets to claim multiple credentials at once.
[*CredentialsApi*](docs/CredentialsApi.md) | [*GenerateCredentials*](docs/CredentialsApi.md#generatecredentials) | 
[*CredentialsApi*](docs/CredentialsApi.md) | [*GetClaimedCredentials*](docs/CredentialsApi.md#getclaimedcredentials) | Get claimed credential in the specified range
[*CredentialsApi*](docs/CredentialsApi.md) | [*GetIssuanceIdClaimedCredential*](docs/CredentialsApi.md#getissuanceidclaimedcredential) | Get claimed VC linked to the issuanceId
[*DefaultApi*](docs/DefaultApi.md) | [*ChangeCredentialStatus*](docs/DefaultApi.md#changecredentialstatus) | change credential status.
[*DefaultApi*](docs/DefaultApi.md) | [*ListIssuanceDataRecords*](docs/DefaultApi.md#listissuancedatarecords) | List records
[*IssuanceApi*](docs/IssuanceApi.md) | [*IssuanceState*](docs/IssuanceApi.md#issuancestate) | 
[*IssuanceApi*](docs/IssuanceApi.md) | [*IssueCredentials*](docs/IssuanceApi.md#issuecredentials) | 
[*IssuanceApi*](docs/IssuanceApi.md) | [*ListIssuance*](docs/IssuanceApi.md#listissuance) | 
[*IssuanceApi*](docs/IssuanceApi.md) | [*StartIssuance*](docs/IssuanceApi.md#startissuance) | 
[*OfferApi*](docs/OfferApi.md) | [*GetCredentialOffer*](docs/OfferApi.md#getcredentialoffer) | 
[*WellKnownApi*](docs/WellKnownApi.md) | [*GetWellKnownOpenIdCredentialIssuer*](docs/WellKnownApi.md#getwellknownopenidcredentialissuer) | 


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [ActionForbiddenError](docs/ActionForbiddenError.md)
 - [ActionForbiddenErrorDetailsInner](docs/ActionForbiddenErrorDetailsInner.md)
 - [BatchCredentialInput](docs/BatchCredentialInput.md)
 - [BatchCredentialInputCredentialRequestsInner](docs/BatchCredentialInputCredentialRequestsInner.md)
 - [BatchCredentialResponse](docs/BatchCredentialResponse.md)
 - [BatchCredentialResponseCredentialResponsesInner](docs/BatchCredentialResponseCredentialResponsesInner.md)
 - [ChangeCredentialStatus400Response](docs/ChangeCredentialStatus400Response.md)
 - [ChangeCredentialStatusInput](docs/ChangeCredentialStatusInput.md)
 - [ChangeStatusForbiddenError](docs/ChangeStatusForbiddenError.md)
 - [CisConfigurationWebhookSetting](docs/CisConfigurationWebhookSetting.md)
 - [CisConfigurationWebhookSettingEndpoint](docs/CisConfigurationWebhookSettingEndpoint.md)
 - [ClaimedCredentialListResponse](docs/ClaimedCredentialListResponse.md)
 - [ClaimedCredentialResponse](docs/ClaimedCredentialResponse.md)
 - [CorsBatchCredentialOK](docs/CorsBatchCredentialOK.md)
 - [CorsGenerateCredentialsOK](docs/CorsGenerateCredentialsOK.md)
 - [CorsGetClaimedCredentialsOK](docs/CorsGetClaimedCredentialsOK.md)
 - [CorsGetCredentialOfferOK](docs/CorsGetCredentialOfferOK.md)
 - [CorsGetIssuanceIdClaimedCredentialOK](docs/CorsGetIssuanceIdClaimedCredentialOK.md)
 - [CorsGetWellKnownOpenIdCredentialIssuerOK](docs/CorsGetWellKnownOpenIdCredentialIssuerOK.md)
 - [CreateCredentialInput](docs/CreateCredentialInput.md)
 - [CreateIssuanceConfig400Response](docs/CreateIssuanceConfig400Response.md)
 - [CreateIssuanceConfigInput](docs/CreateIssuanceConfigInput.md)
 - [CredentialIssuanceIdExistError](docs/CredentialIssuanceIdExistError.md)
 - [CredentialOfferClaimedError](docs/CredentialOfferClaimedError.md)
 - [CredentialOfferExpiredError](docs/CredentialOfferExpiredError.md)
 - [CredentialOfferResponse](docs/CredentialOfferResponse.md)
 - [CredentialOfferResponseGrants](docs/CredentialOfferResponseGrants.md)
 - [CredentialOfferResponseGrantsUrnIetfParamsOauthGrantTypePreAuthorizedCode](docs/CredentialOfferResponseGrantsUrnIetfParamsOauthGrantTypePreAuthorizedCode.md)
 - [CredentialOfferResponseGrantsUrnIetfParamsOauthGrantTypePreAuthorizedCodeTxCode](docs/CredentialOfferResponseGrantsUrnIetfParamsOauthGrantTypePreAuthorizedCodeTxCode.md)
 - [CredentialProof](docs/CredentialProof.md)
 - [CredentialResponse](docs/CredentialResponse.md)
 - [CredentialResponseDeferred](docs/CredentialResponseDeferred.md)
 - [CredentialResponseImmediate](docs/CredentialResponseImmediate.md)
 - [CredentialResponseImmediateCNonceExpiresIn](docs/CredentialResponseImmediateCNonceExpiresIn.md)
 - [CredentialResponseImmediateCredential](docs/CredentialResponseImmediateCredential.md)
 - [CredentialSubjectNotValidError](docs/CredentialSubjectNotValidError.md)
 - [CredentialSupportedObject](docs/CredentialSupportedObject.md)
 - [DeferredCredentialInput](docs/DeferredCredentialInput.md)
 - [FlowData](docs/FlowData.md)
 - [FlowDataStatusListsDetailsInner](docs/FlowDataStatusListsDetailsInner.md)
 - [GenerateCredentials400Response](docs/GenerateCredentials400Response.md)
 - [GetCredentialOffer400Response](docs/GetCredentialOffer400Response.md)
 - [InvalidCredentialRequestError](docs/InvalidCredentialRequestError.md)
 - [InvalidCredentialTypeError](docs/InvalidCredentialTypeError.md)
 - [InvalidIssuerWalletError](docs/InvalidIssuerWalletError.md)
 - [InvalidJwtTokenError](docs/InvalidJwtTokenError.md)
 - [InvalidParameterError](docs/InvalidParameterError.md)
 - [InvalidProofError](docs/InvalidProofError.md)
 - [IssuanceConfigDto](docs/IssuanceConfigDto.md)
 - [IssuanceConfigListResponse](docs/IssuanceConfigListResponse.md)
 - [IssuanceConfigMiniDto](docs/IssuanceConfigMiniDto.md)
 - [IssuanceStateResponse](docs/IssuanceStateResponse.md)
 - [ListIssuanceRecordResponse](docs/ListIssuanceRecordResponse.md)
 - [ListIssuanceResponse](docs/ListIssuanceResponse.md)
 - [ListIssuanceResponseIssuancesInner](docs/ListIssuanceResponseIssuancesInner.md)
 - [MissingHolderDidError](docs/MissingHolderDidError.md)
 - [NotFoundError](docs/NotFoundError.md)
 - [ProjectCredentialConfigExistError](docs/ProjectCredentialConfigExistError.md)
 - [ProjectCredentialConfigNotExistError](docs/ProjectCredentialConfigNotExistError.md)
 - [RevocationForbiddenError](docs/RevocationForbiddenError.md)
 - [StartIssuance400Response](docs/StartIssuance400Response.md)
 - [StartIssuanceInput](docs/StartIssuanceInput.md)
 - [StartIssuanceInputDataInner](docs/StartIssuanceInputDataInner.md)
 - [StartIssuanceInputDataInnerMetaData](docs/StartIssuanceInputDataInnerMetaData.md)
 - [StartIssuanceInputDataInnerStatusListDetailsInner](docs/StartIssuanceInputDataInnerStatusListDetailsInner.md)
 - [StartIssuanceResponse](docs/StartIssuanceResponse.md)
 - [SupportedCredentialMetadata](docs/SupportedCredentialMetadata.md)
 - [SupportedCredentialMetadataDisplayInner](docs/SupportedCredentialMetadataDisplayInner.md)
 - [SupportedCredentialMetadataItemLogo](docs/SupportedCredentialMetadataItemLogo.md)
 - [UpdateIssuanceConfigInput](docs/UpdateIssuanceConfigInput.md)
 - [VcClaimedError](docs/VcClaimedError.md)
 - [WellKnownOpenIdCredentialIssuerResponse](docs/WellKnownOpenIdCredentialIssuerResponse.md)
 - [WellKnownOpenIdCredentialIssuerResponseCredentialsSupportedInner](docs/WellKnownOpenIdCredentialIssuerResponseCredentialsSupportedInner.md)
 - [WellKnownOpenIdCredentialIssuerResponseDisplay](docs/WellKnownOpenIdCredentialIssuerResponseDisplay.md)
 - [WellKnownOpenIdCredentialIssuerResponseDisplayLogo](docs/WellKnownOpenIdCredentialIssuerResponseDisplayLogo.md)


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
