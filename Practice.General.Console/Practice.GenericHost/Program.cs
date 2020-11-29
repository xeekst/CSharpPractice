using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Practice.GenericHost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            // .ConfigureHostConfiguration(configHost =>
            // {
            //     configHost.SetBasePath(Directory.GetCurrentDirectory());
            //     configHost.AddJsonFile("hostsettings.json", optional: true);
            //     configHost.AddEnvironmentVariables(prefix: "DOTNET_");
            //     configHost.AddCommandLine(args);
            // })
            // 配置各种配置
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddEnvironmentVariables(prefix: "DOTNET_");
                config.AddJsonFile("hostsettings.json", optional: true, reloadOnChange: true)
                     .AddJsonFile($"hostsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddCommandLine(args);
            })
            // 直接配置环境变量
            //.UseEnvironment("Development")
            // 配置注册服务
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<LifetimeEventsHostedService>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
    }
}
