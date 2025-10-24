using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Queries.GetDepartmentById;

public class GetDepartmentByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetDepartmentByIdQuery, ProjectDepartment>
{
    public async Task<ProjectDepartment> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<ProjectDepartment>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}