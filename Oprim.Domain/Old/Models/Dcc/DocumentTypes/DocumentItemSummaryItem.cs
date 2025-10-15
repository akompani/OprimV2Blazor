using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting.ListPrices;

namespace Oprim.Domain.Old.Models.Dcc.DocumentTypes
{
    public class DocumentItemSummaryItem: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("SummaryId")] public DocumentItemSummary? Summary { get; set; }
        public long SummaryId { get; set; }

        [ForeignKey("ProjectItemId")] public ContractItem? ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        public double Weight { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(DocumentItemSummaryItem), SummaryId)};
        }
    }
}
