using MediatR;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Quality.PunchItems.Queries.GetPunchById;

public class GetPunchByIdQuery:IRequest<PunchItem>
{
    public int Id { get; set; }
}