using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.Quality.PunchItems.Queries.GetPunches;
using Oprim.Domain.Entities.Quality;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Queries.GetDepartments;

public class GetDepartmentsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetDepartmentsQuery, List<ProjectDepartment>>
{
    public async Task<List<ProjectDepartment>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.GenericRepository<ProjectDepartment>().TableNoTracking
            .Include(x=>x.Project)
            // .Where(p=> p.ProjectId == request.ProjectId)
            .AsNoTracking();
        
        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}