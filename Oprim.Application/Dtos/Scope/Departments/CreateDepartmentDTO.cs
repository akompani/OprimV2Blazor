using Oprim.Application.Dtos.Common;

namespace Oprim.Application.Dtos.Scope.Departments;

public class CreateDepartmentDTO : BaseProjectDTO
{
    public string Code { get; set; }
    public string Name { get; set; }
}