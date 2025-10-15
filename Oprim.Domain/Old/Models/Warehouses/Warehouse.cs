using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Warehouses
{
    public class Warehouse : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string[] DefaultCacheNames() => new[] { nameof(Warehouse) };
    }
}
