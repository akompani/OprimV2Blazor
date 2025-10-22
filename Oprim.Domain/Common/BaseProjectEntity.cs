using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Domain.Common;

public class BaseProjectEntity : BaseEntity
{
    [ForeignKey("ProjectId")] public Project Project { get; set; }
    public int ProjectId { get; set; }
}
