using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkArticles.Queries.GetWorkArticles;

public class GetWorkArticlesQueryHandler(IUnitOfWork ofWork)
    : IRequestHandler<GetWorkArticlesQuery, List<WorkArticle>>
{
    public async Task<List<WorkArticle>> Handle(GetWorkArticlesQuery request,
        CancellationToken cancellationToken)
    {
        var query = ofWork.GenericRepository<WorkArticle>().TableNoTracking
            .AsNoTracking();

        if (request.WorkId != 0) query = query.Where(p => p.WorkId == request.WorkId);

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}