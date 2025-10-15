namespace Oprim.Domain.Old.Models.PMO.Schedules.ViewModels
{
    public class ScheduleWbsViewModel : ScheduleWbs
    {
        public ScheduleWbsViewModel TopLevel { get; set; }
        
        public string FullName
        {
            get
            {
                return TopLevelFullName + (TopLevelFullName.Length > 0 ? " - " : "") + Name;
            }
        }
        
        public string TopLevelFullName
        {
            get
            {
                return TopLevel == null ? "" : (TopLevel?.FullName ?? "");
            }
        }
    }
}
