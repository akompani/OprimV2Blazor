using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Activities;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class ProjectItemProgressViewModel
    {
        public ProjectItemProgressViewModel(ProjectItem projectItem, List<DepartmentItemProgressViewModel> progresses)
        {
            ProjectItem = projectItem;
            DepartmentItemProgresses = progresses;
            WeightFactor = progresses.Sum(p => p.WeightFactor);
            Actual =Math.Round(WeightFactor == 0 ? 0 : (progresses.Sum(p => p.Actual * p.WeightFactor) / WeightFactor),2);
            Plan =Math.Round(WeightFactor == 0 ? 0 : (progresses.Sum(p => p.Plan * p.WeightFactor) / WeightFactor),2);
            Var = Actual - Var;

            string start = null, finish = null;
            PersianDateTime pS = PersianDateTime.Now, pF = PersianDateTime.Now;


            foreach (var prg in progresses)
            {
                if (prg.Progresses.Count > 0)
                {
                    if (start == null)
                    {
                        pS = prg.Start;
                    }
                    else
                    {
                        pS = pS > prg.Start ? prg.Start : pS;
                    }

                    start = pS.ToShortDateString();

                    if (finish == null)
                    {
                        pF = prg.Finish;
                    }
                    else
                    {
                        pF = pF < prg.Finish ? prg.Finish : pF;
                    }

                    finish = pF.ToShortDateString();
                }
            }

            Start = start;
            Finish = finish;
        }

        public ProjectItem ProjectItem { get; set; }

        public decimal WeightFactor { get; set; }

        public decimal Actual { get; set; }
        public decimal Plan { get; set; }
        public decimal Var { get; set; }

        public string Start { get; set; }
        public string Finish { get; set; }

        public List<DepartmentItemProgressViewModel> DepartmentItemProgresses { get; set; }
    }
}
