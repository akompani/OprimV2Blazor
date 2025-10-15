using Oprim.Domain.Old.Models.Organization.Roles.ViewModel;
using Oprim.Domain.Old.Models.Organization.Stakeholders;

namespace Oprim.Domain.Old.Models.Organization.ViewModel
{
    public class StakeholderComponentViewModel:Stakeholder
    {
        public List<ComponentRoleViewModel> ComponentRoles { get; set; }
    }
}
