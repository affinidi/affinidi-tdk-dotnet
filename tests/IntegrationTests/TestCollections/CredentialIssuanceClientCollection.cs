using Xunit;
using IntegrationTests.Fixtures;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("CredentialIssuanceClientTests", DisableParallelization = true)]
    public class CredentialIssuanceClientCollection : ICollectionFixture<CredentialIssuanceApiFixture> { }
}
