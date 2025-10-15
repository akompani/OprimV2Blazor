using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.Invoices
{
    [Index(nameof(ProjectId), nameof(Name), IsUnique = true)]
    public class InvoiceType : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public InvoiceCategory InvoiceCategory { get; set; }

        public int BasePeriod { get; set; }

        [DefaultValue(0)]
        public OldMethodDelayTypes OldMethodDelayType { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(InvoiceType), ProjectId)
            };
        }
    }
}
