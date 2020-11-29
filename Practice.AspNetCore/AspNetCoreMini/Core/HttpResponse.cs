using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreMini.Core.Interface;

namespace AspNetCoreMini.Core
{
    public class HttpResponse
    {
        private readonly IHttpResponseFeature _feature;

        public NameValueCollection Headers => _feature.Headers;
        public Stream Body => _feature.Body;
        public int StatusCode { get => _feature.StatusCode; set => _feature.StatusCode = value; }

        public HttpResponse(IFeatureCollection features) => _feature = features.Get<IHttpResponseFeature>();
    }
    public static partial class Extensions
    {
        public static Task WriteAsync(this HttpResponse response, string contents)
        {
            var buffer = Encoding.UTF8.GetBytes(contents);
            return response.Body.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
