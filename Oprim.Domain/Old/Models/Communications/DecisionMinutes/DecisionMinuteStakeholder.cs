using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;

namespace Oprim.Domain.Old.Models.Communications.DecisionMinutes
{
    public class DecisionMinuteStakeholder : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("DecisionMinuteId")] public DecisionMinute? DecisionMinute { get; set; }
        public int DecisionMinuteId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        public bool Present { get; set; }

        public CommunicationModes CommunicationMode { get; set; }

        [MaxLength(20)]
        public string? CommunicationTime { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(DecisionMinuteStakeholder), DecisionMinuteId) };
        }
    }
}
