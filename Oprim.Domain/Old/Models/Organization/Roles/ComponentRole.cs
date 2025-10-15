using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Roles.ViewModel;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.PMO;

namespace Oprim.Domain.Old.Models.Organization.Roles
{
    public class ComponentRole: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        public int ComponentId { get; set; }

        [ForeignKey("RoleId")] public OrganizationRole? Role { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        public byte Priority { get; set; }

        public ScheduleTailoringRoles TailoringMode { get; set; }

        [Required]
        [MaxLength(10)]
        public string StartDate { get; set; }

        [MaxLength(10)]
        public string? FinishDate { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []
            {
                nameof(ComponentRole),
                nameof(ProjectRoleViewModel),
            };

        }

    }
}
