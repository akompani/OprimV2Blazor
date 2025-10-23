using Oprim.Application.Dtos.Common;

namespace Oprim.Application.Dtos.Scope;

public class CreateDepartmentItemDTO : BaseProjectDTO
{
    public int DepartmentId { get; set; }

    public int Row { get; set; }
    
    public string Code { get; set; }
    
    public string Name { get; set; }
}