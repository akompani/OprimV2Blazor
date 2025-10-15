using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Payroll.ViewModels
{
    public class HumanPayrollTimeViewModel :HumanPayrollTime
    {
        public string ContractCode { get; set; }
        public string ContractName { get; set; }
        public string StakeholderName { get; set; }

        public PersianDateTime PersianDate { get; set; }
        public TimeSpan EntranceTime { get; set; }
        public TimeSpan ExitTime { get; set; }

        public string GetDurationString
        {
            get
            {
                return $"{(int)Duration}:{(Duration - (int)Duration) * 60:00}";
            }
        }
    }
}
