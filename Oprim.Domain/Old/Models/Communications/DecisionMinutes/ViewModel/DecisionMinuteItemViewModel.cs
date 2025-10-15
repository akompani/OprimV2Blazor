using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.Communications.DecisionMinutes.ViewModel
{
    public class DecisionMinuteItemViewModel:DecisionMinuteItem
    {
        public Work? Work { get; set; }
    }
}
