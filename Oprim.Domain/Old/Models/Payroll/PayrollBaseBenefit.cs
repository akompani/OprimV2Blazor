using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using Microsoft.EntityFrameworkCore;

namespace Oprim.Domain.Old.Models.Payroll
{
    [Index(nameof(PayrollBaseId), nameof(PayrollBenefitTypeId), nameof(StartDate), IsUnique = true)]
    public class PayrollBaseBenefit : ICacheModel, IPersianDateRange
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PayrollBaseId")] public PayrollBase PayrollBase { get; set; }
        public int PayrollBaseId { get; set; }

        [ForeignKey("PayrollBenefitTypeId")] public PayrollBenefitType PayrollBenefitType { get; set; }
        public int PayrollBenefitTypeId { get; set; }

        public string Name { get; set; }

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
            return new[] { ICacheModel.CreateCacheName(nameof(PayrollBaseBenefit), PayrollBaseId) };
        }

        public PersianDateRangeValueObject GetPersianDateRangeValue()
        {
            return new PersianDateRangeValueObject(StartDate, FinishDate, Id);
        }
    }
}
