using MediatR;
using Oprim.Application.Dtos.WorkFlow.WorkTemplates;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplates.Commands.CreateWorkTemplate;

public class CreateWorkTemplateCommand : IRequest
{
    public CreateWorkTemplateDTO CreateWorkTemplateDto { get; set; }
}