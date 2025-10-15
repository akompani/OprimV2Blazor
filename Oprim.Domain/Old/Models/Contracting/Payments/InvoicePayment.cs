using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Contracting.Invoices;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.Payments
{
    [Index(nameof(InvoiceId), nameof(PaymentId), IsUnique = true)]
    public class InvoicePayment : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("InvoiceId")] public Invoice Invoice { get; set; }
        public long InvoiceId { get; set; }

        [ForeignKey("PaymentId")] public Payment Payment { get; set; }
        public long PaymentId { get; set; }

        [MaxLength(10)]
        public string PaymentDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long NetAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long GrossAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long DelayEffectiveAmount { get; set; }

        public void Reset()
        {
            PaymentDate = null;
            NetAmount = 0;
            GrossAmount = 0;
            DelayEffectiveAmount = 0;
        }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(InvoicePayment), ProjectId)
            };
        }
    }
}
