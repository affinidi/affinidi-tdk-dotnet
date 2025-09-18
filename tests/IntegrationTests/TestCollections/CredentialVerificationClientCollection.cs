using Xunit;
using IntegrationTests.Fixtures;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("CredentialVerificationClientTests", DisableParallelization = true)]
    public class CredentialVerificationClientCollection : ICollectionFixture<CredentialVerificationApiFixture> { }
}
