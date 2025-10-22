using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Cost;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Commands.DeleteProjectCostBreakdown;

public class DeleteProjectCostBreakdownCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProjectCostBreakdownCommand>
{
    public async Task Handle(DeleteProjectCostBreakdownCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenericRepository<ProjectCostBreakdown>().GetByIdAsync(cancellationToken, request.Id);
        await unitOfWork.GenericRepository<ProjectCostBreakdown>().DeleteAsync(entity, cancellationToken);
    }
}