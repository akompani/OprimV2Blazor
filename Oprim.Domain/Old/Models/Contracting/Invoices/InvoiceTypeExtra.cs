using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Oprim.Domain.Old.Models.Contracting.Invoices
{
    [Index(nameof(Name), nameof(InvoiceTypeId), IsUnique = true)]
    public class InvoiceTypeExtra : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("InvoiceTypeId")] public InvoiceType InvoiceType { get; set; }
        public int InvoiceTypeId { get; set; }

        public InvoiceExtraTypes ExtraType { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public bool DelayEffective { get; set; }

        public double Percentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long FixAmount { get; set; }

        public double MaxLimitPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long MaxLimitFixAmount { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(InvoiceTypeExtra), InvoiceTypeId)
            };
        }
    }
}
