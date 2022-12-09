using System.Collections.Generic;
using System.Drawing;

namespace TreasuryChallenge.Services
{
    public class UniqueRandomCodeGeneratorService : RandomCodesGeneratorService
    {
        public override string Generate(int linesCount, int lineLength)
        {
            var lines = new List<string>();
            var count = 0;
            var sameCodeGeneratedCount = 0;

            while (count != linesCount)
            {
                var code = GetCode(lineLength);

                var index = lines.BinarySearch(code);
                if (index >= 0)
                {
                    sameCodeGeneratedCount++;
                    LogWriter.LogFile($"The code {code} already exists. {sameCodeGeneratedCount} attempts to generate repeated codes!");
                    continue;
                }

                count++;
                LogWriter.LogConsole($"{count} unique codes have already been generated!");
                if (index == -1)
                {
                    lines.Insert(0, code);
                    continue;
                }

                lines.Insert(~index, code);
            }

            LogWriter.LogFile($"There were {sameCodeGeneratedCount} attempts to generate repeated codes!");

            return string.Join('\n', lines);
        }
    }
}
