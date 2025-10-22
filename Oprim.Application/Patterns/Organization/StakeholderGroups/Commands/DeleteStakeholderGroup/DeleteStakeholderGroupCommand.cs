using MediatR;
namespace Oprim.Application.Patterns.Organization.StakeholderGroups.Commands.DeleteStakeholderGroup;

public class DeleteStakeholderGroupCommand : IRequest
{
    public int Id { get; set; }
}