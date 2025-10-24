using MediatR;
using Oprim.Application.Dtos.WorkFlow.Works;

namespace Oprim.Application.Patterns.WorkFlow.Works.Commands.CreateWork;

public class CreateWorkCommand : IRequest
{
    public CreateWorkDTO CreateWorkDto { get; set; }
}