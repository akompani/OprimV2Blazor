using Oprim.Domain.Common;

namespace Oprim.Domain.Entities.Scope;

public class ProjectDepartment : BaseProjectEntity
{
    public string Code { get; set; }
    
    public string Name { get; set; }
}