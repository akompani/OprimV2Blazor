using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Warehouses
{
    public class ProjectMaterialVendor : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("MaterialId")] public MaterialType? Material { get; set; }
        public int MaterialId { get; set; }

        [ForeignKey("SupplierId")] public Stakeholder? Supplier { get; set; }
        public int SupplierId { get; set; }


        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(ProjectMaterialVendor), nameof(Material), ProjectId),
                ICacheModel.CreateCacheName(nameof(ProjectMaterialVendor), nameof(ProjectMaterialVendor.Supplier), ProjectId),
            };
        }
    }
}
