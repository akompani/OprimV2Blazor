using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.Quality.PunchItems.Commands.CreatePunchItem;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Commands.CreateDepartment;

public class CreateDepartmentCommandHandler(IUnitOfWork ofWork, IMapper mapper)
    : IRequestHandler<CreateDepartmentCommand>
{
    public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ProjectDepartment>(request.CreateDepartmentDTO);
        await ofWork.GenericRepository<ProjectDepartment>().AddAsync(entity, cancellationToken);
    }
}