#!/bin/bash
set -eu -o pipefail

echo "Restoring and running tests for packages..."
dotnet restore tests/Packages/AffinidiTdk.AuthProvider.Tests/AffinidiTdk.AuthProvider.Tests.csproj --configfile nuget.config
dotnet test tests/Packages/AffinidiTdk.AuthProvider.Tests/AffinidiTdk.AuthProvider.Tests.csproj

dotnet restore tests/Packages/AffinidiTdk.Common.Tests/AffinidiTdk.Common.Tests.csproj --configfile nuget.config
dotnet test tests/Packages/AffinidiTdk.Common.Tests/AffinidiTdk.Common.Tests.csproj

echo "Restoring and running integration tests..."
dotnet restore tests/IntegrationTests/IntegrationTests.csproj --configfile nuget.config
dotnet test tests/IntegrationTests/IntegrationTests.csproj

echo "All tests complete."
