using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.StakeholderGroups.Commands.CreateStakeholderGroup;

public class CreateStakeholderGroupCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateStakeholderGroupCommand>
{
    public async Task Handle(CreateStakeholderGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = new StakeholderGroup() { Name = request.Name };
        await unitOfWork.GenericRepository<StakeholderGroup>().AddAsync(entity, cancellationToken);
    }
}