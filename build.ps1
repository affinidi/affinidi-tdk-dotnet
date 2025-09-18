# Requires PowerShell 5+ (Windows, macOS, Linux with pwsh)
# Run from repo root

$ErrorActionPreference = "Stop"

Write-Host "Cleaning previous build artifacts..."
dotnet clean
Remove-Item -Recurse -Force ./nupkgs

dotnet new sln --name AffinidiTdk --force
$csprojFiles = Get-ChildItem -Recurse -Filter *.csproj | ForEach-Object { $_.FullName }
foreach ($file in $csprojFiles) {
    dotnet sln AffinidiTdk.sln add $file
}

Write-Host "Lint"
dotnet format --verify-no-changes AffinidiTdk.sln --exclude src/Clients/

Write-Host "Building all projects in solution..."
dotnet build AffinidiTdk.sln
Write-Host "Packing all packages to ./nupkgs..."
dotnet pack AffinidiTdk.sln --output ./nupkgs/

Write-Host "Restoring and running tests for packages..."
dotnet restore tests/Packages/AffinidiTdk.AuthProvider.Tests/AffinidiTdk.AuthProvider.Tests.csproj --configfile nuget.config
dotnet test tests/Packages/AffinidiTdk.AuthProvider.Tests/AffinidiTdk.AuthProvider.Tests.csproj

dotnet restore tests/Packages/AffinidiTdk.Common.Tests/AffinidiTdk.Common.Tests.csproj --configfile nuget.config
dotnet test tests/Packages/AffinidiTdk.Common.Tests/AffinidiTdk.Common.Tests.csproj

Write-Host "Restoring and running integration tests..."
dotnet restore tests/IntegrationTests/IntegrationTests.csproj --configfile nuget.config
dotnet test tests/IntegrationTests/IntegrationTests.csproj

Write-Host "Build, pack, and test complete."
