using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;

namespace Oprim.Domain.Old.Models.Payroll
{
    public class HumanPayrollContractBaseBenefit : ICacheModel,IPersianDateRange
    {
        [Key]
        public long Id { get; set; }

        public long ContractId { get; set; }

        [ForeignKey("PayrollBenefitTypeId")] public PayrollBenefitType PayrollBenefitType { get; set; }
        public int PayrollBenefitTypeId { get; set; }

        public PayrollCalculationMode CalculationMode { get; set; }

        public int RequireValue { get; set; }

        [MaxLength(10)]
        public string StartDate { get; set; }

        [MaxLength(10)]
        public string FinishDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public bool InsuranceImpact { get; set; }
        public bool TaxImpact { get; set; }

       public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(HumanPayrollContractBaseBenefit), ContractId) };
        }

        public PersianDateRangeValueObject GetPersianDateRangeValue()
        {
            return new PersianDateRangeValueObject(StartDate, FinishDate, Id);
        }
    }
}
