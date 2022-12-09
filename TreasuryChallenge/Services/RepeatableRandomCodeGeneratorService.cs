using System.Collections.Generic;
using System.Drawing;

namespace TreasuryChallenge.Services
{
    public class RepeatableRandomCodeGeneratorService : RandomCodesGeneratorService
    {
        public override string Generate(int linesCount, int lineLength)
        {
            var lines = new List<string>();

            for (var i = 0; i < linesCount; i++)
            {
                LogWriter.LogConsole($"{i+1} codes have already been generated!");
                lines.Add(GetCode(lineLength));
            }
            
            return string.Join('\n', lines);
        }
    }
}
