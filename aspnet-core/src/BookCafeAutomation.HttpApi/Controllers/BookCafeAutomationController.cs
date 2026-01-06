using BookCafeAutomation.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BookCafeAutomation.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookCafeAutomationController : AbpControllerBase
{
    protected BookCafeAutomationController()
    {
        LocalizationResource = typeof(BookCafeAutomationResource);
    }
}
