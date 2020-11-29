using System;
using System.Threading.Tasks;

namespace Practice.SuperSocket.ChatRoom.Client.Implement
{
    public class ChatUIUnit : ConsoleUnit
    {
        public ChatUIUnit()
        {
            ResetConsole();
        }
        private ConsoleColor _otherMessageColor = ConsoleColor.Yellow;

        private ConsoleColor _selfMessageColor = ConsoleColor.Green;
        //private ConsoleColor _sendColor = ConsoleColor.Yellow;

        public async Task ReceiveMessage(string message, bool isSelf = false)
        {
            if (isSelf)
            {
                await PrintTextRightLine(message, _selfMessageColor);
            }
            else
            {
                await PrintTextLeftLine(message, _otherMessageColor);
            }

        }

        public async Task SendMessage(string message)
        {
            await base.PrintTextRightLine(message, _selfMessageColor);
        }
    }
}