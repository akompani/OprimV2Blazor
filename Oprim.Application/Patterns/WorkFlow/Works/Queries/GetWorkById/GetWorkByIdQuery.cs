using MediatR;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.Works.Queries.GetWorkById;

public class GetWorkByIdQuery:IRequest<Work>
{
    public long Id { get; set; }
}