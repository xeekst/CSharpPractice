using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperSocket;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.GameService
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Factory.StartNew(async () =>
            {
                var host = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
                .UsePackageHandler(async (s, p) =>
                {
                    await s.SendAsync(Encoding.UTF8.GetBytes(p.Key.ToString() + "\r\n"));
                })
                .UseSession<PlaySession>()
                .UseHostedService<GameService<StringPackageInfo>>()
                .ConfigureLogging((hostCtx, loggingBuilder) =>
                {
                    loggingBuilder.AddConsole();
                })
                .ConfigureAppConfiguration((hostCtx, configApp) =>
                {
                    configApp.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "serverOptions:name", "TestServer" },
                        { "serverOptions:listeners:0:ip", "Any" },
                        { "serverOptions:listeners:0:port", "5040" }
                    });
                })
                .Build();

                await host.RunAsync();
            });
            Console.ReadLine();
        }
    }
}
