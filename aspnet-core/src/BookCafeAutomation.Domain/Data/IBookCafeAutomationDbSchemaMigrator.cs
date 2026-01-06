using System.Threading.Tasks;

namespace BookCafeAutomation.Data;

public interface IBookCafeAutomationDbSchemaMigrator
{
    Task MigrateAsync();
}
