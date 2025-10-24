using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplateArticles.Queries.GetWorkTemplateArticleById;

public class GetWorkTemplateArticleByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetWorkTemplateArticleByIdQuery, WorkTemplateArticle>
{
    public async Task<WorkTemplateArticle> Handle(GetWorkTemplateArticleByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<WorkTemplateArticle>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}