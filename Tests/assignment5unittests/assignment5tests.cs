using NUnit.Framework;
using Assignment5;

namespace Assignment5.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private Program _program;

        [SetUp]
        public void Setup()
        {
            _program = new Program();
        }

        [TestCase(new int[] { 10, 12, 76, 12 }, 12, 2)]
        [TestCase(new int[] { 10, 12, 76, 12 }, 8, 0)]
        [TestCase(new int[] { 10, 12, 76, 12 }, 10, 1)]
        [TestCase(new int[] { 99, 12, 99, 76, 99 }, 99, 3)]
        public void CountSearchValue_VariousNumbers_ReturnsExpectedResult(int[] numbers, int searchValue, int expected)
        {
            // Act
            int result = _program.CountSearchValue(numbers, searchValue);

            // Assert
            Assert.That(result, Is.EqualTo(expected), $"For numbers {numbers[0]}, {numbers[1]}, {numbers[2]}, {numbers[3]}, expected {expected} but got {result}.");
        }

        [TestCase("11\n22\n11\n44\n11\n66\n11\n88\n11\n0\n11", 11, 5)]
        [TestCase("11\n22\n33\n44\n55\n66\n77\n88\n99\n0\n22", 22, 1)]
        [TestCase("11\n22\n33\n44\n55\n66\n77\n88\n99\n0\n13", 13, 0)]
        [TestCase("1\n2\n3\n4\n5\n6\n7\n8\n9\n10\n11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n1", 1, 1)]
        public void UserInput_VariousNumbers_DisplaysExpectedResult(string input, int searchValue, int expectedCount)
        {
            using var sw = new StringWriter();
            using var sr = new StringReader(input);
            Console.SetOut(sw);
            Console.SetIn(sr);

            // Act
            _program.Start();

            string output = sw.ToString();

            // Regex matches search value first, followed by the count anywhere later in the string
            // e.g., matches "11" ... "5" regardless of spelling, punctuation, or extra prompt text
            string pattern = $@"\b{searchValue}\b.*\b{expectedCount}\b";

            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(
                output,
                pattern,
                System.Text.RegularExpressions.RegexOptions.Singleline
            );

            Assert.That(
                isMatch,
                Is.True,
                $"Expected output to show search value ({searchValue}) and count ({expectedCount}).\nActual Output:\n{output}"
            );
        }
    }
}
