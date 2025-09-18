using Xunit;
using IntegrationTests.Fixtures;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("LoginConfigurationClientTests", DisableParallelization = true)]
    public class LoginConfigurationClientCollection : ICollectionFixture<LoginConfigurationApiFixture> { }
}
