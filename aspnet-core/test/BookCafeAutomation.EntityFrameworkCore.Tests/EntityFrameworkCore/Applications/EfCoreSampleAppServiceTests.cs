using BookCafeAutomation.Samples;
using Xunit;

namespace BookCafeAutomation.EntityFrameworkCore.Applications;

[Collection(BookCafeAutomationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BookCafeAutomationEntityFrameworkCoreTestModule>
{

}
