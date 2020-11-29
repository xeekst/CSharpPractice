using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Practice.SuperSocket.ChatRoom.Server.Commands;
using Practice.SuperSocket.ChatRoom.Server.Components;
using Practice.SuperSocket.ChatRoom.Server.Interface;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.ChatRoom.Server
{
    public class ChatRoomServer
    {
        public ChatRoomServer() { }

        public async Task RunAsync()
        {
            var host = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
                // .UsePackageHandler(async (s, p) =>
                // {
                //     await s.SendAsync(Encoding.UTF8.GetBytes(p.Key.ToString() + "\r\n"));
                // })
                .UseCommand((commandOptions)=>{
                    //commandOptions.AddCommand<GOROOM>();

                    // register all commands in one aassembly
                    commandOptions.AddCommandAssembly(typeof(PWD).GetTypeInfo().Assembly);
                })
                .UseSession<ChatorSession>()
                .UseInProcSessionContainer()
                .ConfigureLogging((hostCtx, loggingBuilder) =>
                {
                    loggingBuilder.AddConsole();
                })
                .ConfigureServices((hostCtx, services) =>
                {
                    services.AddSingleton<IRoomManager>(new RoomManager(roomNumber:3));
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

            //var sc = host.GetSessionContainer();
            // sc.GetSessions().ToList().ForEach(async e => await e.Channel.SendAsync(Encoding.UTF8.GetBytes("s")));
            //GlobalCache.AppServer = host;
            await host.RunAsync();
        }
    }
}
