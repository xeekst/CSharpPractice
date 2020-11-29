using System;
using System.Collections.Specialized;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace AspNetCoreMini.Core
{
    public class HttpContext
    {
        public HttpRequest request { get; }
        public HttpResponse Response { get; }

        public HttpContext(IFeatureCollection feature)
        {
            request = new HttpRequest(feature);
            Response = new HttpResponse(feature);
        }
    }
}
