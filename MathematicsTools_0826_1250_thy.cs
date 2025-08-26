// 代码生成时间: 2025-08-26 12:50:44
using System;

namespace MAUIApp
{
    /// <summary>
    /// MathematicsTools class provides a set of mathematical operations.
    /// </summary>
    public static class MathematicsTools
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public static double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts one number from another.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number to be subtracted from the first.</param>
        /// <returns>The result of the subtraction.</returns>
        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides one number by another.
        /// </summary>
        /// <param name="a">Dividend.</param>
        /// <param name="b">Divisor.</param>
        /// <returns>The quotient of the division.</returns>
        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }

        /// <summary>
        /// Calculates the power of a base number.
        /// </summary>
        /// <param name="base">The base number.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>The result of the power operation.</returns>
        public static double Power(double @base, double exponent)
        {
            return Math.Pow(@base, exponent);
        }
    }
}
