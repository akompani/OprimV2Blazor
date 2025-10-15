using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.WorkFlow.WorkBases
{
    [Index(nameof(PrefixCode),IsUnique = true)]
    public class WorkBase : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("CalendarId")] public ProjectCalendar? Calendar { get; set; }
        public int CalendarId { get; set; }

        [MaxLength(3)]
        public string PrefixCode { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public double BaseTimeDurationIndex { get; set; }

        [MaxLength(10)]
        public string ColorCode { get; set; }

        [MaxLength(10)]
        public string TextColorCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Penalty { get; set; }

        public PenaltyApplyTypes PenaltyApplyType { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int Score { get; set; }

        public ScoreApplyTypes ScoreApplyType { get; set; }

        public bool NoArticle { get; set; }

        public int GetArticleScore(WorkBaseArticle baseArticle, int baseArticlesCount)
        {
            if (baseArticlesCount == 0) return Score;

            switch (ScoreApplyType)
            {
                case ScoreApplyTypes.All:
                    return Score;

                case ScoreApplyTypes.DividedByPerson:
                    return Score / baseArticlesCount;

                case ScoreApplyTypes.DividedByWeight:
                    return (int)(baseArticle.Weight * Score / 100);
            }

            return 0;
        }

        public long GetArticlePenalty(WorkBaseArticle baseArticle, int baseArticlesCount, int delay = 0)
        {
            if (baseArticlesCount == 0) return Penalty;

            switch (PenaltyApplyType)
            {
                case PenaltyApplyTypes.All:
                    return Penalty;

                case PenaltyApplyTypes.DividedByPerson:
                    return (int)((decimal)Penalty / baseArticlesCount);

                case PenaltyApplyTypes.DividedByWeight:
                    return (int)(baseArticle.Weight * Penalty / 100);

                case PenaltyApplyTypes.AllForGuiltyPersons:
                    return delay > 0 ? Penalty : 0;
            }

            return 0;
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(WorkBase), ProjectId)};
        }
    }
}
