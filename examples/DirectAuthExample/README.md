# DirectAuthExample

This example shows how to interact with `AffinidiTdk.WalletsClient` using **direct token-based authentication**.

## How it works

- Initializes `AuthProvider` once using `Lazy<AuthProvider>`.
- Fetches a project-scoped token via `authProvider.FetchProjectScopedTokenAsync()`.
- Passes the token manually to `WalletApi` configuration.

## Setup

Update `Program.cs` 

```csharp
// KeyId = "YOUR_KEY_ID", // [OPTIONAL]
// Passphrase = "YOUR_PASSPHRASE", // [OPTIONAL] 
TokenId = "YOUR_TOKEN_ID",
PrivateKey = "YOUR_PRIVATE_KEY",
ProjectId = "YOUR_PROJECT_ID"
```

with your Affinidi ProjectId and PAT secrets (check [getting started with Affinidi](https://docs.affinidi.com/docs/get-started/create-project/) for the details).

## Run example

```bash
dotnet run
```

## Explore more

👀 Explore /src/Clients/WalletsClient/docs for all available methods.
