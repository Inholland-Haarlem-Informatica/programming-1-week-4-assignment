using NUnit.Framework;
using Assignment3;
using System.IO;

namespace Assignment3.Tests
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

        [TestCase(new int[] { 1, 4, 8 }, 13)]
        [TestCase(new int[] { 87, 41, 76 }, 204)]
        [TestCase(new int[] { 49, 2, 25 }, 76)]
        public void CalculateSum_VariousNumbers_ReturnsExpectedResult(int[] numbers, int expected)
        {
            // Act
            int result = _program.CalculateSum(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(expected), $"For numbers {numbers[0]}, {numbers[1]}, {numbers[2]}, expected {expected} but got {result}.");
        }

        [TestCase(new int[] { 1, 4, 8 }, (13 / 3.0))]
        [TestCase(new int[] { 87, 41, 76 }, (204 / 3.0))]
        [TestCase(new int[] { 49, 2, 25 }, (76 / 3.0))]
        public void CalculateAverage_VariousNumbers_ReturnsExpectedResult(int[] numbers, double expected)
        {
            // Act
            double result = _program.CalculateAverage(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(expected), $"For numbers {numbers[0]}, {numbers[1]}, {numbers[2]}, expected {expected} but got {result}.");
        }
    }
}