using Xunit;
using IntegrationTests.Fixtures;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("WalletsClientTests", DisableParallelization = true)]
    public class WalletsClientCollection : ICollectionFixture<WalletsApiFixture> { }
}
