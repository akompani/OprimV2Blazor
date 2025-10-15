using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Tailoring.Daily;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class ReportsSummaryViewModel
    {
        private PersianDateTime _startDate,_finishDate;

        private List<ReportActivityViewModel> _reportActivities;
        private List<ReportActivityResource> _reportResources;
        private List<ReportActivityThreat> _reportThreats;
        private List<ReportOverheadResource> _overheadResources;

        public Dictionary<int, Dictionary<int, double>> DirectHumanResources { get; set; }
        public Dictionary<int, Dictionary<int, double>> DirectMachineryResources { get; set; }
        public Dictionary<int, Dictionary<int, double>> OverheadHumanResources { get; set; }
        public Dictionary<int, Dictionary<int, double>> OverheadMachineryResources { get; set; }
        public Dictionary<string, double> RiskCategories { get; set; }
        public Dictionary<string, double> ProgressItemCategories { get; set; }
        public List<ReportActivityViewModel> SummaryReportActivites { get; set; }

        public int Days { get; set; }

        public ReportsSummaryViewModel(PersianDateTime start,PersianDateTime finish,int validDays)
        {
            _startDate = start;
            _finishDate = finish;
            Days = validDays;
        }

        public void Initialize(List<ReportActivityViewModel> reportActivities
            , List<ReportActivityResource> reportResources
            , List<ReportActivityThreat> reportThreats
            , List<ReportOverheadResource> overheadResources)
        {
            _reportActivities = reportActivities;
            _reportResources = reportResources;
            _reportThreats = reportThreats;
            _overheadResources = overheadResources;
            
            SetResourceSummaries();

            SetOverheadSummaries();

            SetThreatSummaries();

            SetProgressSummaries();

            SetReportActivitySummaries();
        }

        private void SetResourceSummaries()
        {
            var directHumanResources = _reportResources
                .Where(ds => ds.Resource.ResourceType == OprimResourceTypes.Human)
                .GroupBy(rr => new { rr.StakeholderId, rr.ResourceId })
                .Select(rg => new ReportActivityResource()
                {
                    StakeholderId = rg.Key.StakeholderId,
                    ResourceId = rg.Key.ResourceId,
                    Quantity = rg.Sum(r => r.Quantity)
                }).ToList();

            var directMachineryResources = _reportResources
                .Where(ds => ds.Resource.ResourceType == OprimResourceTypes.Machinery)
                .GroupBy(rr => new { rr.StakeholderId, rr.ResourceId })
                .Select(rg => new ReportActivityResource()
                {
                    StakeholderId = rg.Key.StakeholderId,
                    ResourceId = rg.Key.ResourceId,
                    Quantity = rg.Sum(r => r.Quantity)
                }).ToList();

            var rhresources = directHumanResources
                .GroupBy(r => r.ResourceId)
                .Select(rg => rg.Key)
                .ToList();

            var rmresources = directMachineryResources
                .GroupBy(r => r.ResourceId)
                .Select(rg => rg.Key)
                .ToList();

            var rstakeholders = _reportResources
                .GroupBy(r => r.StakeholderId)
                .Select(rg => rg.Key)
                .ToList();

            DirectHumanResources = new Dictionary<int, Dictionary<int, double>>();
            DirectMachineryResources = new Dictionary<int, Dictionary<int, double>>();

            foreach (var stakeholder in rstakeholders)
            {
                var resHumanDic = new Dictionary<int, double>();

                foreach (var rh in rhresources)
                {
                    resHumanDic.Add(rh, directHumanResources.SingleOrDefault(r => r.StakeholderId == stakeholder & r.ResourceId == rh)?.Quantity / 8 ?? 0);
                }

                DirectHumanResources.Add(stakeholder, resHumanDic);


                var resMachineryDic = new Dictionary<int, double>();

                foreach (var rm in rmresources)
                {
                    resMachineryDic.Add(rm, directMachineryResources.SingleOrDefault(r => r.StakeholderId == stakeholder & r.ResourceId == rm)?.Quantity / 8 ?? 0);
                }

                DirectMachineryResources.Add(stakeholder, resMachineryDic);
            }
        }

        private void SetOverheadSummaries()
        {
            var ohresources = _overheadResources
                .Where(o => o.Resource.ResourceType == OprimResourceTypes.Human)
                .GroupBy(r => r.ResourceId)
                .Select(rg => rg.Key)
                .ToList();

            var omresources = _overheadResources
                .Where(o => o.Resource.ResourceType == OprimResourceTypes.Machinery)
                .GroupBy(r => r.ResourceId)
                .Select(rg => rg.Key)
                .ToList();

            var ostakeholders = _overheadResources
                .GroupBy(r => r.StakeholderId)
                .Select(rg => rg.Key)
                .ToList();

            OverheadHumanResources = new Dictionary<int, Dictionary<int, double>>();
            OverheadMachineryResources = new Dictionary<int, Dictionary<int, double>>();

            foreach (var stakeholder in ostakeholders)
            {
                var resHumanDic = new Dictionary<int, double>();

                foreach (var oh in ohresources)
                {
                    resHumanDic.Add(oh, _overheadResources.Where(r => r.StakeholderId == stakeholder & r.ResourceId == oh).Sum(q => q.Quantity) / 8);
                }

                OverheadHumanResources.Add(stakeholder, resHumanDic);

                var resMachineryDic = new Dictionary<int, double>();

                foreach (var om in omresources)
                {
                    resMachineryDic.Add(om, _overheadResources.Where(r => r.StakeholderId == stakeholder & r.ResourceId == om).Sum(q => q.Quantity) / 8);
                }

                OverheadMachineryResources.Add(stakeholder, resMachineryDic);
            }
        }

        private void SetThreatSummaries()
        {
            RiskCategories = _reportThreats.GroupBy(r => r.ProjectThreatId)
                .ToDictionary(xg => xg.First().ProjectThreat.Name, xg => Math.Round((double)xg.Sum(r => r.ReportActivity.ScheduleActivity.DailyWeightFactor), 4));
        }

        private void SetProgressSummaries()
        {
            ProgressItemCategories = _reportActivities.GroupBy(a => a.ScheduleActivity.ProjectItemId)
                .ToDictionary(xg => xg.First().ScheduleActivity.ProjectItem.Name,
                    xg => Math.Round((double)xg.Sum(r => r.DailyProgress * r.ScheduleActivity.WeightFactor), 4));
        }

        private void SetReportActivitySummaries()
        {
            SummaryReportActivites = _reportActivities
                .Where(ra=> ra.DailyProgress > 0)
                .GroupBy(r => r.ScheduleActivityId)
                .Select(rg => new ReportActivityViewModel()
                {
                    ScheduleActivity = rg.First().ScheduleActivity,
                    PrevProgress = rg.Min(r=> r.PrevProgress),
                    CumProgress = rg.Max(r=> r.CumProgress),
                    Threates = _reportThreats
                        .Where(rt=> rg.Select(v=> v.Id).Contains(rt.ReportActivityId))
                        .GroupBy(r=> r.ProjectThreatId)
                        .Select(rt=> new ReportActivityThreat()
                        {
                            ProjectThreat = rt.First().ProjectThreat
                        })
                        .ToList(),
                    Resources = _reportResources
                        .Where(rt => rg.Select(v => v.Id).Contains(rt.ReportActivityId))
                        .GroupBy(r => r.ResourceId)
                        .Select(rt => new ReportActivityResource()
                        {
                            Resource = rt.First().Resource,
                            Count =(ushort) rt.Sum(ra=> ra.Count),
                            Quantity = rt.Sum(ra=> ra.Quantity)
                        })
                        .ToList()
                }).ToList();

            int row = 1;

            foreach (var r in SummaryReportActivites.OrderBy(s=> s.ScheduleActivity.Row))
            {
                r.DailyProgress = r.CumProgress - r.PrevProgress;
                r.Row = row++;
            }
        }

    }
}
