# AffinidiTdk.AuthProvider

`AffinidiTdk.AuthProvider` is a .NET TDK package for managing authentication tokens, including JWT validation, signing, and fetching project-scoped tokens. It integrates with your API Gateway to help you authenticate and handle tokens securely within your .NET applications.

## Requirements

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Features

- **JWT Validation**: Validate JWT tokens with a public key fetched from the API Gateway.
- **Project Scoped Tokens**: Fetch project-scoped tokens to interact with secure resources.

## Installation

To use it in your project, you can install it via NuGet:

```bash
dotnet add package AffinidiTdk.AuthProvider
```

## Run Tests

```bash
cd tests
```

Copy the example environment configuration file and provide necessary credentials:

```bash
cp .env.example .env
```

Update only your PROJECT_ID ([link to docs how to create a project](https://docs.affinidi.com/docs/get-started/create-project/)) and PAT details (KEY_ID, PASSPHRASE, PRIVATE_KEY, TOKEN_ID - [link to docs how to create a PAT](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/)) in your .env file.

Leave all other fields unchanged.

Run all tests:

```bash
dotnet test
```
