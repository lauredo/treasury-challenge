using NUnit.Framework;
using System.Linq;
using TreasuryChallenge.Services;

namespace TreasuryChallenge.UnitTests
{
    [TestFixture]
    public class UniqueRandomCodesGeneratorServiceUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsGeneratingRequiredCodeLengthAndCodesCount()
        {
            var length = 7;
            var linesCount = 10;

            var codes = new UniqueRandomCodeGeneratorService().Generate(linesCount, length);
            var splittedCodes = codes.Split('\n');

            Assert.Multiple(() =>
            {
                Assert.That(splittedCodes.Count(), Is.EqualTo(linesCount));
                Assert.That(splittedCodes.All(code => code.Length == length), Is.True);
            });
        }

        [Test]
        public void IsGeneratingOneMillionCodes()
        {
            var length = 7;
            var linesCount = 1000000;

            var codes = new UniqueRandomCodeGeneratorService().Generate(linesCount, length);
            var splittedCodes = codes.Split('\n');

            Assert.Multiple(() =>
            {
                Assert.That(splittedCodes.Count(), Is.EqualTo(linesCount));
            });
        }

        [Test]
        public void IsGeneratingOneMillionUniquesCodes()
        {
            var length = 7;
            var linesCount = 1000000;

            var codes = new UniqueRandomCodeGeneratorService().Generate(linesCount, length);
            var splittedCodes = codes.Split('\n');

            Assert.Multiple(() =>
            {
                Assert.That(splittedCodes.Count(), Is.EqualTo(linesCount));
                Assert.That(splittedCodes.Count(), Is.EqualTo(splittedCodes.Distinct().Count()));
            });
        }

        [Test]
        public void IsGeneratingTenMillionUniquesCodes()
        {
            var length = 7;
            var linesCount = 10000000;

            var codes = new UniqueRandomCodeGeneratorService().Generate(linesCount, length);
            var splittedCodes = codes.Split('\n');

            Assert.Multiple(() =>
            {
                Assert.That(splittedCodes.Count(), Is.EqualTo(linesCount));
                Assert.That(splittedCodes.Count(), Is.EqualTo(splittedCodes.Distinct().Count()));
            });
        }
    }
}