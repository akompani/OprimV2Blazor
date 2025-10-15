using Oprim.Domain.Old.Models.Organization.Roles;

namespace Oprim.Domain.Old.Models.Organization.ViewModel
{
    public class OrganizationRoleViewModel:OrganizationRole
    {
        public OrganizationRole TopLevelRole { get; set; }
    }
}
