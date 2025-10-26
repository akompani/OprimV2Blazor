using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplateArticles.Queries.GetWorkTemplates;

public class GetWorkTemplateArticlesQueryHandler(IUnitOfWork ofWork)
    : IRequestHandler<GetWorkTemplateArticlesQuery, List<WorkTemplateArticle>>
{
    public async Task<List<WorkTemplateArticle>> Handle(GetWorkTemplateArticlesQuery request,
        CancellationToken cancellationToken)
    {
        var query = ofWork.GenericRepository<WorkTemplateArticle>().TableNoTracking
            .Where(p => p.WorkTemplateId == request.WorkTemplateId)
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}