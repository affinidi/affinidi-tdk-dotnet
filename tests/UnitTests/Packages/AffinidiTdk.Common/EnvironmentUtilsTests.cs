using AffinidiTdk.Common;
using Xunit;

namespace UnitTests.Packages
{
    public class EnvironmentUtilsTests
    {
        [Theory]
        [InlineData("local", "local")]
        [InlineData("LOCAL", "local")]
        [InlineData("dev", "dev")]
        [InlineData("DEV", "dev")]
        [InlineData("prod", "prod")]
        [InlineData("PROD", "prod")]
        [InlineData(null, "prod")] // No environment variable set
        public void FetchEnvironment_ReturnsCorrectEnumValue(string? tdkEnvironment, string expectedEnvironment)
        {
            // Arrange
            // Ensure no environment variable is set

            // Arrange: Set the AFFINIDI_TDK_ENVIRONMENT environment variable for the test case
            System.Environment.SetEnvironmentVariable("AFFINIDI_TDK_ENVIRONMENT", tdkEnvironment);

            string result = EnvironmentUtils.FetchEnvironment();
            Assert.Equal(expectedEnvironment, result);
        }

        [Fact]
        public void FetchApiGwUrl_ReturnsCorrectUrlForProduction()
        {
            var url = EnvironmentUtils.FetchApiGwUrl(Environment.PRODUCTION);
            Assert.Equal("https://apse1.api.affinidi.io", url);
        }

        [Fact]
        public void FetchRegion_ReturnsDefaultRegion()
        {
            var region = EnvironmentUtils.FetchRegion();
            Assert.Equal("ap-southeast-1", region);
        }
    }
}
