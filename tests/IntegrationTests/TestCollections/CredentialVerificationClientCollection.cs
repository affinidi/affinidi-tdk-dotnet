using IntegrationTests.Fixtures;
using Xunit;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("CredentialVerificationClientTests", DisableParallelization = true)]
    public class CredentialVerificationClientCollection : ICollectionFixture<CredentialVerificationApiFixture> { }
}
