using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;

namespace Oprim.Domain.Old.Models.PMO.Tailoring
{
    public class PlanCategoryValue
    {
        public PlanCategoryValue()
        {

        }

        public PlanCategoryValue(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var decimalArray = input.Split(",").ToList();

                Values = new Dictionary<TailorModes, decimal>();

                int index = 0;

                foreach (var da in decimalArray)
                {
                    if (decimal.TryParse(da, out decimal val))
                    {
                        TailorModes tm = index switch
                        {
                            1 => TailorModes.Plan,
                            2 => TailorModes.EarlyPlan,
                            3 => TailorModes.LatePlan,
                            4 => TailorModes.ReSchedule,
                            5 => TailorModes.LateReSchedule,
                            6 => TailorModes.Actual,
                            _ => TailorModes.Actual
                        };

                        Values.Add(tm, val);
                    }

                    index++;

                    if (index > 6) break;
                }
            }
        }

        public PlanCategoryValue(decimal plan, decimal earlyPlan, decimal latePlan, decimal reschedule=0, decimal lateReschedule=0, decimal actual = 0)
        {
            Values = new Dictionary<TailorModes, decimal>();

            Values.Add(TailorModes.Plan, plan);
            Values.Add(TailorModes.EarlyPlan, earlyPlan);
            Values.Add(TailorModes.LatePlan, latePlan);
            Values.Add(TailorModes.ReSchedule, reschedule);
            Values.Add(TailorModes.LateReSchedule, lateReschedule);
            Values.Add(TailorModes.Actual, actual);
        }

        public PlanCategoryValue(ProjectDay projectDay)
        {
            Values = new Dictionary<TailorModes, decimal>();

            this.Values.Add(TailorModes.Plan, projectDay.PP);
            this.Values.Add(TailorModes.EarlyPlan, projectDay.PE);
            this.Values.Add(TailorModes.LatePlan, projectDay.PL);
            this.Values.Add(TailorModes.ReSchedule, projectDay.RP);
            this.Values.Add(TailorModes.LateReSchedule, projectDay.RL);
            this.Values.Add(TailorModes.Actual, projectDay.AC);
        }

        public PlanCategoryValue(Dictionary<TailorModes, decimal> dic)
        {
            Values = dic;
        }

        public string StringValue
        {
            get
            {
                var val1 = Values.ContainsKey(TailorModes.Plan) ? Values[TailorModes.Plan] : 0;
                var val2 = Values.ContainsKey(TailorModes.EarlyPlan) ? Values[TailorModes.EarlyPlan] : 0;
                var val3 = Values.ContainsKey(TailorModes.LatePlan) ? Values[TailorModes.LatePlan] : 0;
                var val4 = Values.ContainsKey(TailorModes.ReSchedule) ? Values[TailorModes.ReSchedule] : 0;
                var val5 = Values.ContainsKey(TailorModes.LateReSchedule) ? Values[TailorModes.LateReSchedule] : 0;
                var val6 = Values.ContainsKey(TailorModes.Actual) ? Values[TailorModes.Actual] : 0;

                return $"{val1},{val2},{val3},{val4},{val5},{val6}";
            }
        }

        public void Set(TailorModes tailorMode, decimal progress)
        {
            Values[tailorMode] = progress;
        }


        public decimal this[TailorModes tailorMode]
        {
            get
            {
                return Values[tailorMode];
            }
        }

        public Dictionary<TailorModes, decimal> Values { get; set; }

        public decimal Spi()
        {
            return 100 * (Values[TailorModes.Plan] > 0 ? (Values[TailorModes.Actual] / Values[TailorModes.Plan]) : 1);
        }

        public decimal PlanVariance()
        {
            return Values[TailorModes.Actual] - Values[TailorModes.Plan];
        }
    }
}
