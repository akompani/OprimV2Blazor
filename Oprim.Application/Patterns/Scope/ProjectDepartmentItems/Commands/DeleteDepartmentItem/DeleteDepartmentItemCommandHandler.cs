using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.Scope.ProjectDepartments.Commands.DeleteDepartment;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Commands.DeleteDepartmentItem;

public class DeleteDepartmentItemCommandHandler(IUnitOfWork ofWork) : IRequestHandler<DeleteDepartmentItemCommand>
{
    public async Task Handle(DeleteDepartmentItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await ofWork.GenericRepository<ProjectDepartmentItem>().Table.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            return;
        
        await ofWork.GenericRepository<ProjectDepartmentItem>().DeleteAsync(entity, cancellationToken);
    }
}