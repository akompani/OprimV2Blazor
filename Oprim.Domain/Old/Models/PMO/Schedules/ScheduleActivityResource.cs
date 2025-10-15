using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    public class ScheduleActivityResource : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity? ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        [ForeignKey("ProjectResourceId")] public ProjectResource? ProjectResource { get; set; }
        public long ProjectResourceId { get; set; }

        [Column(TypeName = "decimal(13,2)")]
        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public double Quantity { get; set; }

        public AllocationModes AllocationMode { get; set; }

        [ForeignKey("CustomAllocationModeId")] public CustomAllocationMode? CustomAllocationMode { get; set; }
        public int? CustomAllocationModeId { get; set; }

        public string FullName
        {
            get
            {
                return ProjectResource?.FullName ?? "";
            }
        }

        public ProjectDayResource? Allocate(decimal prevProgress, decimal thisDayProgress, PersianDateTime date, Dictionary<int, ProjectCalendarCore> projectCalendarDictionary)
        {
            if (Quantity > 0)
            {
                var result = new ProjectDayResource(ProjectResource);

                //if (ProjectResource.Resource.ResourceType == ResourceTypes.Material)
                //{

                //    decimal cumProgress = prevProgress + thisDayProgress;

                //    if (CustomAllocationModeId == 0)
                //    {
                //        switch (AllocationMode)
                //        {
                //            case AllocationModes.OnStart:
                //                if (prevProgress == 0 & cumProgress > 0) result.Quantity = Quantity;
                //                break;

                //            case AllocationModes.OnFinish:
                //                if (prevProgress < 100 & cumProgress == 100) result.Quantity = Quantity;
                //                break;

                //            default:
                //                result.Quantity = (double)(cumProgress - prevProgress) * Quantity / 100;
                //                break;
                //        }
                //    }
                //    else
                //    {
                //        var cumQuantity = CustomAllocationMode.CalculateProgressValue(cumProgress);
                //        var prevQuantity = CustomAllocationMode.CalculateProgressValue(prevProgress);

                //        result.Quantity = (cumQuantity - prevQuantity) * Quantity / 100;
                //    }
                //}
                //else
                //{
                var dayHours = projectCalendarDictionary[ProjectResource.ProjectCalendarId].DayDurationByHour(date);

                if (dayHours == 0) return null;

                result.Quantity = dayHours * (double)Quantity;
                //}

                result.Calculate();

                return result;
            }

            return null;
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ScheduleActivityResource), ScheduleActivityId)};
        }
    }
}
