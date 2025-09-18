using Xunit;
using IntegrationTests.Fixtures;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("IotaClientTests", DisableParallelization = true)]
    public class IotaClientCollection : ICollectionFixture<IotaApiFixture> { }
}
