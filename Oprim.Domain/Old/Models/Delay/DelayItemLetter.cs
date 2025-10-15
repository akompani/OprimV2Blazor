using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Dcc.Letters;

namespace Oprim.Domain.Old.Models.Delay
{
    public class DelayItemLetter : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("DelayItemId")] public DelayItem DelayItem { get; set; }
        public long DelayItemId { get; set; }

        [ForeignKey("LetterId")] public Letter Letter { get; set; }
        public long LetterId { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(DelayItemLetter), DelayItemId) };
        }
    }
}
