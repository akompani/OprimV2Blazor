using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Communications.DecisionMinutes
{
    [Index(nameof(ProjectId), nameof(Code), IsUnique = true)]
    public class DecisionMinuteItemGroup : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string FullName
        {
            get
            {
                return $"{Code} - {Name}";
            }
        }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(DecisionMinuteItemGroup), ProjectId) };
        }
    }
}
