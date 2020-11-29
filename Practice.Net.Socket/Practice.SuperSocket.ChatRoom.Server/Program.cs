using System;
using System.Threading.Tasks;

namespace Practice.SuperSocket.ChatRoom.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ChatRoomServer server = new ChatRoomServer();
            await server.RunAsync();
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
