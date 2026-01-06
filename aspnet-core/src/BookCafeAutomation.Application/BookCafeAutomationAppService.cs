using System;
using System.Collections.Generic;
using System.Text;
using BookCafeAutomation.Localization;
using Volo.Abp.Application.Services;

namespace BookCafeAutomation;

/* Inherit your application services from this class.
 */
public abstract class BookCafeAutomationAppService : ApplicationService
{
    protected BookCafeAutomationAppService()
    {
        LocalizationResource = typeof(BookCafeAutomationResource);
    }
}
