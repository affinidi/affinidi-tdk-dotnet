# Affinidi TDK .NET client for CredentialVerification

Affinidi TDK dotnet client for Affinidi CREDENTIAL VERIFICATION


## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (minimum version: **8.0.400**)  


Check your installed version:

```bash
dotnet --version
```

### Installation

These are the steps to get you started with a dotnet project and integration with **AffinidiTdk.CredentialVerificationClient**. 
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.CredentialVerificationClient))**

```bash
dotnet add package AffinidiTdk.CredentialVerificationClient
```



## Usage

The **AffinidiTdk.CredentialVerificationClient** uses authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package which is also available in [nuget.org](https://www.nuget.org//packages/AffinidiTdk.AuthProvider).

> To generate a token, you first need to create your Personal Access Token (PAT). Please refer to this [link](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat).

1. **Import the required dependencies**

The dependencies required may differ based on the Client API used in your application. 


```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;
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


DefaultApi api = new DefaultApi(config);

var verifyCredentialInput = new VerifyCredentialInput();

VerifyCredentialOutput result = api.VerifyCredentials(verifyCredentialInput);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/credential-verification).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


## Documentation

### Client API Documentation

ClientAPI | Operation | Description
------------ | ------------- | -------------
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/DefaultApi.md) | [*VerifyCredentials*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/DefaultApi.md#verifycredentials) | Verifying VC
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/DefaultApi.md) | [*VerifyCredentialsV2*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/DefaultApi.md#verifycredentialsv2) | Verifying VC
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/DefaultApi.md) | [*VerifyPresentation*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/DefaultApi.md#verifypresentation) | Verifying VP
[*DefaultApi*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/DefaultApi.md) | [*VerifyPresentationV2*](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/DefaultApi.md#verifypresentationv2) | Verifying VP


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [Constraints](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/Constraints.md)
 - [ConstraintsStatuses](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/ConstraintsStatuses.md)
 - [Descriptor](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/Descriptor.md)
 - [Error](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/Error.md)
 - [ErrorDetail](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/ErrorDetail.md)
 - [EvaluateVpOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/EvaluateVpOutput.md)
 - [Field](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/Field.md)
 - [Filter](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/Filter.md)
 - [FilterConst](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/FilterConst.md)
 - [FilterItems](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/FilterItems.md)
 - [Format](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/Format.md)
 - [HolderSubject](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/HolderSubject.md)
 - [InputDescriptor](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/InputDescriptor.md)
 - [InvalidParameterError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/InvalidParameterError.md)
 - [JwtObject](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/JwtObject.md)
 - [LdpObject](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/LdpObject.md)
 - [NestedDescriptor](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/NestedDescriptor.md)
 - [NotFoundError](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/NotFoundError.md)
 - [NotFoundErrorDetailsInner](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/NotFoundErrorDetailsInner.md)
 - [PdStatus](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/PdStatus.md)
 - [PresentationDefinition](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/PresentationDefinition.md)
 - [PresentationSubmission](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/PresentationSubmission.md)
 - [SubmissionRequirement](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/SubmissionRequirement.md)
 - [ValidateJwtInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/ValidateJwtInput.md)
 - [ValidateJwtOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/ValidateJwtOutput.md)
 - [VerifyCredentialInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/VerifyCredentialInput.md)
 - [VerifyCredentialOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/VerifyCredentialOutput.md)
 - [VerifyCredentialV2Input](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/VerifyCredentialV2Input.md)
 - [VerifyPresentationInput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/VerifyPresentationInput.md)
 - [VerifyPresentationOutput](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/VerifyPresentationOutput.md)
 - [VerifyPresentationV2Input](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/VerifyPresentationV2Input.md)
 - [VerifyPresentationV2InputPexQuery](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/VerifyPresentationV2InputPexQuery.md)
 - [W3cCredentialStatus](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/W3cCredentialStatus.md)
 - [W3cProof](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/CredentialVerificationClient/docs/W3cProof.md)



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


