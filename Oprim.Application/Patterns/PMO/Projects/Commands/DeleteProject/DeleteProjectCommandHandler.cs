using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.PMO.Projects.Commands.CreateProject;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.Projects.Commands.DeleteProject;

public class DeleteProjectCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProjectCommand>
{
    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenericRepository<Project>().GetByIdAsync(cancellationToken, request.Id);
        await unitOfWork.GenericRepository<Project>().DeleteAsync(entity, cancellationToken);
    }
}