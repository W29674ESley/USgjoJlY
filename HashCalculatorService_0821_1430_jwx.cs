// 代码生成时间: 2025-08-21 14:30:17
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Maui.Controls;

namespace HashCalculator
{
    /// <summary>
    /// Provides functionality to calculate hash values for strings.
    /// </summary>
    public class HashCalculatorService
    {
        /// <summary>
        /// Calculates the SHA256 hash of a given string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The SHA256 hash of the input string as a hexadecimal string.</returns>
        public string CalculateSHA256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Calculates the SHA512 hash of a given string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The SHA512 hash of the input string as a hexadecimal string.</returns>
        public string CalculateSHA512Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            using (SHA512 sha512 = SHA512.Create())
            {
                // Compute hash
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
