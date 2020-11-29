using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using SuperSocket.WebSocket.Server;

namespace Practice.SuperSocket.WebSocket
{
    public class WebSocket
    {
        public async Task RunAsync()
        {
            var host = WebSocketHostBuilder.Create()
            .UseWebSocketMessageHandler(
                async (session, message) =>
                {
                    await session.SendAsync(message.Message);
                }
            ).UseCommand<StringPackageInfo, StringPackageConverter>(commandOptions =>
            {
                // register commands one by one
                commandOptions.AddCommand<ADD>();
            })
            .ConfigureAppConfiguration((hostCtx, configApp) =>
            {
                configApp.AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "serverOptions:name", "WebsockServer" },
                    { "serverOptions:listeners:0:ip", "Any" },
                    { "serverOptions:listeners:0:port", "4040" }
                });
            })
            .ConfigureLogging((hostCtx, loggingBuilder) =>
            {
                loggingBuilder.AddConsole();
            })
            .Build();

            await host.RunAsync();
        }
    }
}