using System;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Client.Interface;

namespace Practice.SuperSocket.ChatRoom.Client.Implement
{
    public class ConsoleUnit : IConsoleUnit
    {
        private int _screenWidth = 70;
        public bool SetScreenWidth(int width)
        {
            _screenWidth = width;
            return true;
        }
        public Task PrintText(string text, ConsoleColor fontColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
        {
            Console.ForegroundColor = fontColor;
            Console.BackgroundColor = backgroundColor;

            Console.Write(text);

            ResetConsole();
            return Task.CompletedTask;
        }

        public Task PrintTextLeftLine(string text, ConsoleColor fontColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = fontColor;
            Console.BackgroundColor = backgroundColor;

            int len = Console.WindowWidth - text.Length;
            string formatText = "{0,-" + _screenWidth + "}";
            Console.WriteLine(formatText, text);
            ResetConsole();
            return Task.CompletedTask;
        }

        public Task PrintTextRightLine(string text, ConsoleColor fontColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = fontColor;
            Console.BackgroundColor = backgroundColor;

            string formatText = "{0," + _screenWidth + "}";
            Console.WriteLine(formatText, text);

            ResetConsole();
            return Task.CompletedTask;
        }

        public void RemoveLastRow(int rowLast = 1)
        {
            Console.SetCursorPosition(0, Console.CursorTop - rowLast);
            for (int index = 0; index < rowLast; index++)
            {
                Console.WriteLine("{0," + _screenWidth + "}", string.Empty);
            }
            Console.SetCursorPosition(0, Console.CursorTop - rowLast);
        }

        public void ResetConsole()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}