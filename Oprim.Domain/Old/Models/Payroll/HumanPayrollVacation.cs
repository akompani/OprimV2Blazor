using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Payroll
{
    public class HumanPayrollVacation:ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public long ContractId { get; set; }

        [MaxLength(20)]
        public string StartDate { get; set; }        
        
        [MaxLength(20)]
        public string FinishDate { get; set; }

        public bool FullOfDay { get; set; }

        public string[] DefaultCacheNames()
        {
            return new string[] { ICacheModel.CreateCacheName(nameof(HumanPayrollVacation), ContractId) };
        }
    }
}
