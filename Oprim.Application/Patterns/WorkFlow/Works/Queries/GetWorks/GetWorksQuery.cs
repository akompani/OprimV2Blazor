using MediatR;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.Works.Queries.GetWorks;

public class GetWorksQuery:IRequest<List<Work>>
{
    public long ProjectId { get; set; }
}