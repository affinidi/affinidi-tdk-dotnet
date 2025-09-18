#!/bin/bash
set -eu -o pipefail

echo "Cleaning previous build artifacts..."
rm -rf affected*
dotnet clean
rm -rf ./nupkgs/*.nupkgs

dotnet new sln --name AffinidiTdk --force
dotnet sln AffinidiTdk.sln add $(find . -name "*.csproj")

echo "Lint"
dotnet format --verify-no-changes  AffinidiTdk.sln --exclude src/Clients/

echo "Building all projects in solution..."
dotnet build AffinidiTdk.sln

echo "Packing all packages to ./nupkgs..."
dotnet pack AffinidiTdk.sln --output nupkgs/

echo "Restoring and running tests for packages..."
dotnet restore tests/Packages/AffinidiTdk.AuthProvider.Tests/AffinidiTdk.AuthProvider.Tests.csproj --configfile nuget.config
dotnet test tests/Packages/AffinidiTdk.AuthProvider.Tests/AffinidiTdk.AuthProvider.Tests.csproj
dotnet restore tests/Packages/AffinidiTdk.Common.Tests/AffinidiTdk.Common.Tests.csproj --configfile nuget.config
dotnet test tests/Packages/AffinidiTdk.Common.Tests/AffinidiTdk.Common.Tests.csproj

echo "Restoring and running integration tests..."
dotnet restore tests/IntegrationTests/IntegrationTests.csproj --configfile nuget.config
dotnet test tests/IntegrationTests/IntegrationTests.csproj

echo "Build, pack, and test complete."
