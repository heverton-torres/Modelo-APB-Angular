namespace Hvt.Demo.Permissions;

public static class DemoPermissions
{
    public const string GroupName = "Demo";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Accountables
    {
        public const string Default = GroupName + ".Accountables";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
