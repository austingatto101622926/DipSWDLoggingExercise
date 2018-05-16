using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorialiser.Classes
{
    /// <summary>
    /// This should be thrown when the text entered into textboxInput
    /// is not able to be parsed to an integer.
    /// </summary>
    public class NotIntegerException:Exception
    {
        // add a constructor such that the DEFAULT 
        // message for this exception is (if for example 1.23 is entered):
        // "NotIntegerExcpetion: 1.23"

        public NotIntegerException(string input) : base($"NotIntegerException: {input}")
        {}
    }

    /// <summary>
    /// This should be thrown when nothing / or empty white space is entered
    /// into textboxInput
    /// </summary>
    public class NullValueException : Exception
    {
        // modify the constructor such that the DEFAULT 
        // message for this exception is:

        // "NullValueException: No Value Entered"
        public NullValueException() : base("NullValueException: No Value Entered")
        { }
    }


    /// <summary>
    /// This should be raised when the integer passed into the 
    /// Calculator.Factorial method is < 1
    /// </summary>

    public class NumberTooLowException : Exception
    {
        // modify the constructor such that the DEFAULT 
        // message for this exception is (if for example -6 is entered):

        // "NumberTooLowException: -6 "
        public NumberTooLowException(int num) : base($"NumberTooLowException: {num}")
        {}
    }

    /// <summary>
    /// This should be raised when the integer passed into the 
    /// Calculator.Factorial method is > 30
    /// </summary>
    public class NumberTooHighException : Exception
    {
        // modify the  constructor such that the DEFAULT 
        // message for this exception is (if for example 36 is entered):

        // "NumberTooHighException: 36 "

        public NumberTooHighException(int num) : base($"NumberTooHighException: {num}")
        {}
   }


}
