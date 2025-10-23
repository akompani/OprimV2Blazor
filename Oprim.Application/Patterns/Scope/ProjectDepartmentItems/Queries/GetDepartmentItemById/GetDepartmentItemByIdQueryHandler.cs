using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Queries.GetDepartmentItemById;

public class GetDepartmentItemByIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetDepartmentItemByIdQuery, ProjectDepartmentItem>
{
    public async Task<ProjectDepartmentItem> Handle(GetDepartmentItemByIdQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.GenericRepository<ProjectDepartmentItem>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}