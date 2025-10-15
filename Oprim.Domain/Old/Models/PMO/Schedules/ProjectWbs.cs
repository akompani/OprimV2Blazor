using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    public class ProjectWbs : ICacheModel, ISummarize
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public long TopLevelId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        public string Name { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { $"{nameof(ProjectWbs)}-{ProjectId}" };
        }

        public SummarizeTemplate GetSummarize()
        {
            return new SummarizeTemplate(Id, Name);
        }
    }
}
