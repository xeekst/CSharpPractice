using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreMini.Core.Interface
{
    public class ApplicationBuilder : IApplicationBuilder
    {
        private readonly List<Func<RequestDelegate, RequestDelegate>> _middlewares = new List<Func<RequestDelegate, RequestDelegate>>();
        public RequestDelegate Build()
        {
            _middlewares.Reverse();
            return httpContext =>
            {
                RequestDelegate next = n => { n.Response.StatusCode = 404; return Task.CompletedTask; };
                foreach (var middleware in _middlewares)
                {
                    next = middleware(next);
                }
                return next(httpContext);
            };
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }
    }
}