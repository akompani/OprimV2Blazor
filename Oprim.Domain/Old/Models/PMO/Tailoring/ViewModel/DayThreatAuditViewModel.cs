using Oprim.Domain.Old.Models.PMO.Tailoring.Daily;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class DayThreatAuditViewModel : DayThreatAudit
    {
        public string ScheduleActivityName { get; set; }

        public string OwnerThreatName { get; set; }
        public string OwnerStakeholderName { get; set; }

        public string AuditThreatName { get; set; }
        public string AuditStakeholderName { get; set; }

        public string RefereeThreatName { get; set; }
        public string RefereeStakeholderName { get; set; }
    }
}
