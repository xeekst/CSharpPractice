using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreMini.Core;
using WebHostBuilder = AspNetCoreMini.Core.WebHostBuilder;

namespace AspNetCoreMini
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new WebHostBuilder()
            .UseHttpListener("http://localhost:5005/")
            .Configure(app =>
                app.Use(FooMiddleware)
                   .Use(BarMiddleware)
                   .Use(BazMiddleware)
            )
            .Build()
            .StartAsync();
        }

        public static RequestDelegate FooMiddleware(RequestDelegate next)
        {
            return async context =>
            {
                await context.Response.WriteAsync("Foo=>");
                await next(context);
            };
        }

        public static RequestDelegate BarMiddleware(RequestDelegate next)
        {
            return async context =>
            {
                await context.Response.WriteAsync("Bar=>");

                await next(context);
            };
        }

        public static RequestDelegate BazMiddleware(RequestDelegate next)
        {
            return context => context.Response.WriteAsync("Baz");
        }
    }
}
