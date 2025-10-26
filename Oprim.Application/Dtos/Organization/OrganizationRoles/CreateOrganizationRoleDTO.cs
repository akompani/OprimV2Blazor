using System.ComponentModel.DataAnnotations;
using Oprim.Application.Dtos.Common;
using Oprim.Domain.Enums.Project;

namespace Oprim.Application.Dtos.Organization.OrganizationRoles;

public class CreateOrganizationRoleDTO : BaseProjectDTO
{
    [MaxLength(50)]
    public string Name { get; set; }
    
    public int TopLevelRoleId { get; set; }

    public ProjectComponentTypes ComponentType { get; set; }

    public bool UniquePerson { get; set; }

    public byte OrganizationRanking { get; set; }

    public bool ExternalRole { get; set; }
}