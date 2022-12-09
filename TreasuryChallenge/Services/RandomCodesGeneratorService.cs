using System;
using System.Collections.Generic;
using System.Text;

namespace TreasuryChallenge.Services
{
    public abstract class RandomCodesGeneratorService
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public abstract string Generate(int linesCount, int lineLength);
        protected string GetCode(int lineLength)
        {
            var lineSb = new StringBuilder();
            var charCopy = Chars;

            for (var j = 0; j < lineLength; j++)
            {
                var c = GetChar(charCopy);

                lineSb.Append(c);
                charCopy = charCopy.Replace(c, string.Empty);
            }

            return lineSb.ToString();
        }

        private string GetChar(string charList) =>
            charList[new Random().Next(charList.Length)].ToString();
    }
}
