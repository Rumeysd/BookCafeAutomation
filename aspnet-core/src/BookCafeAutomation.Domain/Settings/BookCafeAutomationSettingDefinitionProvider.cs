using Volo.Abp.Settings;

namespace BookCafeAutomation.Settings;

public class BookCafeAutomationSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookCafeAutomationSettings.MySetting1));
    }
}
