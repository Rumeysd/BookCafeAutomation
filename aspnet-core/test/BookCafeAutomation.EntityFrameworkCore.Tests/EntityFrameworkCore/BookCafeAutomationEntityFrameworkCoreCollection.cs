using Xunit;

namespace BookCafeAutomation.EntityFrameworkCore;

[CollectionDefinition(BookCafeAutomationTestConsts.CollectionDefinitionName)]
public class BookCafeAutomationEntityFrameworkCoreCollection : ICollectionFixture<BookCafeAutomationEntityFrameworkCoreFixture>
{

}
