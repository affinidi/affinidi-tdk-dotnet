using Xunit;
using IntegrationTests.Fixtures;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("IamClientTests", DisableParallelization = true)]
    public class IamClientCollection : ICollectionFixture<IamApiFixture> { }
}
