using Hvt.Demo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hvt.Demo.Permissions;

public class DemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DemoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DemoPermissions.MyPermission1, L("Permission:MyPermission1"));
        var accountablesPermission = myGroup.AddPermission(
            DemoPermissions.Accountables.Default, L("Permission:Accountables"));

        accountablesPermission.AddChild(
            DemoPermissions.Accountables.Create, L("Permission:Accountables.Create"));

        accountablesPermission.AddChild(
            DemoPermissions.Accountables.Edit, L("Permission:Accountables.Edit"));

        accountablesPermission.AddChild(
            DemoPermissions.Accountables.Delete, L("Permission:Accountables.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DemoResource>(name);
    }
}
