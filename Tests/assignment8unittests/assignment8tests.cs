using NUnit.Framework;

namespace Assignment8.Tests
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

        [TestCase(1, 100, "135  51 244 396 339 227 188 482  46 332  10 135 171 505 352 338 152 318 363 361")]
        [TestCase(4, 150, "418 506 292 216   1  23 360 235 247 385 115 306 202 286 402 275 282 248 403 442")]
        [TestCase(9, 200, "225 240  25 250 130 222 480 489  41 307 472 257 420  71 136 336 333 298 471 410")]
        public void UpdateNumbers_VariousInputs_ReturnsExpectedResult(int seed, int comparisonNumber, string expected)
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            int[] numbers = new int[20];
            _program.FillArray(numbers, seed);
            _program.UpdateNumbers(numbers, comparisonNumber);
            _program.DisplayNumbers(numbers);

            // Assert
            Assert.That(sw.ToString(), Does.Contain(expected), $"For seed {seed}, expected '{expected}'");
        }
    }
}