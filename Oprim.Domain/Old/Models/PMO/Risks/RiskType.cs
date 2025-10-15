using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.PMO.Risks
{
    public class RiskType: ICacheModel
    {
        public RiskType()
        {

        }

        public RiskType(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public RiskModes RiskMode { get; set; }


        public string[] DefaultCacheNames()
        {
            return new[] { nameof(RiskType) };
        }
    }
}
