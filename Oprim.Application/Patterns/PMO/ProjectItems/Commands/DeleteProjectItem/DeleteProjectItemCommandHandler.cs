using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Commands.DeleteProjectItem;

public class DeleteProjectItemCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProjectItemCommand>
{
    public async Task Handle(DeleteProjectItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenericRepository<ProjectItem>().GetByIdAsync(cancellationToken, request.Id);
        await unitOfWork.GenericRepository<ProjectItem>().DeleteAsync(entity, cancellationToken);
    }
}