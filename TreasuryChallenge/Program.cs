using System;
using System.Diagnostics;
using TreasuryChallenge.Services;

namespace TreasuryChallenge
{
    class Program
    {
        private static readonly int LineLength = 7;

        static void Main(string[] args)
        {
            int linesCount;
            do
            {
                LogWriter.LogConsole("Tell me the number (a positive number) of lines do you need and press enter.");
                LogWriter.LogConsole("0 - to end program");
                linesCount = int.Parse(Console.ReadLine());
                if (linesCount == 0)
                {
                    Console.WriteLine("The program will be closed.");
                    return;
                }

            } while (linesCount < 0);

            int version;
            do
            {
                LogWriter.LogConsole("1 - to generated uniques codes.");
                LogWriter.LogConsole("2 - to generated repeatable codes.");
                LogWriter.LogConsole("0 - to end program");
                version = int.Parse(Console.ReadLine());
                if (linesCount == 0)
                {
                    Console.WriteLine("The program will be closed.");
                    return;
                }

            } while (version < 0);

            try
            {
                LogWriter.LogFile($"Starting algorithm at {DateTime.UtcNow.ToString()}");

                var stopwatch = Stopwatch.StartNew();
                var codes = string.Empty;

                switch (version)
                {
                    case 1: codes = new UniqueRandomCodeGeneratorService().Generate(linesCount, LineLength); break;
                    case 2: codes = new RepeatableRandomCodeGeneratorService().Generate(linesCount, LineLength); break;
                }
                
                new WriteGeneratedCodesService(new TextFileService()).Write(codes);
                stopwatch.Stop();

                LogWriter.LogFile("Algorithm ended.");
                LogWriter.LogFile("Execution time: " + stopwatch.ElapsedMilliseconds);
            }
            catch (Exception exception)
            {
                LogWriter.LogFile("A exception has ocurred: " + exception.Message);
                LogWriter.LogFile(exception.StackTrace);
            }
        }
    }
}