using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Dcc.Letters
{
    public class LetterViewModel:Letter
    {
        public PersianDateTime Send { get; set; }
        
        public string NextLetterFullName { get; set; }
        
        public string FollowLetterFullName { get; set; }

        public List<SummarizeTemplate> ProjectWbsList { get; set; }
        
        public List<SummarizeTemplate> Opponents { get; set; }
    }
}
