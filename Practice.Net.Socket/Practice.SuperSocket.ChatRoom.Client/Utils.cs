using System;
using System.Linq;

namespace Practice.SuperSocket.ChatRoom.Client
{
    public class Utils
    {
        public static string[] lowChars = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public static string[] upChars = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static string[] numberChars = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public static string GenRandomName(){
            var chars = lowChars.ToList().Concat(upChars).ToList();
            string name = string.Empty;
            Random rnd = new Random();
            for(int index=0;index < 6;index++){
                name += chars[rnd.Next(0,chars.Count)];
            }
            for(int index=0;index < 2;index++){
                name += numberChars[rnd.Next(0,numberChars.Length)];
            }
            return name;
        }
    }
}