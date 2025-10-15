using GeneralServices;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.WorkFlow.WorkBases;

namespace Oprim.Domain.Old.Models.WorkFlow.ViewModel
{
    //CFW = change from last week

    public class WorkDashboardViewModel
    {
        public WorkDashboardViewModel(List<WorkArticleViewModel> articles, string date = null)
        {
            var thisDate = date.ToPersianDateTime();
            var startWeekDate = thisDate.StartWeekDate();
            var finishWeekDate = thisDate.FinishWeekDate();

            Articles = articles;

            TotalTasks = articles.GroupBy(a => a.WorkId).Select(a => a.Key).Count();

            CompletedTasks = articles.Where(a => a.Situation == ArticleSituations.Completed)
                .GroupBy(a => a.WorkId).Count();

            LateTasks = articles.Where(a => a.Situation == ArticleSituations.Completed & a.Delay > 0)
                .GroupBy(a => a.WorkId).Count();

            OngoingTasks = articles.Where(a => a.Situation == ArticleSituations.NotCompleted)
                .GroupBy(a => a.WorkId).Count();

            Scores = articles.Sum(a => a.Score);

            AverageScores = TotalTasks == 0 ? 0 : Math.Round((double)Scores / TotalTasks, 2);
            AverageDelay = Math.Round(articles.Count > 0 ? articles.Average(article => article.Delay) : 0, 1);
            AverageProgress = TotalTasks > 0 ? CompletedTasks / TotalTasks : 0;


            Penalties = articles.Sum(a => a.Penalty);
            AveragePenalties = TotalTasks == 0 ? 0 : Math.Round((double)Penalties / TotalTasks, 2);

            WeeklyNewTasks =
                articles.Count(w => w.PlanStartTime >= startWeekDate & w.PlanStartTime <= finishWeekDate);

            WeeklyOngoingTasks = articles.Count(w =>
                (w.ActualFinishTime >= startWeekDate & w.ActualFinishTime <= finishWeekDate) |
                (w.PlanStartTime >= startWeekDate & w.PlanStartTime <= finishWeekDate));

            CompletedTasks = articles.Count(w => w.Situation == ArticleSituations.Completed);

            OngoingTasks = articles.Count(w => w.Situation != ArticleSituations.Completed & w.Situation != ArticleSituations.Diverted & w.PlanFinishTime >= thisDate);
            LateTasks = articles.Count(w => w.Situation != ArticleSituations.Completed & w.Situation != ArticleSituations.Diverted & w.PlanFinishTime < thisDate);

            StakeholderWorkCounts = articles
                .GroupBy(w => w.StakeholderId)
                .ToDictionary(wg => wg.First().Stakeholder,
                    wg => (wg.Count(), wg.Count(a => a.Situation == ArticleSituations.Completed)));

            WorkBasesAverageDelays = articles.GroupBy(w => w.Work.WorkBaseId)
                .ToDictionary(wg => wg.First().Work.WorkBase
                    , wg =>
                        Math.Round(
                            (decimal)wg.Sum(g => g.Delay) / (wg.Count() > 0 ? wg.Count() : 1), 2));

            WorkBasesCount = articles.GroupBy(w => w.Work.WorkBaseId)
                          .ToDictionary(wg => wg.First().Work.WorkBase
                              , wg => wg.Count());

        }

        public string Title { get; set; }

        public decimal Ranking { get; set; }
        public string RankingHistory { get; set; }
        public string RankingCFW { get; set; }

        public double AverageDelay { get; set; }
        public double AverageProgress { get; set; }

        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int OngoingTasks { get; set; }
        public int LateTasks { get; set; }
        public long Scores { get; set; }
        public double AverageScores { get; set; }

        public long Penalties { get; set; }
        public double AveragePenalties { get; set; }



        public int WeeklyNewTasks { get; set; }
        public string WeeklyNewTasksHistory { get; set; }
        public string WeeklyNewTasksCFW { get; set; }


        public int WeeklyOngoingTasks { get; set; }
        public string WeeklyOngoingTasksHistory { get; set; }
        public string WeeklyOngoingTasksCFW { get; set; }


        public int WeeklyCompletedTasks { get; set; }
        public string WeeklyCompletedTasksHistory { get; set; }
        public string WeeklyCompletedTasksCFW { get; set; }

        public List<WorkArticleViewModel> Articles { get; set; }

        public Dictionary<Stakeholder, (int, int)> StakeholderWorkCounts { get; set; }

        public Dictionary<WorkBase, decimal> WorkBasesAverageDelays { get; set; }
        public Dictionary<WorkBase, int> WorkBasesCount { get; set; }
    }
}
