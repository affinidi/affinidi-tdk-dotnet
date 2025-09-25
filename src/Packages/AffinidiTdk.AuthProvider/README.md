# AffinidiTdk.AuthProvider

This is a .NET TDK package which generates authorisation tokens to initialise TDK clients to access Affinidi services.

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

## Thread Safety

The AuthProvider class is thread-safe and designed for high-concurrency environments:

- Internally synchronizes token generation using a lock.
- Automatically caches tokens and refreshes only when expired.
- You can safely reuse a single AuthProvider instance across multiple threads or HTTP requests.
- No additional locking or synchronization is required.

## Token Management

You can create one shared AuthProvider instance and pass its token generator to multiple API clients (e.g., Wallets, IAM):

```csharp
using AffinidiTdk.AuthProvider;

AuthProvider authProvider = new AuthProvider(new AuthProviderParams
{
    ProjectId = "PROJECT_ID",
    TokenId = "TOKEN_ID",
    PrivateKey = "PRIVATE_KEY",
    KeyId = "KEY_ID", // [OPTIONAL] unless unique value used on for the PAT
    Passphrase = "PASSPHRASE" // [OPTIONAL] unless private key is encrypted
});
```

<!-- string token = await authProvider.FetchProjectScopedTokenAsync(); -->

❗️When you call:

```csharp
string token = await authProvider.FetchProjectScopedTokenAsync();
```

- If a valid (non-expired) token is cached, it will be reused.
- If no token exists or it has expired, a new one will be fetched.

> ⚠️ Note: You usually don’t need to call this method directly when using TDK clients — use the hook-based pattern instead (see below).

### Integrate with TDK Clients

To use the same AuthProvider across multiple clients (e.g. WalletsClient, IamClient), inject it into a shared HttpClient using TokenInjectingHandler (imported from AffinidiTdk.Common).

```csharp
using AffinidiTdk.AuthProvider;
using AffinidiTdk.Common;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;

// init AuthProvider

var tokenHandler = new TokenInjectingHandler(
    () => authProvider.FetchProjectScopedTokenAsync(),
    new HttpClientHandler()
);

var httpClient = new HttpClient(tokenHandler);

// Share httpClient across multiple TDK clients
var walletApi = new WalletApi(httpClient, new Configuration());
```

### See Examples and Tests

- [Hook-based usage](https://github.com/affinidi/affinidi-tdk-dotnet/blob/main/examples/HookAuthExample/HookAuthExample.cs)
- [Tests](https://github.com/affinidi/affinidi-tdk-dotnet/tree/main/tests)
