using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Organization.Stakeholders
{
    public class StakeholderGroup: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { nameof(StakeholderGroup) };
        }
    }
}
