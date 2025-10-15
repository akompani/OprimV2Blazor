using MediatR;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Qualities.Queries;

public class GetPunchesQuery:IRequest<List<PunchItem>>
{
    public int DepartmentItemId { get; set; } = 0;
}