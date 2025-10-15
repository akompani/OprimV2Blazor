using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Resources;
using Oprim.Domain.Old.Models.Subcontractors;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Actual
{
    public class ProjectDayActualResource
    {
        [Key]
        public long Id { get; set; }

        public int ProjectId { get; set; }

        public int ProjectDayId { get; set; }

        [ForeignKey("ResourceId")] public Resource? Resource { get; set; }
        public int ResourceId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        [ForeignKey("SubcontractorItemId")] public SubcontractorContractItem? SubcontractorContractItem { get; set; }
        public long SubcontractorItemId { get; set; }

        public double Quantity { get; set; }
    }
}
