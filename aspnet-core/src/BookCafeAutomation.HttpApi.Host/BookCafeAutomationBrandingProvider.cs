using Microsoft.Extensions.Localization;
using BookCafeAutomation.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BookCafeAutomation;

[Dependency(ReplaceServices = true)]
public class BookCafeAutomationBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BookCafeAutomationResource> _localizer;

    public BookCafeAutomationBrandingProvider(IStringLocalizer<BookCafeAutomationResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
