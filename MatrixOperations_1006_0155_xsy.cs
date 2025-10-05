// 代码生成时间: 2025-10-06 01:55:27
using System;
using System.Collections.Generic;

namespace MatrixLibrary
{
    /// <summary>
    /// Represents a matrix with integer elements.
    /// </summary>
    public class Matrix
    {
        private int[,] elements;

        /// <summary>
        /// Initializes a new instance of the Matrix class.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Matrix dimensions must be greater than zero.");
            }

            elements = new int[rows, columns];
        }

        /// <summary>
        /// Gets or sets the element at the specified position.
        /// </summary>
        /// <param name="row">The row index of the element.</param>
        /// <param name="column">The column index of the element.</param>
        /// <returns>The element at the specified position.</returns>
        public int this[int row, int column]
        {
            get => elements[row, column];
            set => elements[row, column] = value;
        }

        /// <summary>
        /// Adds two matrices together.
        /// </summary>
        /// <param name="matrix">The matrix to add to this matrix.</param>
        /// <returns>A new matrix that is the sum of this matrix and the given matrix.</returns>
        public Matrix Add(Matrix matrix)
        {
            if (elements.GetLength(0) != matrix.elements.GetLength(0) || elements.GetLength(1) != matrix.elements.GetLength(1))
            {
                throw new InvalidOperationException("Matrices must be the same size to add.");
            }

            var result = new Matrix(elements.GetLength(0), elements.GetLength(1));
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < elements.GetLength(1); j++)
                {
                    result[i, j] = this[i, j] + matrix[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="matrix">The matrix to multiply this matrix by.</param>
        /// <returns>A new matrix that is the product of this matrix and the given matrix.</returns>
        public Matrix Multiply(Matrix matrix)
        {
            if (elements.GetLength(1) != matrix.elements.GetLength(0))
            {
                throw new InvalidOperationException("The number of columns in the first matrix must be equal to the number of rows in the second matrix to multiply.");
            }

            var result = new Matrix(elements.GetLength(0), matrix.elements.GetLength(1));
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.elements.GetLength(1); j++)
                {
                    for (int k = 0; k < elements.GetLength(1); k++)
                    {
                        result[i, j] += this[i, k] * matrix[k, j];
                    }
                }
            }
            return result;
        }
    }
}
