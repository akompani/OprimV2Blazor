using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Subcontractors
{
    public class SubcontractorStatement : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        
        [ForeignKey("SubcontractorContractId")] public SubcontractorContract? SubcontractorContract { get; set; }
        public int SubcontractorContractId { get; set; }

        [MaxLength(10)]
        public string ToDate { get; set; }

        public decimal OverheadFactor { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ApprovedAmount { get; set; }
        
        public decimal QcFactor { get; set; }

        public decimal QaFactor { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long FactoredAmount { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ApprovedPeriodAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long NetAmount { get; set; }

        public int DocumentBaseId { get; set; }

        public long WorkId { get; set; }

        public string? Notes { get; set; }

        public string FullName => $"{SubcontractorContract?.FullName + " - " ?? ""}{Name}";

        public string[] DefaultCacheNames() => new[] { ICacheModel.CreateCacheName(nameof(SubcontractorStatement)) };
    }
}
