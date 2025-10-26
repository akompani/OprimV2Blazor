using MediatR;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplates.Commands.DeleteWorkTemplate;

public class DeleteWorkTemplateCommand:IRequest
{
    public int Id { get; set; }
}