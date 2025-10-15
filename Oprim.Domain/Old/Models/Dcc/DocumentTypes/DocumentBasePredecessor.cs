using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Dcc.DocumentTypes
{
    public class DocumentBasePredecessor: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DocumentBaseId")] public DocumentBase? DocumentBase { get; set; }
        public int DocumentBaseId { get; set; }
        
        public bool IsRequired { get; set; }

        public bool CanSkipToComplete { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(DocumentBasePredecessor), DocumentBaseId)};
        }
    }
}
