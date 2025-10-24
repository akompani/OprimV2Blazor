using System.ComponentModel.DataAnnotations;
using Oprim.Domain.Common;
using Oprim.Domain.Enums.Project;

namespace Oprim.Domain.Entities.Organization;

public class OrganizationRole : BaseProjectEntity
{
    [MaxLength(50)]
    public string Name { get; set; }

    public int TopLevelRoleId { get; set; }

    public ProjectComponentTypes ComponentType { get; set; }

    public bool UniquePerson { get; set; }

    public byte OrganizationRanking { get; set; }

    public bool ExternalRole { get; set; }
}