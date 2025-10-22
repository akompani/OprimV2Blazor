using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.PMO.Projects.Commands.CreateProject;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItemGroups.Commands.CreateProjectItemGroup;

public class CreateProjectItemGroupCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<CreateProjectCommand>
{
    public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Project>(request.CreateProjectDto);
        await unitOfWork.GenericRepository<Project>().AddAsync(entity,cancellationToken);
    }
}