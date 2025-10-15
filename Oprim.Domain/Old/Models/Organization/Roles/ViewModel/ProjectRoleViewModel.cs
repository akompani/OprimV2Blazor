using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.PMO;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Organization.Roles.ViewModel
{
    public class ProjectRoleViewModel
    {
        public Project Project { get; set; }
        public ApplicationUser User { get; set; }
        public Stakeholder Stakeholder { get; set; }
        public OrganizationRole Role { get; set; }
        public byte Priority { get; set; }
        public ScheduleTailoringRoles TailoringMode { get; set; }

        public int ProjectId
        {
            get
            {
                return Project.Id;
            }
        }

        public string StakeholderName
        {
            get
            {
                return Stakeholder.FullName;
            }
        }

        public override string ToString()
        {
            return $"{StakeholderName} - {ProjectId}";
        }
    }
}
