using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
namespace Oprim.Domain.Entities.PMO;

public class ProjectItemGroup : BaseEntity
{
    // [ForeignKey("ProjectId")] public Project Project { get; set; }
    public long ProjectId { get; set; }
    public string Name { get; set; }
}