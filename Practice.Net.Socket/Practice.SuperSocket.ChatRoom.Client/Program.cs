using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Client.Implement;

namespace Practice.SuperSocket.ChatRoom.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("请输入数字选择模式: 1: 手动输入消息 2. 自动发消息");
            Console.WriteLine();
            string k = Console.ReadLine();

            ChatSocket chatSocket = new ChatSocket("127.0.0.1", 4040);
            ChatView chatView = new ChatView(chatSocket);

            Thread.Sleep(1000);
            // while(true){
            //     Console.WriteLine("=========2======");
            //     //chatView.ReceiveMessageBox.ForEach(e=>Console.WriteLine(e.Message));
            //     if(await chatView.ReceiveMessageBox.Any(s=>s.Message.Contains("Well,You have been in Room"))){
            //         break;
            //     }
            //     Thread.Sleep(3000);
            // }

            // chatSocket.SendRamMessage("ADD 1 2\r\n");
            if (k == "1")
            {
                ConsoleKeyInfo cki;
                do
                {
                    Console.WriteLine("Press a 'F' to Input Message; press the 'Q' key to quit.");

                    // Your code could perform some useful task in the following loop. However,
                    // for the sake of this example we'll merely pause for a quarter second.

                    while (true)
                    {
                        if (Console.KeyAvailable == true)
                        {
                            cki = Console.ReadKey(true);
                            if (cki.Key == ConsoleKey.F || cki.Key == ConsoleKey.Q)
                                break;
                        }
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }
                    if (cki.Key == ConsoleKey.F) await chatView.ListenInputForSend();
                } while (cki.Key != ConsoleKey.Q);
                Console.WriteLine("<You been quit!...>");

            }
            else
            {
                int inde = 1;
                while (true)
                {
                    Thread.Sleep(300);
                    chatSocket.SendMessage($"{chatView._chator.ChatorId} {chatView._chator.ChatorName} gagads{inde++}");
                }
            }


            Console.ReadLine();
            // Console.WriteLine("Hello World!");
        }
    }
}
