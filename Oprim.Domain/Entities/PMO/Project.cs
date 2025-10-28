using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Common.Utilities;
using Oprim.Domain.Enums.Project;

namespace Oprim.Domain.Entities.PMO
{
    public class Project : BaseEntity
    {
        [MaxLength(10)] //TOS-ARG
        public string Code { get; set; }

        [MaxLength(50)] //شماره قرارداد
        public string No { get; set; }

        public string Name { get; set; }

        [MaxLength(20)] public string Location { get; set; }

        public string ClientName { get; set; }

        public string ContractorName { get; set; }

        public DateTime ContractDate { get; set; }
        [NotMapped] public string ContractPersianDate => ContractDate.ToPersianTime();

        public DateTime StartDate { get; set; }
        [NotMapped] public string StartPersianDate => StartDate.ToPersianTime();
        public DateTime FinishDate { get; set; }
        [NotMapped] public string FinishPersianDate => FinishDate.ToPersianTime();

        public bool Lock { get; set; }

        public int ContractDurationDays { get; set; }

        public int ContractContinuousDays { get; set; }

        public DateTime ContractContinuousDate { get; set; }
        [NotMapped] public string ContractContinuousDatePersianDate => ContractContinuousDate.ToPersianTime();


        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long BaseAmount { get; set; }

        public ProjectPlanTypes PlanType { get; set; }

        public string ConsultantName { get; set; }

        public bool IsFehrestic { get; set; }

        public short FehrestYear { get; set; }

        public bool Escalation { get; set; }

        public int EscalationBasePeriod { get; set; }

        [Range(3, 5)] [DefaultValue(3)] public byte EscalationDecimal { get; set; }

        public int SiteMobilizationFieldCode { get; set; }

        [DefaultValue(1.41)] public double OverheadFactor { get; set; }

        public DateTime OfferDate { get; set; }
        [NotMapped] public string OfferDateDatePersianDate => OfferDate.ToPersianTime();


        [DefaultValue(1)] public double OfferFactor { get; set; }

        public bool Apply76574 { get; set; }

        [DefaultValue(3)] public ProjectComponentTypes ComponentType { get; set; }

        public decimal LastUpdateProgress { get; set; }

        // [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        // public int CreatorId { get; set; }
    }
}