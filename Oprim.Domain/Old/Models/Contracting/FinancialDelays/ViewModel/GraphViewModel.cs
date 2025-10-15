namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays.ViewModel
{
    public class GraphViewModel
    {
        public List<int> Annotations { get; set; } = new List<int>();

        public List<GraphViewModelArticle> Articles { get; set; } = new List<GraphViewModelArticle>();
    }
}
