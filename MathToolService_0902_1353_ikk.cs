// 代码生成时间: 2025-09-02 13:53:18
using System;

namespace MathToolApp.Services
{
    /// <summary>
    /// The MathToolService class provides a set of mathematical operations.
    /// </summary>
    public class MathToolService
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts the second number from the first.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The difference between the two numbers.</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides the first number by the second.
        /// </summary>
        /// <param name="a">First number (numerator).</param>
        /// <param name="b">Second number (denominator).</param>
        /// <returns>The quotient of the two numbers.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the denominator is zero.</exception>
        public double Divide(double a, double b)
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
        /// <param name="baseNumber">The base number.</param>
        /// <param name="exponent">The exponent to which the base number is raised.</param>
        /// <returns>The result of the base number raised to the exponent.</returns>
        public double Power(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }
    }
}