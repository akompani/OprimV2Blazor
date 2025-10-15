using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Communications.DecisionMinutes
{
    [Index(nameof(Code),IsUnique = true)]
    public class DecisionMinute : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [MaxLength(30)]
        public string Code { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [MaxLength(5)]
        public string? StartTime { get; set; }

        [MaxLength(5)]
        public string? FinishTime { get; set; }

        public string? Location { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(DecisionMinute), ProjectId) };
        }

        public string FullName
        {
            get
            {
                return $"{Code} - {Name}";
            }
        }
    }
}
