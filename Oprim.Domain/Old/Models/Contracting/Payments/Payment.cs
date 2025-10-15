using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.Payments
{
    public class Payment: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [MaxLength(10)]
        public string ActualDate { get; set; }

        public string TarikhEslahi { get; set; }

        public PaymentTypes PaymentType { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public bool Akhza { get; set; }

        [MaxLength(50)]
        public string AkhzaNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long AkhzaAmount { get; set; }

        [MaxLength(150)]
        public string Notes { get; set; }

        public bool Allocated { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long NetAmount { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long GrossAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long DelayEffectiveAmount { get; set; }
        
        public string InvoiceLinks { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(Payment), ProjectId)
            };
        }
    }
}
