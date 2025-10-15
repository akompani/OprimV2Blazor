using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.WorkFlow.WorkBases;

namespace Oprim.Domain.Old.Models.WorkFlow.ViewModel
{
    public class WorkBaseStakeholderSummary
    {
        public WorkBase DocumentType { get; set; }
        public Stakeholder Stakeholder { get; set; }
        public int Count { get; set; }
        public double Percentage { get; set; }
    }
}
