using MediatR;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Quality.PunchItems.Queries.GetPunches;

public class GetPunchesQuery:IRequest<List<PunchItem>>
{
    public int DepartmentItemId { get; set; } = 0;
    public int ProjectId { get; set; }
}