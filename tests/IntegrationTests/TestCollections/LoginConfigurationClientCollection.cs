using IntegrationTests.Fixtures;
using Xunit;

namespace IntegrationTests.TestCollections
{
    [CollectionDefinition("LoginConfigurationClientTests", DisableParallelization = true)]
    public class LoginConfigurationClientCollection : ICollectionFixture<LoginConfigurationApiFixture> { }
}
