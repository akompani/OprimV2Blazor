using MediatR;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplateArticles.Commands.DeleteWorkTemplateArticle;

public class DeleteWorkTemplateArticleCommand:IRequest
{
    public int Id { get; set; }
}