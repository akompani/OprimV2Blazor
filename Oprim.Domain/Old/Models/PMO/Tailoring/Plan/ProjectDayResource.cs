using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Plan
{
    public class ProjectDayResource
    {
        public ProjectDayResource()
        {

        }

        public ProjectDayResource(ProjectResource scheduleResource)
        {
            ScheduleResource = scheduleResource;
        }

        public ProjectDayResource(int projectId, ScheduleTailoringRoles tailoringRole,long scheduleResourceId)
        {
            ProjectId = projectId;
            ScheduleTailoringRole = tailoringRole;
            ScheduleResourceId = scheduleResourceId;
        }

       public ProjectDayResource(int projectId, int day, ScheduleTailoringRoles tailoringRole, ProjectResource scheduleResource, double quantity =0 )
        {
            ProjectId = projectId;
            Day= day;
            ScheduleTailoringRole = tailoringRole;
            Quantity = quantity;

            ScheduleResourceId = scheduleResource.Id;
            StandardPrice = scheduleResource.StandardPrice;
            OvertimePrice = scheduleResource.OvertimePrice;

            this.Calculate();
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public int Day { get; set; }

        public ScheduleTailoringRoles ScheduleTailoringRole { get; set; }


        [ForeignKey("ScheduleResourceId")] public ProjectResource ScheduleResource { get; set; }
        public long ScheduleResourceId { get; set; }

        public double Quantity { get; set; }

        public double StandardPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long StandardAmount { get; set; }

        public double OvertimePrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long OvertimeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }


        public void Calculate()
        {
            if (ScheduleResource.Maximum > 0 & OvertimePrice > 0)
            {
                StandardAmount =(long)( ScheduleResource.Maximum * StandardPrice);
                OvertimeAmount = (long)((Quantity - ScheduleResource.Maximum) * OvertimePrice);
            }
            else
            {
                StandardAmount =(long)( Quantity * StandardPrice);
                OvertimeAmount = 0;
            }

            Amount = StandardAmount + OvertimeAmount;
        }
    }
}
