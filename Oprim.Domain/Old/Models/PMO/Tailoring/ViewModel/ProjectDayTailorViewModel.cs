using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class ProjectDayTailorViewModel
    {
        public ProjectDayTailorViewModel()
        {
            Progresses = new Dictionary<TailorModes, decimal>();

            Progresses.Add(TailorModes.Plan, 0);
            Progresses.Add(TailorModes.EarlyPlan, 0);
            Progresses.Add(TailorModes.LatePlan, 0);
            Progresses.Add(TailorModes.ReSchedule, 0);
            Progresses.Add(TailorModes.LateReSchedule, 0);

            Costs = new Dictionary<TailorModes, long>();
            OverheadCosts = new Dictionary<TailorModes, long>();
            Earns = new Dictionary<TailorModes, long>();
            ActivityResources = new Dictionary<TailorModes, List<ProjectDayResource>>();

            foreach (var key in Progresses.Keys)
            {
                Costs.Add(key, 0);
                OverheadCosts.Add(key, 0);
                Earns.Add(key, 0);
                ActivityResources.Add(key, new List<ProjectDayResource>());
            }
        
        }

        public Dictionary<TailorModes, decimal> Progresses;
        public Dictionary<TailorModes, long> Costs;
        public Dictionary<TailorModes, long> OverheadCosts;
        public Dictionary<TailorModes, long> Earns;

        public Dictionary<TailorModes, List<ProjectDayResource>> ActivityResources =
            new Dictionary<TailorModes, List<ProjectDayResource>>();

    }
}
