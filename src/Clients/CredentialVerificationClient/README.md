<a id="top"></a>
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

3. **Installing the TDK Client (from [nuget.org](https://www.nuget.org//packages/AffinidiTdk.CredentialVerificationClient))**

```bash
dotnet add package AffinidiTdk.CredentialVerificationClient
```

<p align="right">(<a href="#top">back to top</a>)</p>


## Usage

1. **Import the required dependencies**

The dependencies required may differ based on the Client Api used in your application. 

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;
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


DefaultApi api = new DefaultApi(config);

var verifyCredentialInput = new VerifyCredentialInput();

VerifyCredentialOutput result = api.VerifyCredentials(verifyCredentialInput);

Console.WriteLine(result.ToJson());


```


For more examples, please refer to the [Documentation](https://docs.affinidi.com/dev-tools/affinidi-tdk/clients/credential-verification).

### Token Refresh

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.

<p align="right">(<a href="#top">back to top</a>)</p>


## Documentation

### Client Api Documentation

ClientApi | Operation | Description
------------ | ------------- | -------------
[*DefaultApi*](docs/DefaultApi.md) | [*VerifyCredentials*](docs/DefaultApi.md#verifycredentials) | Verifying VC
[*DefaultApi*](docs/DefaultApi.md) | [*VerifyPresentation*](docs/DefaultApi.md#verifypresentation) | Verifying VP


**Note:** *Each Client API operation requires a different authorization token. Please check the operation details for the type of token required to use the operation properly.*

### Documentation For Models

 - [Constraints](docs/Constraints.md)
 - [ConstraintsStatuses](docs/ConstraintsStatuses.md)
 - [Descriptor](docs/Descriptor.md)
 - [Error](docs/Error.md)
 - [ErrorDetail](docs/ErrorDetail.md)
 - [EvaluateVpOutput](docs/EvaluateVpOutput.md)
 - [Field](docs/Field.md)
 - [Filter](docs/Filter.md)
 - [FilterConst](docs/FilterConst.md)
 - [FilterItems](docs/FilterItems.md)
 - [Format](docs/Format.md)
 - [HolderSubject](docs/HolderSubject.md)
 - [InputDescriptor](docs/InputDescriptor.md)
 - [InvalidParameterError](docs/InvalidParameterError.md)
 - [JwtObject](docs/JwtObject.md)
 - [LdpObject](docs/LdpObject.md)
 - [NestedDescriptor](docs/NestedDescriptor.md)
 - [NotFoundError](docs/NotFoundError.md)
 - [NotFoundErrorDetailsInner](docs/NotFoundErrorDetailsInner.md)
 - [PdStatus](docs/PdStatus.md)
 - [PresentationDefinition](docs/PresentationDefinition.md)
 - [PresentationSubmission](docs/PresentationSubmission.md)
 - [SubmissionRequirement](docs/SubmissionRequirement.md)
 - [ValidateJwtInput](docs/ValidateJwtInput.md)
 - [ValidateJwtOutput](docs/ValidateJwtOutput.md)
 - [VerifyCredentialInput](docs/VerifyCredentialInput.md)
 - [VerifyCredentialOutput](docs/VerifyCredentialOutput.md)
 - [VerifyCredentialV2Input](docs/VerifyCredentialV2Input.md)
 - [VerifyPresentationInput](docs/VerifyPresentationInput.md)
 - [VerifyPresentationOutput](docs/VerifyPresentationOutput.md)
 - [VerifyPresentationV2Input](docs/VerifyPresentationV2Input.md)
 - [W3cCredentialStatus](docs/W3cCredentialStatus.md)
 - [W3cProof](docs/W3cProof.md)


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
