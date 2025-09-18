using IntegrationTests.Fixtures;
using Xunit;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("IotaClientTests", DisableParallelization = true)]
    public class IotaClientCollection : ICollectionFixture<IotaApiFixture> { }
}
