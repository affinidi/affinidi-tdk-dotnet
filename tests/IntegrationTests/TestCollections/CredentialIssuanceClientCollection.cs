using IntegrationTests.Fixtures;
using Xunit;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("CredentialIssuanceClientTests", DisableParallelization = true)]
    public class CredentialIssuanceClientCollection : ICollectionFixture<CredentialIssuanceApiFixture> { }
}
