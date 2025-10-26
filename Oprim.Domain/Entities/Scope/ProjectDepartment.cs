using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Domain.Entities.Scope;

public class ProjectDepartment : BaseProjectEntity
{
    [ForeignKey("ProjectId")] public Project Project { get; set; }
    public long ProjectId { get; set; }
    public string Code { get; set; }
    
    public string Name { get; set; }
}