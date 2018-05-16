using System;
using NUnit.Framework;
using Factorialiser.Classes;

namespace FactorialiserTests
{
    [TestFixture]
    public class ExceptionTests
    {
        [Test]
        [TestCase(31, "NumberTooHighException: 31")]
        [TestCase(35, "NumberTooHighException: 35")]
        [TestCase(107, "NumberTooHighException: 107")]
        public void NumberTooHighException_IsThrown_MessageCorrect(int input, string expectedResult)
        {
            // arrange
            var ex = new NumberTooHighException(input);

            // Assert
            Assert.That(ex.Message.Equals(expectedResult));

        }


        [Test]
        [TestCase(0, "NumberTooLowException: 0")]
        [TestCase(-35, "NumberTooLowException: -35")]
        [TestCase(-107, "NumberTooLowException: -107")]
        public void NumberTooLowException_IsThrown_MessageCorrect(int input, string expectedResult)
        {
            // arrange
            var ex = new NumberTooLowException(input);

            // Assert
            Assert.That(ex.Message.Equals(expectedResult));
        }

        [Test]
        [TestCase("1.23", "NotIntegerException: 1.23")]
        [TestCase("bollocks", "NotIntegerException: bollocks")]
        [TestCase("true", "NotIntegerException: true")]
        public void NotIntegerException_IsThrown_MessageCorrect(string input, string expectedResult)
        {
            // arrange
            var ex = new NotIntegerException(input);

            // Assert
            Assert.That(ex.Message.Equals(expectedResult));
        }

        [Test]
        public void NullValueException_IsThrown_MessageCorrect()
        {
            // arrange
            var ex = new NullValueException();

            // Assert
            Assert.That(ex.Message.Equals("NullValueException: No Value Entered"));
        }





    }
}
