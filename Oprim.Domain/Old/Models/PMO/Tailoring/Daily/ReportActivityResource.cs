using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Resources;
using Oprim.Domain.Old.Models.Subcontractors;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Daily
{
    public class ReportActivityResource: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ReportActivityId")] public ReportActivity? ReportActivity { get; set; }
        public long ReportActivityId { get; set; }

        [ForeignKey("ResourceId")] public Resource? Resource { get; set; }
        public int ResourceId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        [ForeignKey("SubcontractorItemId")] public SubcontractorContractItem? SubcontractorContractItem { get; set; }
        public long SubcontractorItemId { get; set; }

        public ushort Count { get; set; }

        public double Quantity { get; set; }

        [MaxLength(150)]
        public string? Notes { get; set; }

        public string FullName
        {
            get
            {
                if (Resource == null) return "";

                return Resource.FullName;
            }
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ReportActivityResource), ReportActivityId)};
        }

        public ReportActivityResource Clone(long newReportActivityId)
        {
            return new ReportActivityResource()
            {
                ReportActivityId = newReportActivityId,
                ResourceId = this.ResourceId,
                StakeholderId = this.StakeholderId,
                SubcontractorItemId = this.SubcontractorItemId,
                Count = this.Count,
                Quantity = this.Quantity,
                Notes = this.Notes
            };
        }
    }
}
