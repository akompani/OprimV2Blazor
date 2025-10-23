using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Commands.CreateDepartmentItem;

public class CreateDepartmentItemCommandHandler(IUnitOfWork ofWork, IMapper mapper)
    : IRequestHandler<CreateDepartmentItemCommand>
{
    public async Task Handle(CreateDepartmentItemCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ProjectDepartmentItem>(request.CreateDepartmentItemDTO);
        await ofWork.GenericRepository<ProjectDepartmentItem>().AddAsync(entity, cancellationToken);
    }
}