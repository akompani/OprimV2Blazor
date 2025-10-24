using MediatR;

namespace Oprim.Application.Patterns.WorkFlow.Works.Commands.DeleteWork;

public class DeleteWorkCommand:IRequest
{
    public long Id { get; set; }
}