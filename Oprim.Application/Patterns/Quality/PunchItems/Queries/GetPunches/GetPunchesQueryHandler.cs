using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Quality.PunchItems.Queries.GetPunches;

public class GetPunchesQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetPunchesQuery, List<PunchItem>>
{
    public async Task<List<PunchItem>> Handle(GetPunchesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.GenericRepository<PunchItem>().TableNoTracking
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}