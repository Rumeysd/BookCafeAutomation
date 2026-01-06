using Volo.Abp.Modularity;

namespace BookCafeAutomation;

[DependsOn(
    typeof(BookCafeAutomationApplicationModule),
    typeof(BookCafeAutomationDomainTestModule)
)]
public class BookCafeAutomationApplicationTestModule : AbpModule
{

}
