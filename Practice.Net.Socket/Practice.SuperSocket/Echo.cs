using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperSocket;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket
{
    public class Echo
    {
        public async Task RunAsync()
        {
            var host = SuperSocketHostBuilder.Create<TextPackageInfo, LinePipelineFilter>()
            .ConfigurePackageHandler(async (s, p) =>
            {
                await s.SendAsync(Encoding.UTF8.GetBytes(p.Text.ToString()+ "\r\n"));
            })
            .ConfigureLogging((hostCtx, loggingBuilder) =>
            {
                loggingBuilder.AddConsole();
            })
            .ConfigureSuperSocket(options =>
            {
                options.Name = "Echo Server";
                options.Listeners = new [] {
                    new ListenOptions
                    {
                        Ip = "Any",
                        Port = 4040
                    }
                };
            }).Build();
            
            await host.RunAsync();
        }
    }
}