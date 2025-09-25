# HookAuthExample

This example shows how to interact with `AffinidiTdk.WalletsClient` using a **hook-based token injector** (`TokenInjectingHandler`).

## How it works

- Uses a `DelegatingHandler` to inject a fresh token into every request.
- Auth is handled behind-the-scenes via a hook (`Func<Task<string>>`).
- Clean and reusable for integration tests or multiple clients.

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

With logs

```bash
AFFINIDI_TDK_LOG_LEVEL=info dotnet run
```

## Explore more

👀 Explore /src/Clients/WalletsClient/docs for all available methods.
