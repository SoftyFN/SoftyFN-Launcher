using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softy
{
    class Softy
    {
        public static void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("SoftyFN");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("] " + message + "\n");
        }

        public static void LogNoBreak(string message)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("SoftyFN");
            Console.ForegroundColor = old;
            Console.Write("] " + message);
        }
    }
}
