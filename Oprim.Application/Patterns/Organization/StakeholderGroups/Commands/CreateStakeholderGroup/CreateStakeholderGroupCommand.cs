using MediatR;

namespace Oprim.Application.Patterns.Organization.StakeholderGroups.Commands.CreateStakeholderGroup;

public class CreateStakeholderGroupCommand : IRequest
{
    public string Name { get; set; }
}