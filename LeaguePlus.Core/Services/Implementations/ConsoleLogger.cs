using System;

namespace LeaguePlus.Core
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string content)
        {
            Log(content, ConsoleColor.Red);
        }

        public void LogSuccessful(string content)
        {
            Log(content, ConsoleColor.Green);
        }

        public void LogInformation(string content)
        {
            Log(content, ConsoleColor.White);
        }

        public void LogWarning(string content)
        {
            Log(content, ConsoleColor.Yellow);
        }

        public void LogDevInfo(string content)
        {
            Log(content, ConsoleColor.Blue);
        }

        public void Log(string content, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            var time = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[{time}] {content}");
            Console.ResetColor();
        }
    }
}
