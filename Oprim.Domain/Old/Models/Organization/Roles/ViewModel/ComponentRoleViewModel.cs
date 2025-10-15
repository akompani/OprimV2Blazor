namespace Oprim.Domain.Old.Models.Organization.Roles.ViewModel
{
    public class ComponentRoleViewModel : ComponentRole
    {
        public string ComponentName { get; set; }

        public string FullName
        {
            get
            {
                return $"Access by {Role.Name} for {ComponentName}";
            }
        }
    }
}
