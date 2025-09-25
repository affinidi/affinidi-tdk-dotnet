<a id="top"></a>
# Affinidi Trust Development Kit (Affinidi TDK) for .NET

The Affinidi Trust Development Kit (Affinidi TDK) is a modern interface that allows you to build privacy-first identity apps in .NET with minimal setup.
It allows you to easily manage and integrate [Affinidi Elements](https://docs.affinidi.com/docs/affinidi-elements/) and [Frameworks](https://docs.affinidi.com/frameworks/iota-framework/) into your application. It minimises dependencies and enables developers to integrate seamlessly into the [Affinidi Trust Network (ATN)](https://docs.affinidi.com/docs/).


## How do I use Affinidi TDK?

The Affinidi TDK provides two types of modules:

- [Clients](src/Clients), which offer methods to access Affinidi Elements services like Credential Issuance, Credential Verification, and Login Configurations, among others.
- [Packages](src/Packages), which are commonly used utilities/helpers that are self-contained and composable.


<a id="requirements"></a>
## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) **(minimum version: `8.0.400`)**
- Compatible OS: Windows, macOS, or Linux

You can check your installed version using:

```bash
dotnet --version
```

💡 This project uses a `global.json` to enforce SDK version consistency. If you don’t have the specified version installed, the build may fail.


[[Back to top]](#top) | [[Requirements]](#requirements) | [[Installation]](#installation) | [[Quickstart]](#quickstart) | [[Documentation]](#documentation) | [[Support & Feedback]](#support_feedback) | [[Contributing]](#contributing) | [[FAQ]](#faq)


<a id="installation"></a>
## Installation

### Creating a New Project

1. Create a project directory: `mkdir my-dotnet-app`
2. Create the project: `dotnet create console`


### Installing a TDK client or packages with .NET

To install TDK client or package in dotnet, you need to run the command below:

`dotnet add package <Affinidi-Package-Name>`

Example (installing the AffinidiTdk.AuthProvider Package):

`dotnet add package AffinidiTdk.AuthProvider`

The Clients and Packages will be available in [nuget.org](https://www.nuget.org/).


[[Back to top]](#top) | [[Requirements]](#requirements) | [[Installation]](#installation) | [[Quickstart]](#quickstart) | [[Documentation]](#documentation) | [[Support & Feedback]](#support_feedback) | [[Contributing]](#contributing) | [[FAQ]](#faq)




<a id="quickstart"></a>
## Quickstart

Here's a basic example of using the .NET TDK to create a wallet using **WalletsApi** from **[AffinidiTdk.WalletsClient](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/src/Clients/WalletsClient)**:

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Model;

public class CreateWalletExample
{
    static async Task Main(string[] args)
    {
        // Instantiate AuthProviderConfig object to load the AuthProvider.
        // Ensure that these sensitive information are kept safe. 
        // You may use `DotNetEnv` to load this info from your .env
        var authProviderParams = new AuthProviderParams
        {
            // These are sample Values Only, please generate your own Personal Access Tokens (PAT). 
            // Please refer to https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat for the guide on creating your own PAT.
            ProjectId = "c0be7a6f-36db-41ab-8069-ccfaa30d4a31", 
            TokenId = "d26653a5-60c3-42eb-824b-d6878ae99c2e", 
            PrivateKey = "-----BEGIN PRIVATE KEY-----MIICXQIBAAKBgQCWGnSOnz0hCtrdkl7y4dRyR3jAKUjlq1Sx1Zs3pjyZYVO5TDWE6KGwoYxIUBecsKdO98hvIRqI6xXtWNpfb++yldBPbEcH/+Vu3oJGevhrsUCQQCRA4M6Pp8Oe1yWCxmiJyI08xvwwpnABVcXXLAHxq/LX92kJa3s9qXpzbgj8Uwl53B6F2Nzs0NtxQnT73To3fMh-----END PRIVATE KEY-----" 
        };

        // create an AuthProvider instance
        AuthProvider authProvider = new AuthProvider(authProviderParams);

        // fetch the projectScopedToken from the authProviderConfig
        string projecScopedToken = await authProvider.FetchProjectScopedTokenAsync();
        
        // create an instance of Configuration from AffinidiTdk.LoginConfigurationClient
        Configuration config = new Configuration();

        // set the projectScopedToken as apiKey. Note that its using a Map/Dictionary. Key here is "authorization"
        config.AddApiKey("authorization", projectScopedToken);

        // create an instance of ConfigurationApi (from AffinidiTdk.WalletsClient.Api) and pass the config in the constructor argument.
        WalletApi api = new WalletApi(config);

        // prepare the input data to create a wallet
        CreateWalletInput input = new CreateWalletInput(name: "DotNet Wallet", didMethod: CreateWalletInput.DidMethodEnum.Key); 

        // call the CreateWallet operation
        CreateWalletResponse result  = api.CreateWallet(input);
        
        // print the result
        Console.WriteLine("CreateWallet Result: " + result.ToJson());
    }
}
```

Running the code will display the result similar to below:

```bash

CreateWallet Result: {
  "wallet": {
    "id": "fsdfdsf298340832904...",
    "did": "did:key:djsaildjo92u930u0j9frjfsdfdsff...",
    "name": "DotNet Wallet",
    "ari": "ari:identity:ap-southeast-1:759696e3-249b-4ed1-a5bb-34d68e329c0c:wallet/25969eb3219054597ce405d1c24c9b05",
    "keys": [
      {
        "id": "4fb137fe-4012-40c6-bd0a-039d02003cad",
        "ari": "ari:identity:ap-southeast-1:759696e3-249b-4ed1-a5bb-34d68e329c0c:key/6af24104090fb9583b6c4f1f7bddf080-4621a2278bd7ea1a"
      }
    ]
  }
}

```

You may find more examples [here](examples).

### Important Reminder

When handling tokens, it is important that your project access token is managed properly to prevent failures due to expired tokens. 

We have created an [example code](https://github.com/affinidi/affinidi-tdk-dotnet/blob/main/examples/HookAuthExample/HookAuthExample.cs) which handles the automatic refresh of tokens to ensure that the token used in the client APIs are fresh.


[[Back to top]](#top) | [[Requirements]](#requirements) | [[Installation]](#installation) | [[Quickstart]](#quickstart) | [[Documentation]](#documentation) | [[Support & Feedback]](#support_feedback) | [[Contributing]](#contributing) | [[FAQ]](#faq)



<a id="documentation"></a>
## Documentation

Head over to our [Documentation site](https://docs.affinidi.com/dev-tools/affinidi-tdk) to know how to get started with Affinidi TDK.

Use [this document](https://docs.affinidi.com/dev-tools/affinidi-tdk/overview/#prerequisites) to learn more about how to work with Affinidi TDK, including generating the Authorisation Token and calling the methods.

To learn how to integrate Affinidi TDK and use the different modules into your application, you can explore the following:

- [Affinidi TDK Clients](https://docs.affinidi.com/dev-tools/affinidi-tdk/overview/#clients)
- [Affinidi TDK Packages](https://docs.affinidi.com/dev-tools/affinidi-tdk/overview/#packages)



[[Back to top]](#top) | [[Requirements]](#requirements) | [[Installation]](#installation) | [[Quickstart]](#quickstart) | [[Documentation]](#documentation) | [[Support & Feedback]](#support_feedback) | [[Contributing]](#contributing) | [[FAQ]](#faq)



<a id="support_feedback"></a>
## Support & feedback

If you face any issues or have suggestions, please don't hesitate to contact us using [this link](https://share.hsforms.com/1i-4HKZRXSsmENzXtPdIG4g8oa2v).

### Reporting technical issues

If you have a technical issue with the Affinidi TDK's codebase, you can also create an issue directly in GitHub.

1. Ensure the bug was not already reported by searching on GitHub under
   [Issues](https://github.com/affinidi/affinidi-tdk-dotnet/issues).

2. If you're unable to find an open issue addressing the problem,
   [open a new one](https://github.com/affinidi/affinidi-tdk-dotnet/issues/new).
   Be sure to include a **title and clear description**, as much relevant information as possible,
   and a **code sample** or an **executable test case** demonstrating the expected behavior that is not occurring.
   


[[Back to top]](#top) | [[Requirements]](#requirements) | [[Installation]](#installation) | [[Quickstart]](#quickstart) | [[Documentation]](#documentation) | [[Support & Feedback]](#support_feedback) | [[Contributing]](#contributing) | [[FAQ]](#faq)



<a id="contributing"></a>
## Contributing

We enjoy community contributions! Whether it’s bug fixes, feature requests, or improving docs, your input helps shape the Affinidi TDK.

- Head over to our [CONTRIBUTING](CONTRIBUTING.md) to get started.
- Have an idea? Start a discussion in [GitHub Discussions](https://github.com/affinidi/affinidi-tdk-dotnet/issues) or [Discord](https://discord.com/invite/hGVVSEASPQ)



[[Back to top]](#top) | [[Requirements]](#requirements) | [[Installation]](#installation) | [[Quickstart]](#quickstart) | [[Documentation]](#documentation) | [[Support & Feedback]](#support_feedback) | [[Contributing]](#contributing) | [[FAQ]](#faq)



<a id="faq"></a>
## FAQ

### What can I develop?

You are only limited by your imagination! Affinidi TDK is a toolbox with which you can build software applications for personal or commercial use.

### Is there anything I should not develop?

We only provide the tools - how you use them is largely up to you. We have no control over what you develop with our tools - but please use our tools responsibly!

We hope that you will not develop anything that contravenes any applicable laws or regulations. Your projects should also not infringe on Affinidi's or any third party's intellectual property (for instance, misusing other parties' data, code, logos, etc).

### What responsibilities do I have to my end-users?

Please ensure that you have in place your terms and conditions, privacy policies, and other safeguards to ensure that the projects you build are secure for your end users.

If you are processing personal data, please protect the privacy and other legal rights of your end-users and store their personal or sensitive information securely.

Some of our components would also require you to incorporate our end-user notices into your terms and conditions.

### Is Affinidi TDK free for use?

Affinidi TDK itself is free, so come onboard and experiment with our tools and see what you can build! We may bill for certain components in the future, but we will inform you beforehand.

### Is there any limit or cap to my usage of the Affinidi TDK?

We may from time to time impose limits on your use of the Affinidi TDK, such as limiting the number of API requests that you may make in a given duration. This is to ensure the smooth operation of the Affinidi TDK so that you and all our other users can have a pleasant experience as we continue to scale and improve the Affinidi TDK.

### Do I need to provide you with anything?

From time to time, we may request certain information from you to ensure that you are complying with the [Terms and Conditions](https://www.affinidi.com/terms-conditions).

### Can I share my developer's account with others?

When you create a developer's account with us, we will issue you your private login credentials. Please do not share this with anyone else, as you would be responsible for activities that happen under your account. If you have interested friends, ask them to sign up – let's build together!

### Telemetry

Affinidi collects usage data to improve our products and services. For information on what data we collect and how we use your data, please refer to our [Privacy Notice](https://www.affinidi.com/privacy-notice).

_Disclaimer:
Please note that this FAQ is provided for informational purposes only and is not to be considered a legal document. For the legal terms and conditions governing your use of the Affinidi Services, please refer to our [Terms and Conditions](https://www.affinidi.com/terms-conditions)._

[[Back to top]](#top) | [[Requirements]](#requirements) | [[Installation]](#installation) | [[Quickstart]](#quickstart) | [[Documentation]](#documentation) | [[Support & Feedback]](#support_feedback) | [[Contributing]](#contributing) | [[FAQ]](#faq)
