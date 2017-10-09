using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace api2
{
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly Antlr.Runtime.Misc.Func<Task<string>> getToken;
        
        public AuthenticatedHttpClientHandler(Antlr.Runtime.Misc.Func<Task<string>> getToken)
        {
            if (getToken == null) throw new Exception("getToken");
            this.getToken = getToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;    
            if (auth != null)
            {
                var token = await getToken().ConfigureAwait(false);
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);
            }
            
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}