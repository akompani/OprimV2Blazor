using System.ComponentModel.DataAnnotations;
using Oprim.Domain.Old.Models;

namespace Oprim.Domain.Old.Security
{
    public class OprimRole: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string[] DefaultCacheNames() => new[] { nameof(OprimRole) };

    }
}
