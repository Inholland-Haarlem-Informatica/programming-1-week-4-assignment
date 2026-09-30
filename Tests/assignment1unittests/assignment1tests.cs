using Assignment1;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Assignment1.Tests
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

        [TestCase(1, "Element 1 is: 25")]
        [TestCase(1, "Element 20 is: 71")]
        [TestCase(9, "Element 1 is: 43")]
        [TestCase(9, "Element 20 is: 80")]
        public void DisplayArray_VariousNumbers_PrintsExpectedMessage(int seed, string expected)
        {
            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            int[] numbers = new int[20];
            _program.FillArray(numbers, seed);
            _program.DisplayArray(numbers);

            // Assert
            string actual = WhitespaceRegex().Replace(sw.ToString(), "").Trim();
            string expectedNormalized = WhitespaceRegex().Replace(expected, "").Trim();
            Assert.That(actual, Does.Contain(expectedNormalized).IgnoreCase, $"For seed {seed}, expected '{expected}'");
        }

        [GeneratedRegex(@"\s+")]
        private static partial Regex WhitespaceRegex();
    }
}