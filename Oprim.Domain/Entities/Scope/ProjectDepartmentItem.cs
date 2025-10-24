using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;

namespace Oprim.Domain.Entities.Scope;

public class ProjectDepartmentItem : BaseProjectEntity
{
    [ForeignKey("DepartmentId")] public ProjectDepartment Department { get; set; }
    public long DepartmentId { get; set; }

    public int Row { get; set; }
    
    public string Code { get; set; }
    
    public string Name { get; set; }
    
}