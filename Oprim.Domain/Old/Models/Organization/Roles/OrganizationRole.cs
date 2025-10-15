using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Organization.Roles
{
    public class OrganizationRole: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int TopLevelRoleId { get; set; }

        public ComponentTypes ComponentType { get; set; }

        public bool UniquePerson { get; set; }

        public byte OrganizationRanking { get; set; }

        public bool ExternalRole { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { nameof(OrganizationRole) };
        }
    }
}
