using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(async()=>{
                var host = SuperSocketHostBuilder.Create<TextPackageInfo, LinePipelineFilter>()
                .UsePackageHandler(async (s, p) =>
                {
                    await s.SendAsync(Encoding.UTF8.GetBytes(p.Text.ToString()+ "\r\n"));
                })
                // .UseCommand((commandOptions)=>{
                //     commandOptions.AddCommand<ADD>();
                // })
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
                        { "serverOptions:listeners:0:port", "4040" }
                    });
                }).Build();
                
                await host.RunAsync();
            });
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
