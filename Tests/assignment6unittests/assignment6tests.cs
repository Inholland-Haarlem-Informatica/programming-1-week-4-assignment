using NUnit.Framework;
using Assignment6;

namespace Assignment6.Tests
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

        [TestCase(6000, 6000)]
        [TestCase(100, 100)]
        public void ThrowDice_VariousScores_ReturnsExpectedGrade(int numberOfThrows, int expectedSum)
        {
            // Arrange
            int[] counts = new int[6];

            // Act
            _program.ThrowDice(counts, numberOfThrows);

            int sum = 0;
            for (int i = 0; i < counts.Length; i++)
                sum += counts[i];

            // Assert
            Assert.That(sum, Is.EqualTo(expectedSum), $"For throws {numberOfThrows}, expected sum {expectedSum} but got {sum}.");
        }

        [TestCase(6000, "Number of throws of value 1 = ")]
        [TestCase(6000, "Number of throws of value 6 = ")]
        public void UserInput_VariousNumbers_DisplaysExpectedResult(int input, string expected)
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            _program.Start();

            // Assert
            Assert.That(sw.ToString(), Does.Contain(expected), $"For input {input}, expected '{expected}'");
        }
    }
}