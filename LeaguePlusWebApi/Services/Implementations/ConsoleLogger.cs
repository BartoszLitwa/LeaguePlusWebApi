using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string content)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(content);
            Console.ResetColor();
        }

        public void LogSuccessful(string content)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(content);
            Console.ResetColor();
        }

        public void LogInformation(string content)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(content);
            Console.ResetColor();
        }

        public void LogWarning(string content)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(content);
            Console.ResetColor();
        }

        public void LogDevInfo(string content)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(content);
            Console.ResetColor();
        }
    }
}
