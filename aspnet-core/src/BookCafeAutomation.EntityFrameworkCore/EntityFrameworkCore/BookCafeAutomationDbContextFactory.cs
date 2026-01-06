using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookCafeAutomation.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BookCafeAutomationDbContextFactory : IDesignTimeDbContextFactory<BookCafeAutomationDbContext>
{
    public BookCafeAutomationDbContext CreateDbContext(string[] args)
    {
        BookCafeAutomationEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookCafeAutomationDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new BookCafeAutomationDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BookCafeAutomation.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
