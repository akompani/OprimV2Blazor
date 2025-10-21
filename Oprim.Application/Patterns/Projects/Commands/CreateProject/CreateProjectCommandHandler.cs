using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Projects;

namespace Oprim.Application.Patterns.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<CreateProjectCommand>
{
    public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Project>(request.CreateProjectDto);
        await unitOfWork.GenericRepository<Project>().AddAsync(entity,cancellationToken);
    }
}