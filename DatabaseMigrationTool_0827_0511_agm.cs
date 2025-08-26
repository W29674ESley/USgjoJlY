// 代码生成时间: 2025-08-27 05:11:36
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

// DatabaseMigrationTool.cs
// This class provides functionality for database migration using Entity Framework Core.

public class DatabaseMigrationTool
{
    private readonly string _connectionString;
    private readonly DbContext _dbContext;

    // Constructor that initializes the tool with a connection string and a context.
    public DatabaseMigrationTool(string connectionString, DbContext dbContext)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    // Method to apply pending migrations to the database.
    public void ApplyMigrations()
    {
        try
        {
            // Ensure the database exists before applying migrations.
            _dbContext.Database.EnsureCreated();

            // Apply any pending migrations.
            _dbContext.Database.Migrate();

            Console.WriteLine("Migrations applied successfully.");
        }
        catch (Exception ex)
        {
            // Log or handle migration errors appropriately.
            Console.WriteLine($"An error occurred during migration: {ex.Message}");
            throw;
        }
    }

    // Method to generate a new migration based on the current model changes.
    public void GenerateMigration(string migrationName)
    {
        try
        {
            // Generate the migration file.
            var migrationBuilder = _dbContext.Database.GetDbConnection().GetMigrationCommandExecutor();
            migrationBuilder.ExecuteNonQuery($"migrations add {migrationName} -o Data/Migrations");

            Console.WriteLine($"Migration {migrationName} generated successfully.");
        }
        catch (Exception ex)
        {
            // Log or handle errors that occur during migration generation.
            Console.WriteLine($"An error occurred while generating migration {migrationName}: {ex.Message}");
            throw;
        }
    }
}
