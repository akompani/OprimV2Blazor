using MediatR;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplateArticles.Queries.GetWorkTemplateArticleById;

public class GetWorkTemplateArticleByIdQuery:IRequest<WorkTemplateArticle>
{
    public int Id { get; set; }
}