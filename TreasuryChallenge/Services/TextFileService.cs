using System;
using System.IO;
using TreasuryChallenge.Interfaces;

namespace TreasuryChallenge.Services
{
    public class TextFileService : IFileService
    {
        public void SaveText(string text)
        {
            try
            {
                File.WriteAllText("aleatory-file.txt", text);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine("Unauthorized access on folder");
                throw exception;
            }
        }
    }
}
