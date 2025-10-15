using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Dcc.DocumentTypes;
using Oprim.Domain.Old.Models.WorkFlow.WorkBases;

namespace Oprim.Domain.Old.Models.WorkFlow.Works
{
    public class ScheduleWork : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public WorkFlowRepeatModes RepeatMode { get; set; }

        public int RepeatFactor { get; set; }

        [MaxLength(7)]
        public string? DaySelection { get; set; }

        [MaxLength(10)]
        public string? StartDate { get; set; }

        [MaxLength(5)]
        public string? StartTime { get; set; }

        public bool NoneDocument { get; set; }

        public int LagFromDocumentDate { get; set; }

        [ForeignKey("DocumentBaseId")] public DocumentBase DocumentBase { get; set; }
        public int DocumentBaseId { get; set; }

        [ForeignKey("WorkBaseId")] public WorkBase WorkBase { get; set; }
        public int WorkBaseId { get; set; }
        
        public string[] DefaultCacheNames() => new[] { nameof(ScheduleWork) };
    }
}
