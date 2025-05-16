using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AppBlazor.Data
{
    public class HttpInterceptor : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Content != null)
            {
                var content = await request.Content.ReadAsStringAsync();
                Console.WriteLine($"Request enviada a: {request.RequestUri}");
                Console.WriteLine($"Cuerpo de la solicitud: {content}");
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}