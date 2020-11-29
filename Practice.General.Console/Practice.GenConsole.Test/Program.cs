using System;
using System.Threading;
using System.Threading.Tasks;
using GenericConsole.Units;

namespace Practice.GenConsole.Test
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("downloading , wait a moment please ...");
            IConsoleUnit con = new ConsoleUnit();

            // for (int i = 0; i <= 100; i++)
            // {
            //     Thread.Sleep(100);
            //     if (i != 0) await con.RemoveLastRow();
            //     await con.PrintTextLeftLine($"{i}% downloaded ...", ConsoleColor.Blue);
            //     //Console.WriteLine("                    ");
            //     //Console.SetCursorPosition(0, Console.CursorTop - 1);
            //     //Console.WriteLine(i + "% downloaded ...");
            // }
            // Console.WriteLine("\ndownload completely !");
            // Console.ReadKey();
            // ClearCurrentConsoleLine();
            // Console.Clear();
            // Console.WriteLine("Hello World!");

            // Console.WriteLine("{0,-20} {1,20}", "Finished!", "[ok]");

            // string[] names = { "012345678901234567890123456789\n0123456789\n0123456789", "Bridgette", "Carla", "Daniel",
            //              "Ebenezer", "Francine", "George" };
            // decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80,
            //                      16.75m };

            // Console.WriteLine("{0,-20} {1,15}\n", "Name", "Hours");
            // for (int ctr = 0; ctr < names.Length; ctr++)
            //     Console.WriteLine("{0,-20} {1,15}", names[ctr], hours[ctr]);

            ChatRoomView view = new ChatRoomView();
            TestChatRoomView(view);
            var m = string.Empty;
            while ((m = Console.ReadLine()) != null)
            {
                view.OnSendMessage(new ChatMessageModel() { Message = m, ChatorId = "1001" });
            }
            //TestAlignment();
        }
        public static void TestChatRoomView(ChatRoomView view)
        {

            view.OnReceiveMessage(new ChatMessageModel() { Message = "hihi!", ChatorId = "412" });
            view.OnReceiveMessage(new ChatMessageModel() { Message = "无名氏", ChatorId = "1001" });
            view.OnReceiveMessage(new ChatMessageModel() { Message = "hsdfaihi", ChatorId = "4312" });
        }
        public static void TestAlignment()
        {
            string[] names = { "Adam", "Bridgette", "Carla", "Daniel",
                         "Ebenezer", "Francine", "George" };
            decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80,
                                 16.75m };

            Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");
            for (int ctr = 0; ctr < names.Length; ctr++)
                Console.WriteLine("{0,-20} {1,6}", names[ctr], hours[ctr]);

        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
