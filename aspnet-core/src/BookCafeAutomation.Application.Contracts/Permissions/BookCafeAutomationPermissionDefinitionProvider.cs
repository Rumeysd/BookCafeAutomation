using BookCafeAutomation.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BookCafeAutomation.Permissions;

public class BookCafeAutomationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookCafeAutomationPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookCafeAutomationPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookCafeAutomationResource>(name);
    }
}
