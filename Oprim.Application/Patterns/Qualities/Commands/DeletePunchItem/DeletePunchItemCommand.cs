using MediatR;

namespace Oprim.Application.Patterns.Qualities.Commands.DeletePunchItem;

public class DeletePunchItemCommand:IRequest
{
    public int Id { get; set; }
}