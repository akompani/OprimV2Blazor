using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models;

namespace Oprim.Domain.Old.Security
{
    [Index(nameof(PermissionId), nameof(RoleId), IsUnique = true)]
    public class RolePermission : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PermissionId")] public Permission Permission { get; set; }
        public int PermissionId { get; set; }

        [ForeignKey("RoleId")] public OprimRole Role { get; set; }
        public int RoleId { get; set; }

        public bool Access { get; set; }

        public string[] DefaultCacheNames() => new[] { nameof(RolePermission) };
    }
}
