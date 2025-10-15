using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting.ListPrices;

namespace Oprim.Domain.Old.Models.Dcc.Documents
{
    public class DocumentField: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("DocumentId")] public Document Document { get; set; }
        public long DocumentId { get; set; }

        public long ArticleId { get; set; }

        [ForeignKey("FieldId")] public ContractField Field { get; set; }
        public int FieldId { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long FehrestAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long StarAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long NewItemAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long FactoriAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public void Reset()
        {
            FehrestAmount = 0;
            StarAmount = 0;
            NewItemAmount = 0;
            FactoriAmount = 0;
            Amount = 0;
        }

        public string[] DefaultCacheNames() => new[] { ICacheModel.CreateCacheName(nameof(DocumentField), ArticleId) };
    }
}
