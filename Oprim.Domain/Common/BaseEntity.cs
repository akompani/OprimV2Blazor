using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Domain.Common;

public class BaseEntity
{
    
    [Key] public long Id { get; set; }
    // [JsonIgnore] 
    // public bool IsDelete { get; set; }= false;
    
    [ForeignKey("CreatorId")] public Stakeholder? Creator { get; set; }
    public long CreatorId { get; set; }

    [MaxLength(20)] public DateTime CreateTime { get; set; }
}
