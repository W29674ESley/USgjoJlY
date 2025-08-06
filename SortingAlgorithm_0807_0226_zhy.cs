// 代码生成时间: 2025-08-07 02:26:06
 * Description:
 * This class provides an implementation of various sorting algorithms.
 * It demonstrates best practices in C# programming, including code structure,
 * error handling, commenting, and maintainability.
 */

using System;
using System.Collections.Generic;

namespace MauiSortingApp
{
    // SortingAlgorithm class to encapsulate sorting functionalities
    public class SortingAlgorithm
    {
        // Method to sort an array using Bubble Sort algorithm
        public int[] BubbleSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap the elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }

        // Method to sort an array using Quick Sort algorithm
        public int[] QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            return QuickSortInternal(array, 0, array.Length - 1);
        }

        private int[] QuickSortInternal(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                QuickSortInternal(array, low, pivotIndex - 1);
                QuickSortInternal(array, pivotIndex + 1, high);
            }

            return array;
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    // Swap array[i] and array[j]
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            // Swap array[i+1] and array[high] (or pivot)
            int temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;

            return i + 1;
        }
    }
}
