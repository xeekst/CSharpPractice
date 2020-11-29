using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperSocket;
using SuperSocket.ProtoBase;


namespace Practice.SuperSocket{
    public class TelnetConfig{
        public async Task RunAsync()
        {
            var host = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
            .ConfigurePackageHandler(async (s, package) =>
            {
                var result = 0;

                switch (package.Key.ToUpper())
                {
                    case ("ADD"):
                        result = package.Parameters
                            .Select(p => int.Parse(p))
                            .Sum();
                        break;

                    case ("SUB"):
                        result = package.Parameters
                            .Select(p => int.Parse(p))
                            .Aggregate((x, y) => x - y);
                        break;

                    case ("MULT"):
                        result = package.Parameters
                            .Select(p => int.Parse(p))
                            .Aggregate((x, y) => x * y);
                        break;
                }

                await s.SendAsync(Encoding.UTF8.GetBytes(result.ToString() + "\r\n"));
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