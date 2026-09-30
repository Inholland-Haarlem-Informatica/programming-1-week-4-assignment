using NUnit.Framework;
using Assignment7;

namespace Assignment7.Tests
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

        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(9, false)]
        [TestCase(10, false)]
        public void BookSeat_VariousSeats_ReturnsExpectedResult(int seatNumber, bool expected)
        {
            // Arrange
            bool[] seats = new bool[10];
            for (int i = 0; i < seats.Length; i++)
                seats[i] = true;    // all seats available

            // Act
            _program.BookSeat(seats, seatNumber);
            bool result = seats[seatNumber - 1];    // book seat and get availability of that seat

            // Assert
            Assert.That(expected, Is.EqualTo(result), $"For seat {seatNumber}, expected {expected} but got {result}.");
        }
    }
}