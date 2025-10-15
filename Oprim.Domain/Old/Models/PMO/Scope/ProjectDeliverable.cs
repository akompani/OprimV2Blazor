using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Scope
{
    [Index(nameof(ProjectId), nameof(Code), IsUnique = true)]
    public class ProjectDeliverable: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectDepartmentItemId")] public ProjectDepartmentItem? ProjectDepartmentItem { get; set; }
        public long ProjectDepartmentItemId { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public decimal WeightFactor { get; set; }

        public string UnitName { get; set; }

        public double Quantity { get; set; }

        public string FullName
        {
            get
            {
                return $"{Code} - {Name}";
            }
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectDeliverable), ProjectId)};
        }
    }
}
