using MediatR;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplates.Queries.GetWorkTemplateById;

public class GetWorkTemplateByIdQuery:IRequest<WorkTemplate>
{
    public int Id { get; set; }
}