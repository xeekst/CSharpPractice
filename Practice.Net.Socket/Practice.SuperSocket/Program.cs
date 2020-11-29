using System;
using System.Threading.Tasks;

namespace Practice.SuperSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0 Echo Server
            // var t = Task.Factory.StartNew(async()=>{
            //     Echo server = new Echo();
            //     await server.RunAsync();
            // });

            //1. 初始 服务器
            // var t = Task.Factory.StartNew(async()=>{
            //     Telnet telnet = new Telnet();
            //     await telnet.RunAsync();
            // });

            //2. 使用配置文件启动
            // var t = Task.Factory.StartNew(async()=>{
            //     TelnetConfig telnet = new TelnetConfig();
            //     await telnet.RunAsync();
            // });

            //3. 使用命令类启动
            var t = Task.Factory.StartNew(async()=>{
                MultipleCommand server = new MultipleCommand();
                await server.RunAsync();
            });
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
