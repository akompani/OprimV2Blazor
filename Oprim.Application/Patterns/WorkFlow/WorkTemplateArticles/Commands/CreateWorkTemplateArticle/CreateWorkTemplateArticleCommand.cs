using MediatR;
using Oprim.Application.Dtos.WorkFlow.WorkTemplateArticles;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplateArticles.Commands.CreateWorkTemplateArticle;

public class CreateWorkTemplateArticleCommand : IRequest
{
    public CreateWorkTemplateArticleDTO CreateWorkTemplateArticleDto { get; set; }
}