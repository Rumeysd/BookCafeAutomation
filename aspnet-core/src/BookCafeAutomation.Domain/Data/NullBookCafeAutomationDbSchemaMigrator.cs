using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BookCafeAutomation.Data;

/* This is used if database provider does't define
 * IBookCafeAutomationDbSchemaMigrator implementation.
 */
public class NullBookCafeAutomationDbSchemaMigrator : IBookCafeAutomationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
