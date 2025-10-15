using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using GeneralServices.Calendars;
using GeneralServices.Classes;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.WorkFlow.WorkBases;

namespace Oprim.Domain.Old.Models.WorkFlow.Works
{
    public class CalendarEvent
    {
        
        //title: 'رویداد یک روز کامل',
        //start: '2025-06-01',
        //end: '2025-06-01',
        //url:'',
        //backgroundColor: "#5682f3"
        public CalendarEvent()
        {

        }

        public CalendarEvent(int projectId, string title, string start, string end,string url = null, string backgroundColor = "#5682f3")
        {
            ProjectId = projectId;
            Title = title;
            Start = start;
            End = end;
            Url  = url;
            BackgroundColor = backgroundColor;
        }

        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int ProjectId { get; set; }
        public string BackgroundColor { get; set; }

        public string Url { get; set; }
    }

    public class WorkArticle : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        public long PrevArticleId { get; set; }

        public int Row { get; set; }

        [ForeignKey("WorkId")] public Work Work { get; set; }
        public long WorkId { get; set; }

        [ForeignKey("WorkBaseArticleId")] public WorkBaseArticle WorkBaseArticle { get; set; }
        public int WorkBaseArticleId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        public long Amount { get; set; }

        [MaxLength(25)]
        public string PlanStart { get; set; }

        [MaxLength(25)]
        public string PlanFinish { get; set; }

        public int PlanDuration { get; set; }

        [MaxLength(25)]
        public string? ActualFinish { get; set; }

        public double ActualDuration { get; set; }

        public int Delay { get; set; }

        public long Score { get; set; }

        public long Penalty { get; set; }

        [MaxLength(20)]
        public string? PenaltyOrScoreApplyTime { get; set; }

        public string? Notes { get; set; }

        public SevenPointLikertScale QualityValue { get; set; }

        public ArticleSituations Situation { get; set; }

        public bool FinalArticle { get; set; }

        public string? ArticleValue { get; set; }

        #region Functions
        public void Finalized(bool diverted = false)
        {
            ActualFinish = PersianDateTime.Now.FullDateTime();
            Situation = diverted ? ArticleSituations.Diverted : ArticleSituations.Completed;
        }

        public void Reset()
        {
            ActualFinish = null;
            Situation = ArticleSituations.NotCompleted;
        }

        public void Calculate(PersianCalendarCore calendarCore, WorkBase documentType, WorkBaseArticle baseArticle, int baseArticlesCount, bool diverted = false)
        {
            try
            {
                var planStartTime = PlanStart.ToPersianDateTime();
                PersianDateTime actualFinishDate;

                if (!string.IsNullOrEmpty(ActualFinish))
                {
                    Situation = diverted ? ArticleSituations.Diverted : ArticleSituations.Completed;

                    actualFinishDate = PersianDateTime.Parse(ActualFinish);
                }
                else
                {
                    Situation = ArticleSituations.NotCompleted;

                    actualFinishDate = PersianDateTime.Now.AddMinutes(-1);
                }

                var planFinishDate = PersianDateTime.Parse(PlanFinish);

                if (Situation == ArticleSituations.Completed)
                {
                    Delay = calendarCore.Duration(planFinishDate, actualFinishDate) / 60;

                    if (Delay >= 0)
                    {
                        Score = 0;
                        Penalty = documentType.GetArticlePenalty(baseArticle, baseArticlesCount, Delay);
                    }
                    else
                    {
                        Delay = 0;
                        Score = documentType.GetArticleScore(baseArticle, baseArticlesCount);
                        Penalty = 0;
                    }

                    PenaltyOrScoreApplyTime = PersianDateTime.Now.FullDateTime();
                }
                else
                {
                    Delay = 0;
                    Score = 0;
                    Penalty = 0;

                    PenaltyOrScoreApplyTime = null;
                }

                if (Situation == ArticleSituations.Completed)
                {
                    ActualDuration = Math.Max(calendarCore.DurationByHour(planStartTime, actualFinishDate), 0);
                }
                else
                {
                    ActualDuration = 0;
                    ActualFinish = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string GetSituationClass()
        {
            return Situation switch
            {
                ArticleSituations.NotCompleted => "bg-primary",
                ArticleSituations.Diverted => "bg-indigo",
                ArticleSituations.Completed => "bg-success",
                _ => ""
            };
        }


        #endregion

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(WorkArticle), WorkId),
                ICacheModel.CreateCacheName(nameof(WorkArticle),nameof(Stakeholder), StakeholderId),
                ICacheModel.CreateCacheName(nameof(Work),nameof(Stakeholder), StakeholderId)
            };
        }

        public CalendarEvent GetEvent()
        {
            return new CalendarEvent(Work.ProjectId
                ,Work.Name
                , PlanStart.GetGeorgianDateStringFromPersian()
                , PlanFinish.GetGeorgianDateStringFromPersian()
                , Work.DocumentTypeId != 0 ? $"/workflow/Works/RedirectWorkToDocument?projectId={Work.ProjectId}&documentTypeId={Work.DocumentTypeId}&documentId={Work.DocumentId}" : ""
                , Work.WorkBase.ColorCode);
        }

    }
}
