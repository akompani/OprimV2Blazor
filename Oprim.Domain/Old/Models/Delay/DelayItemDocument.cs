using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Dcc.Documents;

namespace Oprim.Domain.Old.Models.Delay
{
    public class DelayItemDocument : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("DelayItemId")] public DelayItem DelayItem { get; set; }
        public long DelayItemId { get; set; }

        [ForeignKey("DocumentId")] public Document Document { get; set; }
        public long DocumentId { get; set; }


        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(DelayItemDocument), DelayItemId) };
        }
    }
}
