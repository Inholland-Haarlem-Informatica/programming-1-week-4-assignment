using NUnit.Framework;
using Assignment4;

namespace assignment4.Tests
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

        [TestCase(new int[] { 15, 76, 48 }, 1)]
        [TestCase(new int[] { 87, 41, 76 }, 0)]
        [TestCase(new int[] { 49, 68, 100 }, 2)]
        public void GetHighestGradeIndex_VariousNumbers_ReturnsExpectedResult(int[] grades, int expected)
        {
            // Act
            int result = _program.GetHighestGradeIndex(grades);

            // Assert
            Assert.That(result, Is.EqualTo(expected), $"For grades {grades[0]}, {grades[1]}, {grades[2]}, expected {expected} but got {result}.");
        }

        [TestCase("Programming 1\n3\nPeter\nDanny\nJulia\n65\n45\n98", "Student Julia has the highest grade: 98")]
        [TestCase("Programming 1\n3\nPeter\nDanny\nJulia\n45\n98\n65", "Student Danny has the highest grade: 98")]
        [TestCase("Programming 1\n3\nPeter\nDanny\nJulia\n98\n65\n45", "Student Peter has the highest grade: 98")]
        public void UserInput_VariousNumbers_DisplaysExpectedResult(string input, string expected)
        {
            using var sw = new StringWriter();
            using var sr = new StringReader(input);
            Console.SetOut(sw);
            Console.SetIn(sr);

            // Act
            _program.Start();

            // Assert
            Assert.That(sw.ToString(), Does.Contain(expected), $"For input {input}, expected '{expected}'");
        }
    }
}