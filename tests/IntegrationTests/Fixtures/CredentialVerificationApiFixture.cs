using System;
using System.Net.Http;
using System.Threading.Tasks;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;
using IntegrationTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests.Fixtures
{
    public class CredentialVerificationApiFixture : IAsyncLifetime
    {
        public DefaultApi DefaultApi { get; private set; }

        public CredentialVerificationApiFixture()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;
            Configuration config = new Configuration();

            DefaultApi = new DefaultApi(httpClient, config);
        }

        // Runs BEFORE any tests (init shared resources)
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        // Runs AFTER all tests are done (clean up)
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
