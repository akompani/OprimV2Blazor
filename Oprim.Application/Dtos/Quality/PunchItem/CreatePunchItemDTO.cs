using Oprim.Application.Dtos.Common;

namespace Oprim.Application.Dtos.Quality.PunchItem;

public class CreatePunchItemDTO : BaseProjectDTO
{
    public string Name { get; set; }
    
    public long WbsId { get; set; }

    public int DepartmentItemId { get; set; }

    public int ProjectItemId { get; set; }
}