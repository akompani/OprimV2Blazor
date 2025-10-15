using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Oprim.Domain.Old.Models.Resources
{
    [Index(nameof(Code),IsUnique = true)]
    public class Resource: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public OprimResourceTypes ResourceType { get; set; }

        public ResourceCategories Category { get; set; }

        public string FullName
        {
            get
            {
                return $"{Code}-{Name}";
            }
        }

        public string[] DefaultCacheNames() => new[] { nameof(Resource) };
    }
}
