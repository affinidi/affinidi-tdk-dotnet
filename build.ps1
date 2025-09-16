# Requires PowerShell 5+ (Windows, macOS, Linux with pwsh)
# Run from repo root

$ErrorActionPreference = "Stop"

Write-Host "Cleaning previous build artifacts..."
Remove-Item -Recurse -Force -ErrorAction SilentlyContinue .\nupkgs

Write-Host "Packing all packages to ./nupkgs..."
dotnet pack src/Packages/AffinidiTdk.AuthProvider/AffinidiTdk.AuthProvider.csproj --output ./nupkgs
dotnet pack src/Packages/AffinidiTdk.Common/AffinidiTdk.Common.csproj --output ./nupkgs

Write-Host "Packing all clients to ./nupkgs..."
dotnet pack src/Clients/CredentialIssuanceClient/src/AffinidiTdk.CredentialIssuanceClient/AffinidiTdk.CredentialIssuanceClient.csproj --output ./nupkgs
dotnet pack src/Clients/CredentialVerificationClient/src/AffinidiTdk.CredentialVerificationClient/AffinidiTdk.CredentialVerificationClient.csproj --output ./nupkgs
dotnet pack src/Clients/IamClient/src/AffinidiTdk.IamClient/AffinidiTdk.IamClient.csproj --output ./nupkgs
dotnet pack src/Clients/IotaClient/src/AffinidiTdk.IotaClient/AffinidiTdk.IotaClient.csproj --output ./nupkgs
dotnet pack src/Clients/LoginConfigurationClient/src/AffinidiTdk.LoginConfigurationClient/AffinidiTdk.LoginConfigurationClient.csproj --output ./nupkgs
dotnet pack src/Clients/VaultDataManagerClient/src/AffinidiTdk.VaultDataManagerClient/AffinidiTdk.VaultDataManagerClient.csproj --output ./nupkgs
dotnet pack src/Clients/WalletsClient/src/AffinidiTdk.WalletsClient/AffinidiTdk.WalletsClient.csproj --output ./nupkgs

Write-Host "Building all projects in solution..."
dotnet build AffinidiTdk.sln

Write-Host "Restoring and running tests for packages..."
dotnet restore tests/Packages/AffinidiTdk.AuthProvider.Tests/AffinidiTdk.AuthProvider.Tests.csproj --configfile nuget.config
dotnet test tests/Packages/AffinidiTdk.AuthProvider.Tests/AffinidiTdk.AuthProvider.Tests.csproj
dotnet restore tests/Packages/AffinidiTdk.Common.Tests/AffinidiTdk.Common.Tests.csproj --configfile nuget.config
dotnet test tests/Packages/AffinidiTdk.Common.Tests/AffinidiTdk.Common.Tests.csproj

Write-Host "Restoring and running integration tests..."
dotnet restore tests/IntegrationTests/IntegrationTests.csproj --configfile nuget.config
dotnet test tests/IntegrationTests/IntegrationTests.csproj

Write-Host "Build, pack, and test complete."
