using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.PMO.Scope;
using Oprim.Domain.Old.Models.Resources;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Daily
{
    public class ReportOverheadResource: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ReportId")] public Report? Report { get; set; }
        public long ReportId { get; set; }

        [ForeignKey("ArticleId")] public WorkArticle Article { get; set; }
        public long ArticleId { get; set; }

        [ForeignKey("ResourceId")] public Resource? Resource { get; set; }
        public int ResourceId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        [ForeignKey("DepartmentId")] public ProjectDepartment? Department { get; set; }
        public int DepartmentId { get; set; }

        public int Count { get; set; }
        public double Quantity { get; set; }

        [MaxLength(50)]
        public string? Notes { get; set; }

        public string FullName
        {
            get
            {
                return Resource?.FullName ?? "";
            }
        }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(ReportOverheadResource), ArticleId)
            };
        }

        public ReportOverheadResource Clone(long reportId, long newArticleId)
        {
            return new ReportOverheadResource()
            {
                ReportId = reportId,
                ArticleId = newArticleId,
                ResourceId = this.ResourceId,
                StakeholderId = this.StakeholderId,
                DepartmentId = this.DepartmentId,
                Count = this.Count,
                Quantity = this.Quantity,
                Notes = this.Notes
            };
        }

    }
}
