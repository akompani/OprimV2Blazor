using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItemGroups.Commands.DeleteProjectItem;

public class DeleteProjectItemGroupCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProjectItemGroupCommand>
{
    public async Task Handle(DeleteProjectItemGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenericRepository<ProjectItemGroup>().GetByIdAsync(cancellationToken, request.Id);
        await unitOfWork.GenericRepository<ProjectItemGroup>().DeleteAsync(entity, cancellationToken);
    }
}