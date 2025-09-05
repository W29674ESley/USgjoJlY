// 代码生成时间: 2025-09-06 00:33:25
 * This tool is designed to handle database schema changes in a maintainable and extensible manner.
 */

using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Design;

namespace DatabaseMigrationTool
{
    // Define the database context
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }

    // Define the migration tool
    public class DatabaseMigrationTool
    {
        private readonly ILogger<DatabaseMigrationTool> logger;
        private readonly IServiceProvider serviceProvider;

        public DatabaseMigrationTool(ILogger<DatabaseMigrationTool> logger, IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        // Execute the migration
        public void MigrateDatabase()
        {
            try
            {
                // Get the database context from the service provider
                var context = serviceProvider.GetRequiredService<AppDbContext>();

                // Check if the migration services are available
                if (context.Database.GetService<IMigrationCommandExecutor>() == null)
                {
                    throw new InvalidOperationException("Migration services are not available.");
                }

                // Migrate the database to the latest version
                context.Database.Migrate();

                logger.LogInformation("Database migration completed successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during database migration.");
                throw;
            }
        }
    }

    // Program entry point
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddLogging();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            // Create and run the migration tool
            var migrationTool = new DatabaseMigrationTool(logger, serviceProvider);
            migrationTool.MigrateDatabase();

            // Run the MAUI application
            var app = builder.Build();
            app.UseRouting();
            app.MapBlazorHub();
            app.MapRazorPages();
            app.Run();
        }
    }
}
