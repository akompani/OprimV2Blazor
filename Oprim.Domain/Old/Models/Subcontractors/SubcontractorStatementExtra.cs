using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Subcontractors
{
    public class SubcontractorStatementExtra: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("StatementId")] public SubcontractorStatement? Statement { get; set; }
        public long StatementId { get; set; }

        [ForeignKey("BaseExtraId")] public SubcontractorContractBaseExtra? BaseExtra { get; set; }
        public int BaseExtraId { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public string[] DefaultCacheNames() => new[]
            { ICacheModel.CreateCacheName(nameof(SubcontractorStatementExtra), StatementId) };
    }
}
