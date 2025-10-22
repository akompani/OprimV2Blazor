using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.StakeholderGroups.Commands.DeleteStakeholderGroup;

public class DeleteStakeholderGroupCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteStakeholderGroupCommand>
{
    public async Task Handle(DeleteStakeholderGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenericRepository<StakeholderGroup>().GetByIdAsync(cancellationToken, request.Id);
        await unitOfWork.GenericRepository<StakeholderGroup>().DeleteAsync(entity, cancellationToken);
    }
}