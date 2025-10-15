using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.PMO;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Delay
{
    public class DelayScenario : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        public int CreatorId { get; set; }

        [MaxLength(10)]
        public string CreateDate { get; set; }

        [ForeignKey("ScheduleId")] public ProjectSchedule Schedule { get; set; }
        public int ScheduleId { get; set; }

        public bool UseActualDates { get; set; }

        [MaxLength(10)]
        public string EffectiveStartDate { get; set; }

        [MaxLength(10)]
        public string EffectiveFinishDate { get; set; }

        public FinancialDelayAuthorizeMethods FinancialDelayAuthorizeMethod { get; set; }

        [MaxLength(10)]
        public string ToDate { get; set; }

        public int FinancialAuthorizeDays { get; set; }

        public int AuthorizeDays { get; set; }

        [MaxLength(10)]
        public string AuthorizeTime { get; set; }

        public int UnAuthorizeDays { get; set; }

        [MaxLength(10)]
        public string UnAuthorizeTime { get; set; }

        public int InternalAuthorizeDays { get; set; }

        [MaxLength(10)]
        public string InternalAuthorizeTime { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(DelayScenario), ProjectId),
                ICacheModel.CreateCacheName("GanttTask", Id)

            };
        }
    }
}
