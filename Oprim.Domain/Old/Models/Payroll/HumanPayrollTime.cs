using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Payroll
{
    public class HumanPayrollTime : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public long ContractId { get; set; }

        public int MonthNo { get; set; }

        public short DayNo { get; set; }
        
        [MaxLength(10)]
        public string Date { get; set; }

        [MaxLength(11)] // 08:00-17:45
        public string Times { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public double Duration { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(HumanPayrollTime),ProjectId, MonthNo)
            };
        }
    }
}
