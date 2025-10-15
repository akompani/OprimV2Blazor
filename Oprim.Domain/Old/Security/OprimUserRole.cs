using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models;

namespace Oprim.Domain.Old.Security
{
    public class OprimUserRole: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        public string? UserId { get; set; }

        [ForeignKey("RoleId")] public OprimRole? Role { get; set; }
        public int RoleId { get; set; }

        public string[] DefaultCacheNames() => new[] { nameof(OprimUserRole) };
    }
}
