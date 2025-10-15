using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Dcc.DocumentTypes
{
    public class DocumentBaseParameter:ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("DocumentBaseId")] public DocumentBase? DocumentBase { get; set; }
        public int DocumentBaseId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public ParameterTypes ParameterType { get; set; }

        public RangeTypes RangeType { get; set; }
        
        public string? RangeValues { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(DocumentBaseParameter), DocumentBaseId)};
        }
    }
}
