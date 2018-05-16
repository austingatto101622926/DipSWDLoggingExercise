using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;


namespace Factorialiser.Classes
{
    public static class Calculator
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Calculates and returns the factorial of the input integer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static int Factorial(int input)
        {
            logger.Trace($"calculating: {input}");
            try
            {
                if (input < 1) throw new NumberTooLowException(input);
                if (input > 30) throw new NumberTooHighException(input);

                int result = input;
                for (int i = input-1; i > 1; i--)
                {
                    result *= i;
                }
                return result;
            }
            catch (NumberTooLowException ex)
            {
                logger.Debug($"input too low: {input}");
                throw ex;
            }
            catch (NumberTooHighException ex)
            {
                logger.Debug($"input too high: {input}");
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error($"unknown error msg: {ex.Message}");
                throw ex;
            }
            // this method should:

            // return the factorial of the integer enetered (or a recursive step toward it)
            // in this normal operation, every step / recursion should be logged (Trace) in the following format
            // (if for example an input of 5 was received)
            // "Calcuator.Factorial: calculating: 5"

            // if the number entered is < 1 this should throw a NumberTooLowException.
            // if this occurs it should be logged (Debug) with the message as below:
            // "Calcuator.Factorial: input too low: -5"

            // if the number entered is >30 this should throw a NumberTooHighException.
            // if this occurs it should be logged (Debug) with the message as below:
            // "Calcuator.Factorial: input too high: 45"

        }
    }
}
