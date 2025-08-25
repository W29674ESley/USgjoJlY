// 代码生成时间: 2025-08-26 01:34:17
using System;
using Microsoft.Data.SqlClient;

namespace MAUIApp
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Executes a query with parameterized SQL to prevent SQL injection.
        /// </summary>
        /// <param name="query">The SQL query with parameters.</param>
        /// <param name="parameters">The parameters for the query.</param>
        /// <returns>The result of the query execution.</returns>
        public SqlDataReader ExecuteQuery(string query, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        return command.ExecuteReader();
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception details and rethrow for further handling
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// Executes a non-query SQL command (like INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="commandText">The SQL command text.</param>
        /// <param name="commandParameters">The parameters for the command.</param>
        /// <returns>The number of affected rows.</returns>
        public int ExecuteNonQuery(string commandText, SqlParameter[] commandParameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddRange(commandParameters);
                        return command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception details and rethrow for further handling
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
