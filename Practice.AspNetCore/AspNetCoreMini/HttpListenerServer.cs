using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AspNetCoreMini.Core;
using AspNetCoreMini.Core.Interface;

namespace AspNetCoreMini
{
    public class HttpListenerServer : IServer
    {
        private readonly HttpListener _httpListener;
        private readonly string[] _urls;

        public HttpListenerServer(params string[] urls)
        {
            _httpListener = new HttpListener();
            _urls = urls.Any() ? urls : new string[] { "http://localhost:5000/" };
        }
        public async Task StartAsync(RequestDelegate handler)
        {
            _urls.ToList().ForEach(u => _httpListener.Prefixes.Add(u));
            _httpListener.Start();

            while (true)
            {
                var listenerContext = await _httpListener.GetContextAsync();
                var feature = new HttpListenerFeature(listenerContext);
                var features = new FeatureCollection()
                    .Set<IHttpRequestFeature>(feature)
                    .Set<IHttpResponseFeature>(feature);
                var httpContext = new HttpContext(features);
                await handler(httpContext);
                listenerContext.Response.Close();
            }
        }
    }

    public static partial class Extensions
    {
        public static IWebHostBuilder UseHttpListener(this IWebHostBuilder builder, params string[] urls)
        { 
            return builder.UseServer(new HttpListenerServer(urls)); 
        }
    }
}