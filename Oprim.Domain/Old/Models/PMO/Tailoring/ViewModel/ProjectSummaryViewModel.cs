using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class ProjectSummaryViewModel
    {
        public int Id { get; set; }

        public Project Project { get; set; }

        public ProjectDayViewModel ProjectDay { get; set; }

    }
}
