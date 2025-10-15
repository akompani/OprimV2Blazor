using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.Payroll
{
    [Index(nameof(Code), IsUnique = true)]
    public class HumanPayrollContract : ICacheModel, IPersianDateRange
    {
        [Key] public long Id { get; set; }

        [MaxLength(20)]
        public string Code { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        [ForeignKey("ResourceId")] public Resource Resource { get; set; }
        public int ResourceId { get; set; }

        [ForeignKey("PayrollBaseId")] public PayrollBase PayrollBase { get; set; }
        public int PayrollBaseId { get; set; }

        [ForeignKey("CalendarId")] public ProjectCalendar Calendar { get; set; }
        public int CalendarId { get; set; }

        [MaxLength(10)]
        public string StartDate { get; set; }

        [MaxLength(10)]
        public string FinishDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long BaseSalary { get; set; }

        public virtual List<HumanPayrollArticle> Articles { get; set; }
        public virtual List<HumanPayrollTime> Times { get; set; }
        public virtual List<HumanPayrollVacation> Vacations { get; set; }
        public virtual List<HumanPayrollLoan> Loans { get; set; }
        public virtual List<HumanPayrollContractBaseBenefit> Benefits { get; set; }
        public virtual List<HumanPayrollPayment> Payments { get; set; }

        public string Name
        {
            get
            {
                return $"{Code} [ {StartDate} - {FinishDate} ]";
            }
        }

        public string FullName
        {
            get
            {
                return $"{Stakeholder?.FullName ?? ""} - {PayrollBase?.Name ?? ""} [{StartDate}-{FinishDate}]";
            }
        }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(HumanPayrollContract), ProjectId) };
        }

        public PersianDateRangeValueObject GetPersianDateRangeValue()
        {
            return new PersianDateRangeValueObject(StartDate, FinishDate, Id);
        }
    }
}
