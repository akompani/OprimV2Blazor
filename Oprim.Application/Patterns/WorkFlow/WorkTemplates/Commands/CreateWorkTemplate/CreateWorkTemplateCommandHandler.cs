using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplates.Commands.CreateWorkTemplate;

public class CreateWorkTemplateCommandHandler(IUnitOfWork ofWork, IMapper mapper)
    : IRequestHandler<CreateWorkTemplateCommand>
{
    public async Task Handle(CreateWorkTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<WorkTemplate>(request.CreateWorkTemplateDto);
        await ofWork.GenericRepository<WorkTemplate>().AddAsync(entity, cancellationToken);
    }
}