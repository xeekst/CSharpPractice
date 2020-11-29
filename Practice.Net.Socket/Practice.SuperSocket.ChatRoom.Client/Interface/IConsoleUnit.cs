using System;
using System.Threading.Tasks;

namespace Practice.SuperSocket.ChatRoom.Client.Interface
{
    public interface IConsoleUnit
    {
        Task PrintTextLeftLine(string text, ConsoleColor fontColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black);
        Task PrintText(string text, ConsoleColor fontColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black);
        Task PrintTextRightLine(string text, ConsoleColor fontColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black);
        void RemoveLastRow(int rowLast);
    }
}