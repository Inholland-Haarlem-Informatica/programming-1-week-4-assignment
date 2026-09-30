using Assignment2;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Assignment2.Tests
{
    [TestFixture]
    public partial class ProgramTests
    {
        private Program _program;

        [SetUp]
        public void Setup()
        {
            _program = new Program();
        }

        [TestCase(1, "25 12 47 78 66 44 36 95 11 65 03 25 33 99 69 66 29 62 71 71")]
        [TestCase(4, "82 100 57 42 02 06 70 45 48 75 24 60 39 56 79 53 55 48 79 87")]
        [TestCase(9, "43 46 06 48 27 43 94 96 10 60 93 50 82 16 29 66 65 58 93 80")]
        public void DisplayArray_VariousNumbers_ReturnsExpectedResult(int seed, string expected)
        {
            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            int[] numbers = new int[20];
            _program.FillArray(numbers, seed);
            _program.DisplayArray(numbers);

            // Normalise
            int[] expectedNumbers = ExtractNumbers(expected);
            int[] actualNumbers = ExtractNumbers(sw.ToString());

            // Assert
            Assert.That(actualNumbers, Is.EqualTo(expectedNumbers),
                $"For seed {seed}, output numbers did not match expected numbers.");
        }

        [TestCase(1, 3)]
        [TestCase(4, 2)]
        [TestCase(9, 6)]
        public void GetSmallestNumber_VariousNumbers_ReturnsExpectedResult(int seed, int expected)
        {
            // Act
            int[] numbers = new int[20];
            _program.FillArray(numbers, seed);
            int result = _program.GetSmallestNumber(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(expected), $"For seed {seed}, expected {expected} but got {result}.");
        }

        private static int[] ExtractNumbers(string input)
        {
            return [.. NumbersRegex()
                .Matches(input)
                .Select(m => int.Parse(m.Value))];
        }

        [GeneratedRegex(@"\d+")]
        private static partial Regex NumbersRegex();

    }
}