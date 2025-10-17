# Contributing to Affinidi TDK

When contributing to this repository, please first discuss the change you wish to make by creating a new [GitHub issue](https://github.com/affinidi/affinidi-tdk-dotnet/issues/new).

Clients are generated intenally by Affinidi based on our API's. So, please don't update the client code and instead create an issue.

### Installing requirements

1. Install [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
2. Install [Cake](https://github.com/cake-build/cake) tool:

```bash
dotnet tool install --global Cake.Tool
```

## Developing

Follow the steps below to install dependencies and run the test suite

### Environment Setup

Navigate to the tests folder and copy the example environment file:

```bash
cd tests

cp .env.example .env

cd ..
```

Edit .env file and update only the following fields with your credentials:

- PROJECT_ID – [Getting started and how to create a project](https://docs.affinidi.com/docs/get-started/create-project/)

- KEY_ID, PASSPHRASE, PRIVATE_KEY, TOKEN_ID – [How to generate PAT credentials](https://docs.affinidi.com/dev-tools/affinidi-tdk/get-access-token/)

Leave all other fields in the .env file unchanged.

📌 The .env.example file must be copied and modified within the /tests folder.
All scripts should be run from the root folder of the project.

### Run Tests

To buld, compile and run test suite, run the script:

```bash
dotnet cake
```

To run only integration tests:

```bash
dotnet cake --target IntegrationTest
```

❗️NOTE: If your project contains more than 7 wallets, all wallets will be deleted 💣 to prevent test failures caused by backend ResourceLimitExceeded errors (maximum of 10 wallets allowed per project).

### Formating and fixing lint issues

Before pushing code, please make sure to propperly format.

```bash
dotnet cake --target Format
```

### Code quality expectations

1. Ensure the pipeline checks are finished successfully.
2. Ensure the pull request doesn't contain redundant comments, console.log, etc.
3. Ensure your code is covered with unit and integration tests (NOTE: no mocks/stubs in integration tests).
4. Avoid adding comments to explain what code does, code should be self-explanatory and clean.
5. Avoid using variable names like `i` or abbreviations - names should be simple and unambiguous.
6. Follow [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) guide for commit messages writing
7. Make sure commits are signed

## Code of Conduct

### Our Pledge

In the interest of fostering an open and welcoming environment, we as
contributors and maintainers pledge to make participation in our project and
our community a harassment-free experience for everyone, regardless of age, body
size, disability, ethnicity, gender identity and expression, level of experience,
nationality, personal appearance, race, religion, or sexual identity and
orientation.

### Our Standards

Examples of behavior that contributes to creating a positive environment
include:

- Using welcoming and inclusive language
- Being respectful of differing viewpoints and experiences
- Gracefully accepting constructive criticism
- Focusing on what is best for the community
- Showing empathy towards other community members
- Avoiding obvious comments about things like code styling and indentation.
  - If you see yourself wanting to do that more than once - open an issue with a repo to update the Linter/Prettier rules to address this concern once and for all. **Code reviews should be about logic, not indenting or adding more newlines**

Examples of unacceptable behavior by participants include:

- The use of sexualized language or imagery and unwelcome sexual attention or
  advances
- Trolling, insulting/derogatory comments, and personal or political attacks
- Public or private harassment
- Publishing others' private information, such as a physical or electronic
  address, without explicit permission
- Other conduct which could reasonably be considered inappropriate in a
  professional setting
