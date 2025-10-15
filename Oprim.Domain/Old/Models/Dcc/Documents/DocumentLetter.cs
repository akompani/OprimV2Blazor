using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Dcc.Letters;

namespace Oprim.Domain.Old.Models.Dcc.Documents
{
    public class DocumentLetter
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("DocumentId")] public Document Document { get; set; }
        public long DocumentId { get; set; }

        [ForeignKey("LetterId")] public Letter Letter { get; set; }
        public long LetterId { get; set; }
    }
}
