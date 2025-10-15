using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Communications
{
    public class ProjectVisit
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [ForeignKey("VisitorId")] public Stakeholder Visitor { get; set; }
        public int VisitorId { get; set; }

        [Required]
        [MaxLength(25)] public string EntranceTime { get; set; }

        [Required]
        [MaxLength(25)] public string ExitTime { get; set; }

        public int HoursDuration { get; set; }
    }
}
