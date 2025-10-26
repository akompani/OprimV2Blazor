using MediatR;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplates.Queries.GetWorkTemplates;

public class GetWorkTemplatesQuery:IRequest<List<WorkTemplate>>
{
    public long ProjectId { get; set; }
}