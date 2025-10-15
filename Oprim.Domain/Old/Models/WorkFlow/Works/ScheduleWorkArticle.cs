using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.WorkFlow.Works
{
    public class ScheduleWorkArticle : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ScheduleWorkId")] public ScheduleWork? ScheduleWork { get; set; }
        public int ScheduleWorkId { get; set; }

        [MaxLength(20)]
        public string? CreateTime { get; set; }

        [MaxLength(20)]
        public string? ScheduleTime { get; set; }

        [MaxLength(10)]
        public string? DocumentDate { get; set; }

        public long WorkId { get; set; }

        public long DocumentId { get; set; }

        public string[] DefaultCacheNames() => new[]
        {
            ICacheModel.CreateCacheName(nameof(ScheduleWorkArticle),ScheduleWorkId)
        };
    }
}
