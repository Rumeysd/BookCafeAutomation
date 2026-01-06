using Volo.Abp.Modularity;

namespace BookCafeAutomation;

/* Inherit from this class for your domain layer tests. */
public abstract class BookCafeAutomationDomainTestBase<TStartupModule> : BookCafeAutomationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
