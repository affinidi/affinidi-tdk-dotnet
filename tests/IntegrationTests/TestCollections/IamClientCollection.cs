using IntegrationTests.Fixtures;
using Xunit;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("IamClientTests", DisableParallelization = true)]
    public class IamClientCollection : ICollectionFixture<IamApiFixture> { }
}
