using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;

namespace Oprim.Domain.Old.Models.Subcontractors
{
    public class Subcontractor: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        public string[] DefaultCacheNames() => new[] { nameof(Subcontractor) };
    }
}
