using System;
using System.Threading.Tasks;

namespace Practice.SuperSocket.WebSocket
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WebSocket ws = new WebSocket();
            await ws.RunAsync();
            //Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
