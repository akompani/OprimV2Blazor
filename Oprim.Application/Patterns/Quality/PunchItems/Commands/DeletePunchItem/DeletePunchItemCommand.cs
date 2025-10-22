using MediatR;

namespace Oprim.Application.Patterns.Quality.PunchItems.Commands.DeletePunchItem;

public class DeletePunchItemCommand:IRequest
{
    public int Id { get; set; }
}