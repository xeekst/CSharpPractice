using System;
using System.Threading.Tasks;
using AspNetCoreMini.Core.Interface;

namespace AspNetCoreMini.Core
{
    public class WebHost : IWebHost
    {
        private readonly IServer _server;
        private readonly RequestDelegate _handler;

        public WebHost(IServer server,RequestDelegate handler){
            _server = server;
            _handler = handler;
        }

        public async Task StartAsync()
        {
            Console.WriteLine("started");
            await _server.StartAsync(_handler);
        }
    }
}