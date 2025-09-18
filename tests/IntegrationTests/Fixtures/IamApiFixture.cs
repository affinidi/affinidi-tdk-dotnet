using Xunit;
using Xunit.Abstractions;

using System;
using System.Net.Http;
using System.Threading.Tasks;

using AffinidiTdk.IamClient.Api;
using AffinidiTdk.IamClient.Client;
using AffinidiTdk.IamClient.Model;

using IntegrationTests.Helpers;

namespace IntegrationTests.Fixtures
{
    public class IamApiFixture : IAsyncLifetime
    {
        public ProjectsApi ProjectsApi { get; private set; }
        public PoliciesApi PoliciesApi { get; private set; }

        public IamApiFixture()
        {
            HttpClient httpClient = AuthHelper.Instance.HttpClient;
            Configuration config = new Configuration();

            ProjectsApi = new ProjectsApi(httpClient, config);
            PoliciesApi = new PoliciesApi(httpClient, config);
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
