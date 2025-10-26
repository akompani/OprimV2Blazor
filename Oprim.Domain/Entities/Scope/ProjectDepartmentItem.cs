using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Domain.Entities.Scope;

public class ProjectDepartmentItem : BaseEntity
{
    [ForeignKey("DepartmentId")] public ProjectDepartment Department { get; set; } = default!;
    public long ProjectId { get; set; }

    public int Row { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }
}