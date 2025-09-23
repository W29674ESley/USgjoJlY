// 代码生成时间: 2025-09-24 00:30:37
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStatisticsAnalyzerApp
{
    /// <summary>
    /// A class responsible for performing statistical analysis on data.
    /// </summary>
    public class DataStatisticsAnalyzer
    {
        /// <summary>
        /// Calculates the mean of an array of numbers.
        /// </summary>
        /// <param name="data">The array of numbers to calculate the mean from.</param>
        /// <returns>The mean of the numbers in the array.</returns>
        public double CalculateMean(double[] data)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Data array is null or empty");
            }

            double sum = data.Sum();
            return sum / data.Length;
        }

        /// <summary>
        /// Calculates the median of an array of numbers.
        /// </summary>
        /// <param name="data">The array of numbers to calculate the median from.</param>
        /// <returns>The median of the numbers in the array.</returns>
        public double CalculateMedian(double[] data)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Data array is null or empty");
            }

            int middle = data.Length / 2;
            double[] sortedData = data.OrderBy(x => x).ToArray();
            return data.Length % 2 == 0 ? (sortedData[middle - 1] + sortedData[middle]) / 2 : sortedData[middle];
        }

        /// <summary>
        /// Calculates the mode of an array of numbers.
        /// </summary>
        /// <param name="data">The array of numbers to calculate the mode from.</param>
        /// <returns>The mode of the numbers in the array.</returns>
        public double CalculateMode(double[] data)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Data array is null or empty");
            }

            var frequency = new Dictionary<double, int>();
            foreach (var number in data)
            {
                if (frequency.ContainsKey(number))
                {
                    frequency[number]++;
                }
                else
                {
                    frequency[number] = 1;
                }
            }

            var maxCount = frequency.Values.Max();
            return frequency.Where(kvp => kvp.Value == maxCount).Select(kvp => kvp.Key).DefaultIfEmpty(0).FirstOrDefault();
        }

        /// <summary>
        /// Calculates the standard deviation of an array of numbers.
        /// </summary>
        /// <param name="data">The array of numbers to calculate the standard deviation from.</param>
        /// <returns>The standard deviation of the numbers in the array.</returns>
        public double CalculateStandardDeviation(double[] data)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Data array is null or empty");
            }

            double mean = CalculateMean(data);
            double variance = data.Average(d => Math.Pow(d - mean, 2));
            return Math.Sqrt(variance);
        }
    }
}
