using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Payroll
{
    public class HumanPayrollLoan : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        public long ContractId { get; set; }

        [MaxLength(10)]
        public string StartRepaymentDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long MonthlyDeductionAmount { get; set; }

        
        public string[] DefaultCacheNames()
        {
            throw new NotImplementedException();
        }
    }
}
