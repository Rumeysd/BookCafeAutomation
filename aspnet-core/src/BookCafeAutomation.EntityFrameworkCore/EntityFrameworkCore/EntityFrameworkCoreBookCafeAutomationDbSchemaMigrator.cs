using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookCafeAutomation.Data;
using Volo.Abp.DependencyInjection;

namespace BookCafeAutomation.EntityFrameworkCore;

public class EntityFrameworkCoreBookCafeAutomationDbSchemaMigrator
    : IBookCafeAutomationDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBookCafeAutomationDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the BookCafeAutomationDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BookCafeAutomationDbContext>()
            .Database
            .MigrateAsync();
    }
}
