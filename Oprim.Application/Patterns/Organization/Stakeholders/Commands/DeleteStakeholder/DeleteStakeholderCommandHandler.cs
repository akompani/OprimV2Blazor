using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.Stakeholders.Commands.DeleteStakeholder;

public class DeleteStakeholderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteStakeholderCommand>
{
    public async Task Handle(DeleteStakeholderCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenericRepository<Stakeholder>().GetByIdAsync(cancellationToken, request.Id);
        await unitOfWork.GenericRepository<Stakeholder>().DeleteAsync(entity, cancellationToken);
    }
}