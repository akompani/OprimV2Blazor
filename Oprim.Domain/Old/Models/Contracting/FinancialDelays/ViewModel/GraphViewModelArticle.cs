using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays.ViewModel
{
    public class GraphViewModelArticle
    {
        public GraphViewModelArticle()
        {
            
        }

        public GraphViewModelArticle(PersianDateTime start, PersianDateTime today, long payment, long request)
        {
            Day = (today - start).Days + 1;
            Payment = payment;
            Request = request;
        }

        public int Day { get; set; }

        public long Payment { get; set; }

        public long Request { get; set; }
    }
}
