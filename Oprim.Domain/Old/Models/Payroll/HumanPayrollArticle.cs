using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Payroll
{
    public class HumanPayrollArticle : ICacheModel
    {
        public HumanPayrollArticle()
        {

        }

        public HumanPayrollArticle(int projectId, long contractId, int monthNo)
        {
            ProjectId = projectId;
            ContractId = contractId;
            MonthNo = monthNo;
        }


        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public long ContractId { get; set; }

        public int MonthNo { get; set; }

        public double TotalMandatoryHours { get; set; }

        public short TotalMandatoryDays { get; set; }

        public short TotalDays { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public double TotalHours { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public double TotalVacationHours { get; set; }

        public int TotalVacationDays { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public double ExtraHours { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public double DelayHours { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public double RushHours { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long BaseAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long BaseExtraHourAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ExtraAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long DeductionAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long BenefitsAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long InsuranceImpactAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long InsuranceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long EmployeeShareInsuranceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ClientShareInsuranceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long TaxImpactAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long TaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long TotalAmount
        {
            get
            {
                return BaseAmount + BenefitsAmount + ExtraAmount - DeductionAmount;
            }
        }


        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long PayableAmount
        {
            get
            {
                return TotalAmount - TaxAmount - EmployeeShareInsuranceAmount;

            }
        }


        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(HumanPayrollArticle), ProjectId, (int)(MonthNo / 100)) };
        }
    }
}
