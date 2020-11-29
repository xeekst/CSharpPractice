using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Practice.SuperSocket.Command;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket
{
    public class MultipleCommand
    {
        public async Task RunAsync()
        {
            var host = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
            .UseCommand(options =>
            {
                options.AddCommand<ADD>();
                options.AddCommand<MULT>();
                // ？ 感觉全局的不生效
                //options.AddGlobalCommandFilter<AsyncCommandFilterAttribute>();
            })
            .ConfigureLogging((hostCtx, loggingBuilder) =>
            {
                loggingBuilder.AddConsole();
            })
            .ConfigureSuperSocket(options =>
            {
                options.Name = "Command Server";
                options.Listeners = new[] {
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