using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AffinidiTdk.Common.Http
{
    public class TokenInjectingHandler : DelegatingHandler
    {
        private readonly Func<Task<string>> _getTokenAsync;

        public TokenInjectingHandler(Func<Task<string>> getTokenAsync, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            _getTokenAsync = getTokenAsync;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _getTokenAsync();

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
