using Volo.Abp.Modularity;

namespace BookCafeAutomation;

[DependsOn(
    typeof(BookCafeAutomationDomainModule),
    typeof(BookCafeAutomationTestBaseModule)
)]
public class BookCafeAutomationDomainTestModule : AbpModule
{

}
