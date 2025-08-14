// 代码生成时间: 2025-08-14 20:54:52
using System;
using System.Security.Cryptography;
using System.Text;

namespace MAUIApp
{
    /// <summary>
    /// A utility class that provides functionality to calculate hash values.
    /// </summary>
    public class HashCalculationTool
    {
        /// <summary>
        /// Calculates the hash of a given input string.
        /// </summary>
        /// <param name="input">The string to calculate the hash for.</param>
        /// <param name="algorithm">The hashing algorithm to use.</param>
        /// <returns>The hash value of the input string.</returns>
        public static string CalculateHash(string input, HashAlgorithm algorithm)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            using (algorithm)
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = algorithm.ComputeHash(bytes);

                // Convert the byte array to a hexadecimal string.
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.AppendFormat("{0:x2}", b);
                }
                return sb.ToString();
            }
        }
    }

    /// <summary>
    /// A static class containing extension methods for the HashCalculationTool.
    /// </summary>
    public static class HashCalculationToolExtensions
    {
        /// <summary>
        /// Calculates the SHA256 hash of a given input string.
        /// </summary>
        /// <param name="input">The string to calculate the hash for.</param>
        /// <returns>The SHA256 hash value of the input string.</returns>
        public static string CalculateSha256Hash(this string input)
        {
            using SHA256 sha256 = SHA256.Create();
            return HashCalculationTool.CalculateHash(input, sha256);
        }

        /// <summary>
        /// Calculates the SHA512 hash of a given input string.
        /// </summary>
        /// <param name="input">The string to calculate the hash for.</param>
        /// <returns>The SHA512 hash value of the input string.</returns>
        public static string CalculateSha512Hash(this string input)
        {
            using SHA512 sha512 = SHA512.Create();
            return HashCalculationTool.CalculateHash(input, sha512);
        }
    }
}
