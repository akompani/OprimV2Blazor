using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.PMO.Projects.Commands.CreateProject;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Commands.CreateProjectItem;

public class CreateProjectItemCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<CreateProjectItemCommand>
{
    public async Task Handle(CreateProjectItemCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Project>(request.CreateProjectDto);
        await unitOfWork.GenericRepository<Project>().AddAsync(entity,cancellationToken);
    }
}