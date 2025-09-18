# Tests for Affinidi TDK

## Setup Instructions

Follow the steps below to install dependencies and run the test suite

### Environment Setup

Copy the example environment configuration file and provide necessary credentials:

```bash
cp .env.example .env
```

Update only your PROJECT_ID ([link to docs how to create a project](https://docs.affinidi.com/docs/get-started/create-project/)) and PAT details (KEY_ID, PASSPHRASE, PRIVATE_KEY, TOKEN_ID - [link to docs how to create a PAT](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/)) in your .env file.

Leave all other fields unchanged.

### Run Tests

Run all tests:

```bash
dotnet test"
```

Logs verbosity can be changed via:

```bash
dotnet test --logger "console;verbosity=normal"
```

Run tests for a specific file:

```bash
dotnet test --filter DisplayName~WalletApiTests
```

For more options refer to [xUnit docs](https://learn.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests?pivots=xunit).
