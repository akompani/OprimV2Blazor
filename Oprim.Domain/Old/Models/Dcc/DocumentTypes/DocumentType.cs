using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Dcc.DocumentTypes
{
    public class DocumentType : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string Code { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{nameof(DocumentType)};
        }
    }
}
