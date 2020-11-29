using System;
using Microsoft.AspNetCore.Builder;

namespace AspNetCoreMini.Core.Interface
{
    public interface IWebHostBuilder
    {
        IWebHostBuilder UseServer(IServer server);
        IWebHostBuilder Configure(Action<IApplicationBuilder> configure);
        IWebHost Build();
    }
}