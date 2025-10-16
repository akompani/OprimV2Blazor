using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Qualities.Queries.GetPunchById;

public class GetPunchByIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetPunchByIdQuery, PunchItem>
{
    public async Task<PunchItem> Handle(GetPunchByIdQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.GenericRepository<PunchItem>().TableNoTracking
            .Include(p => p.ProjectWbs)
            .Include(p => p.DepartmentItem)
            .Include(p => p.Creator)
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}