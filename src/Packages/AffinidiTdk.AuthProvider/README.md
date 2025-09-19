# AffinidiTdk.AuthProvider

`AffinidiTdk.AuthProvider` is a .NET TDK package for managing authentication tokens, including JWT validation, signing, and fetching project-scoped tokens. It integrates with your API Gateway to help you authenticate and handle tokens securely within your .NET applications.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) **(minimum version: `8.0.400`)**
- Compatible OS: Windows, macOS, or Linux

You can check your installed version using:

```bash
dotnet --version
```

## Features

- **JWT Validation**: Validate JWT tokens with a public key fetched from the API Gateway.
- **Project Scoped Tokens**: Fetch project-scoped tokens to interact with Affinidi services.

## Installation

To use it in your project, you can install it via NuGet:

```bash
dotnet add package AffinidiTdk.AuthProvider
```

To get ProjectScopedToken you need to initialize AuthProvider. Please check our docs how to obtain required secrets:

- [Getting started with Affinidi and how to create a project](https://docs.affinidi.com/docs/get-started/create-project/)
- [How to generate PAT credentials](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/)

```csharp
using AffinidiTdk.AuthProvider;
// ...
AuthProvider authProvider = new AuthProvider(new AuthProviderParams
{
    ProjectId = "PROJECT_ID",
    TokenId = "TOKEN_ID",
    PrivateKey = "PRIVATE_KEY",
    KeyId = "KEY_ID", // [OPTIONAL] unless unique value used on for the PAT
    Passphrase = "PASSPHRASE" // [OPTIONAL] unless private key is encrypted
});

string token = await authProvider.FetchProjectScopedTokenAsync();
```

Refer to docs of AffinidiTdk Clients and expore AffinidiTdk tests to see how to use AuthProvider to interact with Clients.
