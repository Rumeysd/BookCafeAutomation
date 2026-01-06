using BookCafeAutomation.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BookCafeAutomation.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookCafeAutomationEntityFrameworkCoreModule),
    typeof(BookCafeAutomationApplicationContractsModule)
    )]
public class BookCafeAutomationDbMigratorModule : AbpModule
{
}
