using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Payroll
{


    public class PayrollBase : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public PayrollCalculationMode BaseCalculationMode { get; set; }

        public double DeductionFactor { get; set; }

        public double ExtraFactor { get; set; }

        public int TotalWorkHours { get; set; }

        public PayrollCloseCalculationMode PayrollCloseCalculationPeriod { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(PayrollBase), ProjectId) };
        }
    }
}
