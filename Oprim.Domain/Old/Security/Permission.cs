using System.ComponentModel.DataAnnotations;
using Oprim.Domain.Old.Models;

namespace Oprim.Domain.Old.Security
{
    public class Permission: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        public string? AreaName { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }

        public string Url { get; set; }

        public void GenerateUrl()
        {
            Url = string.IsNullOrEmpty(AreaName) ? "" : "/" + AreaName;
            Url += "/" + ControllerName;
            Url += "/" + ActionName;
        }

        public bool IsEqual(Permission b)
        {
            return AreaName == b.AreaName & ControllerName == b.ControllerName & ActionName == b.ActionName;
        }


        public string[] DefaultCacheNames() => new[] { nameof(Permission) };
    }
}
