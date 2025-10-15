using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Payroll
{
    public class PayrollBenefitType:ICacheModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string[] DefaultCacheNames()
        {
            return new []{nameof(PayrollBenefitType)};
        }

    }
}
