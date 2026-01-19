using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp.EntityFrameworkCore.PostgreSql;

namespace BookCafeAutomation.EntityFrameworkCore;

public class BookCafeAutomationDbContextFactory : IDesignTimeDbContextFactory<BookCafeAutomationDbContext>
{
    public BookCafeAutomationDbContext CreateDbContext(string[] args)
    {
        BookCafeAutomationEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookCafeAutomationDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default")); 

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