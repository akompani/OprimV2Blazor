using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.Invoices
{
    public class InvoiceExtra : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("InvoiceId")] public Invoice Invoice { get; set; }
        public long InvoiceId { get; set; }

        [ForeignKey("InvoiceTypeExtraId")] public InvoiceTypeExtra InvoiceTypeExtra { get; set; }
        public int InvoiceTypeExtraId { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public bool UserEdit { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(InvoiceExtra), ProjectId)
            };
        }
    }
}
