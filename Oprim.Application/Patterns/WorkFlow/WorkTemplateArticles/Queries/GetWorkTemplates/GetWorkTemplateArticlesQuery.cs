using MediatR;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplateArticles.Queries.GetWorkTemplates;

public class GetWorkTemplateArticlesQuery:IRequest<List<WorkTemplateArticle>>
{
    public long WorkTemplateId { get; set; }
}