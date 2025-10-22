using MediatR;
using Oprim.Application.Dtos.Organization.Stakeholder;

namespace Oprim.Application.Patterns.Organization.Stakeholders.Commands.CreateStakeholder;

public class CreateStakeholderCommand : IRequest
{
    public CreateStakeholderDTO CreateStakeholderDto { get; set; }
}