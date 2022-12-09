using System;
using System.IO;

namespace TreasuryChallenge.Services
{
    public static class LogWriter
    {
        public static void LogConsole(string message)
        {
            Console.WriteLine(message);
        }
        public static void LogFile(string message)
        {
            using StreamWriter streamWriter = File.AppendText("logfile.txt");
            streamWriter.WriteLine(message);
        }
    }
}
