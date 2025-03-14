using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Options;

namespace ClickSendApi.Client;

internal class AuthHeaderHandler(IOptions<ClickSendConfig> options) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var username = options.Value.Username;
        var password = options.Value.ApiKey;
        var basicAuthenticationHeaderValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthenticationHeaderValue);
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
