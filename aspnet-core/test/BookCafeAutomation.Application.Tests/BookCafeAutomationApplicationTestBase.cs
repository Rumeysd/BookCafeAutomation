using Volo.Abp.Modularity;

namespace BookCafeAutomation;

public abstract class BookCafeAutomationApplicationTestBase<TStartupModule> : BookCafeAutomationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
