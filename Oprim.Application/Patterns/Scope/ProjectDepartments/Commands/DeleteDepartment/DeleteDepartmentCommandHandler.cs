using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Commands.DeleteDepartment;

public class DeleteDepartmentCommandHandler(IUnitOfWork ofWork) : IRequestHandler<DeleteDepartmentCommand>
{
    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await ofWork.GenericRepository<ProjectDepartment>().Table.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            return;
        
        await ofWork.GenericRepository<ProjectDepartment>().DeleteAsync(entity, cancellationToken);
    }
}