<a id="top"></a>
# Affinidi Trust Development Kit (TDK) for .NET

The Affinidi TDK empowers developers to streamline the integration of Affinidi services into their applications with comprehensive tools, reducing integration effort and improving productivity.
This toolkit also makes it easy to integrate [Affinidi Elements](https://docs.affinidi.com/docs/affinidi-elements/) and [Frameworks](https://docs.affinidi.com/frameworks/iota-framework/) into your application. It enables developers to integrate seamlessly into the [Affinidi Trust Network (ATN)](https://docs.affinidi.com/docs/).

With Affinidi TDK, developers can build privacy-first identity applications in .NET, supporting use-cases such as [enabling passwordless login experience for your users](https://docs.affinidi.com/docs/affinidi-login/), [implementing consent-driven data sharing](https://docs.affinidi.com/frameworks/iota-framework/), and [issuing verifiable credentials (VCs) to your users](https://docs.affinidi.com/docs/affinidi-elements/credential-issuance/).


## Table of Contents

- [How do I use Affinidi TDK?](#how-do-i-use-affinidi-tdk)
- [Requirements](#requirements)
- [Installation](#installation)
- [Quickstart](#quickstart)
- [Documentation](#documentation)
- [Support & Feedback](#support--feedback)
- [Contributing](#contributing)
- [FAQ](#faq)
- [Telemetry](#telemetry)


## How do I use Affinidi TDK?

The Affinidi TDK provides two types of modules:

- [Clients](https://docs.affinidi.com/dev-tools/affinidi-tdk/dotnet/clients/): offer methods to access Affinidi Elements services like Credential Issuance, Credential Verification, and Login Configurations, among others.
- [Packages](https://docs.affinidi.com/dev-tools/affinidi-tdk/dotnet/packages/): are commonly used utilities/helpers that are self-contained and composable.



## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) **(minimum version: `8.0.400`)**

You can check your installed version using:

```bash
dotnet --version
```

💡 This project uses a `global.json` to enforce SDK version consistency. If you don’t have the specified version installed, the build may fail.


<p align="right">(<a href="#top">back to top</a>)</p>



## Installation

### Creating a New Project

> **Note:** These are optional if you have already created a project.

1. Create a project directory: `mkdir my-dotnet-app`
2. Create the project: `dotnet create console`


### Installing a TDK client or packages with .NET

> **Note:** The Affinidi TDK clients use authorisation token to authenticate client requests. You can generate a token with the use of the **AuthProvider** package.

To install TDK client or package in dotnet, you need to run the command below:

`dotnet add package <Affinidi-Package-Name>`

Example (installing the AffinidiTdk.AuthProvider Package):

`dotnet add package AffinidiTdk.AuthProvider`

All Affinidi TDK Clients and Packages are available in [nuget.org](https://www.nuget.org/profiles/affinidi). 


<p align="right">(<a href="#top">back to top</a>)</p>



## Quickstart

> **Note:** When working with tokens, it’s crucial to manage your project access token properly to avoid failures caused by expiration. To help with this, we’ve provided [example code](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/examples/HookAuthExample/HookAuthExample.cs) that automatically refreshes tokens, ensuring that the client APIs always use a valid, up-to-date token.


Here's a basic example of using the .NET TDK to create a wallet for signing verifiable credentials using the **WalletApi** from **[AffinidiTdk.WalletsClient](https://www.nuget.org/packages/AffinidiTdk.WalletsClient)**:

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
            // Please generate your own Personal Access Tokens (PAT). 
            // Refer to https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/#create-a-personal-access-token-pat for the guide on creating your own PAT.
            ProjectId = "<YOUR-PROJECT-ID>",
            TokenId = "<YOUR-TOKEN-ID>",
            PrivateKey = "<YOUR-PRIVATE-KEY>"
        };

        // create an AuthProvider instance
        AuthProvider authProvider = new AuthProvider(authProviderParams);

        // fetch the projectScopedToken from the authProviderConfig
        string projecScopedToken = await authProvider.FetchProjectScopedTokenAsync();
        
        // create an instance of Configuration from AffinidiTdk.CredentialIssuanceClient
        Configuration config = new Configuration();

        // set the projectScopedToken as apiKey. Note that its using a Map/Dictionary. Key here is "authorization"
        config.AddApiKey("authorization", projectScopedToken);

        // create an instance of WalletApi (from using AffinidiTdk.WalletsClient.Api) and pass the config in the constructor argument.
        WalletApi api = new WalletApi(config);

        // create a CreateWalletInput object with the name and did method
        CreateWalletInput input = new CreateWalletInput(name: "DotNet Wallet", didMethod: CreateWalletInput.DidMethodEnum.Key); 

        // call the CreateWallet api and pass the CreateWalletInput as argument
        CreateWalletResponse result  = api.CreateWallet(input);
        
        Console.WriteLine("CreateWallet Result: " + result.ToJson());
    }
}
```

Running the code will display the result similar to below:

```bash

CreateWallet Result: {
  "wallet": {
    "id": "<WALLET-ID>",
    "did": "<WALLET-DID>",
    "name": "DotNet Wallet",
    ...
  }
}

```

Get to know more about other .NET TDK clients and operations from our [documentation site](https://docs.affinidi.com/dev-tools/affinidi-tdk/dotnet/clients/).


<p align="right">(<a href="#top">back to top</a>)</p>



## Documentation

Head over to our [Documentation site](https://docs.affinidi.com/dev-tools/affinidi-tdk) to know how to get started with Affinidi TDK.

Use [this document](https://docs.affinidi.com/dev-tools/affinidi-tdk/overview/#prerequisites) to learn more about how to work with Affinidi TDK, including generating the Authorisation Token and calling the methods.

To learn how to integrate Affinidi TDK and use the different modules into your application, you can explore the following:

- [Affinidi TDK Clients](https://docs.affinidi.com/dev-tools/affinidi-tdk/overview/#clients)
- [Affinidi TDK Packages](https://docs.affinidi.com/dev-tools/affinidi-tdk/overview/#packages)



<p align="right">(<a href="#top">back to top</a>)</p>



## Support & Feedback

If you face any issues or have suggestions, please don't hesitate to contact us using [this link](https://share.hsforms.com/1i-4HKZRXSsmENzXtPdIG4g8oa2v).

### Reporting technical issues

If you have a technical issue with the Affinidi TDK's codebase, you can also create an issue directly in GitHub.

1. Ensure the bug was not already reported by searching on GitHub under
   [Issues](https://github.com/affinidi/affinidi-tdk-dotnet/issues).

2. If you're unable to find an open issue addressing the problem,
   [open a new one](https://github.com/affinidi/affinidi-tdk-dotnet/issues/new).
   Be sure to include a **title and clear description**, as much relevant information as possible,
   and a **code sample** or an **executable test case** demonstrating the expected behavior that is not occurring.
   


<p align="right">(<a href="#top">back to top</a>)</p>



## Contributing

We enjoy community contributions! Whether it’s bug fixes, feature requests, or improving docs, your input helps shape the Affinidi TDK.

- Head over to our [CONTRIBUTING](CONTRIBUTING.md) to get started.
- Have an idea? Start a discussion in [GitHub Discussions](https://github.com/affinidi/affinidi-tdk-dotnet/issues) or [Discord](https://discord.com/invite/hGVVSEASPQ)



<p align="right">(<a href="#top">back to top</a>)</p>




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

<p align="right">(<a href="#top">back to top</a>)</p>

## Telemetry

Affinidi collects usage data to improve our products and services. For information on what data we collect and how we use your data, please refer to our [Privacy Notice](https://www.affinidi.com/privacy-notice).

_Disclaimer:
Please note that this FAQ is provided for informational purposes only and is not to be considered a legal document. For the legal terms and conditions governing your use of the Affinidi Services, please refer to our [Terms and Conditions](https://www.affinidi.com/terms-conditions)._



<p align="right">(<a href="#top">back to top</a>)</p>