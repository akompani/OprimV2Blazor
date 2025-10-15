using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Oprim.Domain.Common;

public class BaseEntity
{
    //
    // [Key] public int Id { get; set; }
    // [JsonIgnore] 
    // public bool IsDelete { get; set; }= false;
}
