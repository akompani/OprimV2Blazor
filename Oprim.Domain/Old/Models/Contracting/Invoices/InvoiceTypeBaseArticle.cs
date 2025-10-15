using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Oprim.Domain.Old.Models.Contracting.Invoices
{
    [Index(nameof(InvoiceTypeId), nameof(Order), IsUnique = true)]
    public class InvoiceTypeBaseArticle : ICacheModel
    {
        
        [Key]
        public int Id { get; set; }

        [ForeignKey("InvoiceTypeId")] public InvoiceType InvoiceType { get; set; }
        public int InvoiceTypeId { get; set; }

        public byte Order { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int FixDays { get; set; }

        public int FitTheBaseTime { get; set; }


        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(InvoiceTypeBaseArticle), InvoiceTypeId)
            };
        }
    }
}
