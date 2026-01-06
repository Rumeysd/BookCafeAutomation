using BookCafeAutomation.Samples;
using Xunit;

namespace BookCafeAutomation.EntityFrameworkCore.Domains;

[Collection(BookCafeAutomationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BookCafeAutomationEntityFrameworkCoreTestModule>
{

}
