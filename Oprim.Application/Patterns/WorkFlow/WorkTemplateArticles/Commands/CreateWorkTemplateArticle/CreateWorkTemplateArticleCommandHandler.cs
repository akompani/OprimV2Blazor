using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplateArticles.Commands.CreateWorkTemplateArticle;

public class CreateWorkTemplateArticleCommandHandler(IUnitOfWork ofWork, IMapper mapper)
    : IRequestHandler<CreateWorkTemplateArticleCommand>
{
    public async Task Handle(CreateWorkTemplateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<WorkTemplateArticle>(request.CreateWorkTemplateArticleDto);
        await ofWork.GenericRepository<WorkTemplateArticle>().AddAsync(entity, cancellationToken);
    }
}