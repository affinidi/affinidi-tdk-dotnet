using IntegrationTests.Fixtures;
using Xunit;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("WalletsClientTests", DisableParallelization = true)]
    public class WalletsClientCollection : ICollectionFixture<WalletsApiFixture> { }
}
