using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    [Index(nameof(ScheduleId), nameof(Code), IsUnique = true)]
    public class ScheduleWbs : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ScheduleId")] public ProjectSchedule Schedule { get; set; }
        [DefaultValue(1)]
        public int ScheduleId { get; set; }

        [ForeignKey("ProjectWbsId")] public ProjectWbs ProjectWbs { get; set; }
        public long ProjectWbsId { get; set; }

        public int Row { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        public string Name { get; set; }

        public long TopLevelId { get; set; }

        public string OutlineCode { get; set; }
        public byte OutlineLevel { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []
            {
                ICacheModel.CreateCacheName(nameof(ScheduleWbs), ScheduleId) ,
                ICacheModel.CreateCacheName(nameof(ScheduleWbs), ScheduleId,"LEVELS")
            };
        }


        public void CopyFrom(ScheduleWbs source)
        {
            ProjectId = source.ProjectId;
            ScheduleId = source.ScheduleId;
            Code = source.Code;
            Name = source.Name;
            TopLevelId = source.TopLevelId;
            OutlineCode = source.OutlineCode;
            OutlineLevel = source.OutlineLevel;
        }
    }
}
