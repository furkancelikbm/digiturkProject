// Data/ApplicationDbContextFactory.cs
using digiturkProject.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration; // IConfiguration için
using System.IO;

namespace digiturkProject.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Create DbContextOptionsBuilder
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Get connection string from configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            // Create and return DbContext
            return new ApplicationDbContext(builder.Options);
        }
    }
}
