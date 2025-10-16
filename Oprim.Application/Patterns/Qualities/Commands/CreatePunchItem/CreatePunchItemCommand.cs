using MediatR;

namespace Oprim.Application.Patterns.Qualities.Commands.CreatePunchItem;

public class CreatePunchItemCommand:IRequest
{

    public int ProjectId { get; set; }

    public long WbsId { get; set; }

    public int DepartmentItemId { get; set; }

    public int ProjectItemId { get; set; }

    public string Notes { get; set; }

    public string CreateTime { get; set; }

    public int CreatorId { get; set; }

    public string OpponentLinks { get; set; }
}