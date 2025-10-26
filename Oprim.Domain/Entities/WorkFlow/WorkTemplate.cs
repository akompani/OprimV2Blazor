using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.Schedule;
using Oprim.Domain.Enums.WorkFlow;

namespace Oprim.Domain.Entities.WorkFlow;

public class WorkTemplate : BaseProjectEntity
{
    [ForeignKey("CalendarId")] public ProjectCalendar Calendar { get; set; }
    public long CalendarId { get; set; }

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

}