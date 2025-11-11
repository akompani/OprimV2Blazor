namespace Oprim.Application.Identities;

public static class Permissions
{
    public static class Users
    {
        public const string View = "Permissions.Users.View";
        public const string Create = "Permissions.Users.Create";
        public const string Edit = "Permissions.Users.Edit";
        public const string Delete = "Permissions.Users.Delete";
    }

    public static class Works
    {
        public const string View = "Permissions.Works.View";
        public const string Manage = "Permissions.Works.Manage";
        public const string Create = "Permissions.Works.Create";
        public const string Edit = "Permissions.Works.Edit";
        public const string Delete = "Permissions.Works.Delete";
    }
}