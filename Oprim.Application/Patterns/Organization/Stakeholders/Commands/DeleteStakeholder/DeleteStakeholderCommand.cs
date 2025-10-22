using MediatR;

namespace Oprim.Application.Patterns.Organization.Stakeholders.Commands.DeleteStakeholder;

public class DeleteStakeholderCommand : IRequest
{
    public int Id { get; set; }
}