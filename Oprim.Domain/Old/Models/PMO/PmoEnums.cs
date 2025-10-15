using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Schedules.ViewModels;
using Oprim.Domain.Old.Models.PMO.Tailoring;
using Oprim.Domain.Old.Models.PMO.Tailoring.Actual;
using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.PMO
{
    public enum ScheduleTailoringRoles : byte
    {
        ClientRole = 0,
        WorkshopRole = 1
    }

    public enum RiskModes : byte
    {
        Threat = 0,
        Opportunity = 1
    }

    public enum DelayCategories : byte
    {
        Unauthorized = 0,
        InternalAuthorized=1,
        ExternalAuthorized=2
    }

    public enum FinancialDelayAuthorizeMethods : byte
    {
        None=0,
        Instruction5090NoEscalation=1,
        Instruction5090WithEscalation=2,
        NewNoPublishInstruction=9
    }

    public enum RiskImpactTypes : byte
    {
        VeryLow=1,
        Low=2,
        Medium=3,
        High=4,
        VeryHigh=5
    }

    public enum RiskResponseTypes : byte
    {
        Escalate = 0,
        Avoid = 1,
        Transfer = 2,
        Mitigate = 3,
        Accept = 4
    }

    public enum TailorModes : byte
    {
        Plan = 0,
        EarlyPlan = 1,
        LatePlan = 2,
        ReSchedule = 3,
        LateReSchedule = 4,
        Actual = 5
    }

    public enum ActivityCategories : byte
    {
        Engineering = 1,
        Procurement = 2,
        Construction = 3
    }


    public enum ActivityConstraintModes : byte
    {
        AsSoonAsPossible = 0,
        AsLateAsPossible = 1,
        StartOn = 2,
        FinishOn = 3,
        StartNoEarlierThan = 4,
        StartNoLaterThan = 5,
        FinishNoEarlierThan = 6,
        FinishNoLaterThan = 7
    }

    public enum ActivityRelationModes : byte
    {
        FinishToStart = 0,
        FinishToFinish = 1,
        StartToStart = 2,
        StartToFinish = 3
    }

    public enum ResourceWorkSituations : byte
    {
        InActive = 0,
        Active = 1,
        Maintenance = 2
    }

    public enum DataEntrySituations : byte
    {
        NoData = 0,
        NotCompleted = 1,
        Completed = 2
    }

    public enum WorkshopSituations : byte
    {
        InActive = 0,
        SemiActive = 1,
        Active = 2
    }

    public enum ReportActivityTypes : byte
    {
        Manual = 0,
        ActionPlan = 1,
        PreviousProgress = 2
    }

    public enum AllowDelayTypes : byte
    {
        NotAllow = 0,
        AllowForWorkshop = 1,
        AllowForOrganization = 2
    }

    public enum InsuranceTypes : byte
    {
        CivilResponsibility = 1,
        AllRisk = 2,
        Other = 3
    }

    public enum ActionPlanTypes : byte
    {
        Range = 0,
        Weekly = 1,
        Monthly = 2
    }

    public class SchedulePath
    {
        public SchedulePath(long firstActivityId, string pathActivities = null, long lastActivityId = 0)
        {
            FirstActivityId = firstActivityId;
            PathActivities = string.IsNullOrEmpty(pathActivities) ? firstActivityId.ToString() : pathActivities;
            LastActivityId = lastActivityId == 0 ? firstActivityId : lastActivityId;
        }

        public SchedulePath(SchedulePath path)
        {
            FirstActivityId = path.FirstActivityId;
            PathActivities = path.PathActivities;
            LastActivityId = path.LastActivityId;
        }

        public long FirstActivityId { get; set; }

        public string PathActivities { get; set; }

        public long LastActivityId { get; set; }
    }

    public static class PmoGeneralFunctions
    {
        public static int OrganizationProjectId = -1;

        public static decimal SumProgress(this List<ScheduleActivityActualProgress> progresses)
        {
            return progresses.Sum(p => p.Progress * p.WeightFactor);
        }


        //public static dec Substract(this CategoryValue a, CategoryValue b)
        //{
        //    var result = new CategoryValue();

        //    result.Total = b.Total - a.Total;
        //    result.Engineering = b.Engineering - a.Engineering;
        //    result.Procurement = b.Procurement - a.Procurement;
        //    result.Construction = b.Construction - a.Construction;

        //    return result;
        //}

        //public static CategoryValue Add(this CategoryValue a, CategoryValue b)
        //{
        //    var result = new CategoryValue();

        //    result.Total = b.Total + a.Total;
        //    result.Engineering = b.Engineering + a.Engineering;
        //    result.Procurement = b.Procurement + a.Procurement;
        //    result.Construction = b.Construction + a.Construction;

        //    return result;
        //}

        public static void CopyFromNear(this ProjectDay thisDay, ProjectDay nearDay)
        {
            thisDay.AC = nearDay.AC;

            thisDay.PlanAllowDays = nearDay.PlanAllowDays;

            thisDay.PlanEarnDate = nearDay.PlanEarnDate;
        }


        public static void AddValue(this Dictionary<TailorModes, long> obj,
            Dictionary<TailorModes, long> obj2)
        {
            foreach (var objKey in obj.Keys)
            {
                obj[objKey] += obj2[objKey];
            }

            return;
        }

        public static void AddValue(this Dictionary<TailorModes, decimal> obj,
                   Dictionary<TailorModes, decimal> obj2)
        {
            foreach (var objKey in obj.Keys)
            {
                obj[objKey] += obj2[objKey];
            }

            return;
        }

        public static void AddList(this Dictionary<TailorModes, List<ProjectDayResource>> obj,
                          Dictionary<TailorModes, List<ProjectDayResource>> obj2)
        {
            foreach (var key in obj.Keys)
            {
                foreach (var resource in obj2[key])
                {
                    var item = obj[key].SingleOrDefault(r =>
                        r.ScheduleResourceId == resource.ScheduleResourceId);

                    if (item == null)
                    {
                        item = new ProjectDayResource(resource.ProjectId, resource.Day, resource.ScheduleTailoringRole, resource.ScheduleResource);
                        obj2[key].Add(item);
                    }

                    item.Quantity += resource.Quantity;
                    item.Amount += resource.Amount;

                    if (item.Quantity != 0) item.StandardPrice = item.Amount / item.Quantity;
                }
            }

            return;
        }


        //public static void AddValueInDay(this ProjectDayTailorViewModel obj, ProjectDayTailorViewModel addObj, ScheduleActivity sa)
        //{
        //    foreach (var key in obj.Progresses.Keys)
        //    {
        //        obj.Progresses[key] += addObj.Progresses[key] * sa.WeightFactor ;
        //        obj.Costs.AddValue(addObj.Costs);
        //        obj.Earns.AddValue(addObj.Earns);
        //        obj.ActivityResources.AddList(addObj.ActivityResources);
        //    }
        //}

        public static PlanCategoryValue Subtract(this PlanCategoryValue p1, PlanCategoryValue p2)
        {
            return new PlanCategoryValue(
                p1[TailorModes.Plan] - p2[TailorModes.Plan],
                p1[TailorModes.EarlyPlan] - p2[TailorModes.EarlyPlan],
                p1[TailorModes.LatePlan] - p2[TailorModes.LatePlan],
                p1[TailorModes.ReSchedule] - p2[TailorModes.ReSchedule],
                p1[TailorModes.LateReSchedule] - p2[TailorModes.LateReSchedule],
                p1[TailorModes.Actual] == 0 ? 0 : p1[TailorModes.Actual] - p2[TailorModes.Actual]
            );
        }

        public static ActivityCategories ConvertStringToActivityCategory(this string epcStr)
        {
            return epcStr.ToUpper() switch
            {
                "E" => ActivityCategories.Engineering,
                "P" => ActivityCategories.Procurement,
                "C" => ActivityCategories.Construction,
                _ => ActivityCategories.Construction
            };
        }
        public static OprimResourceTypes ConvertStringToResourceType(this string type)
        {
            return type.ToUpper() switch
            {
                "HUMAN" => OprimResourceTypes.Human,
                "MACHINERY" => OprimResourceTypes.Machinery,
                _ => OprimResourceTypes.Human
            };
        }

        public static ActivityConstraintModes ConvertStringToActivityMode(this string activityConstraintModeStr)
        {
            return activityConstraintModeStr.Replace(" ", "").ToUpper() switch
            {
                "ASLATEASPOSSIBLE" => ActivityConstraintModes.AsLateAsPossible,
                "MUSTSTARTON" => ActivityConstraintModes.StartOn,
                "MUSTFINISHON" => ActivityConstraintModes.FinishOn,
                "STARTNOEARLIERTHAN" => ActivityConstraintModes.StartNoEarlierThan,
                "STARTNOLATERTHAN" => ActivityConstraintModes.StartNoLaterThan,
                "FINISHNOEARLIERTHAN" => ActivityConstraintModes.FinishNoEarlierThan,
                "FINISHNOLATERTHAN" => ActivityConstraintModes.FinishNoLaterThan,
                "ASSOONASPOSSIBLE" => ActivityConstraintModes.AsSoonAsPossible,
                _ => ActivityConstraintModes.AsSoonAsPossible
            };
        }

        public static List<ActivityRelationViewModel> GetRelationList(this string relation, int activityId, RelationModes mode = RelationModes.Predecessor)
        {
            try
            {
                var result = new List<ActivityRelationViewModel>();

                if (string.IsNullOrEmpty(relation)) return result;

                var elements = relation.Split(",").ToList();

                foreach (var element in elements)
                {
                    result.Add(new ActivityRelationViewModel(element, activityId, mode));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        

        public static PersianDateTime StartByConstraintMode(this ScheduleActivityViewModel activity
            , Dictionary<int, ProjectCalendarCore> calendarDic
            , int dayHours
            , PersianDateTime startDate)
        {
            var constraintDate = activity.ConstraintPersianDateTime;

            var finishDate = calendarDic[activity.ProjectCalendarId].AddHours(startDate, activity.Duration * dayHours);

            var startByConstraintFinishDate = calendarDic[activity.ProjectCalendarId]
                .AddHours(constraintDate, -activity.Duration * dayHours);

            return activity.ConstraintMode switch
            {
                ActivityConstraintModes.StartOn => constraintDate,

                ActivityConstraintModes.FinishOn => startByConstraintFinishDate,

                ActivityConstraintModes.StartNoEarlierThan => constraintDate > startDate ? constraintDate : startDate,

                ActivityConstraintModes.StartNoLaterThan => constraintDate < startDate ? constraintDate : startDate,

                ActivityConstraintModes.FinishNoEarlierThan => constraintDate > finishDate
                    ? startByConstraintFinishDate
                    : startDate,

                ActivityConstraintModes.FinishNoLaterThan => constraintDate < finishDate
                    ? startByConstraintFinishDate
                    : startDate,

                _ => startDate
            };
        }

        public static PersianDateTime FinishByConstraintMode(this ScheduleActivityViewModel activity
                   , Dictionary<int, ProjectCalendarCore> calendarDic
                   , int dayHours
                   , PersianDateTime finishDate)
        {
            var constraintDate = activity.ConstraintPersianDateTime;

            var startDate = calendarDic[activity.ProjectCalendarId].AddHours(finishDate, -activity.Duration * dayHours);

            var finishByConstraintStartDate = calendarDic[activity.ProjectCalendarId]
                .AddHours(constraintDate, activity.Duration * dayHours);

            return activity.ConstraintMode switch
            {
                ActivityConstraintModes.StartOn => finishByConstraintStartDate,

                ActivityConstraintModes.FinishOn => finishDate,

                ActivityConstraintModes.StartNoEarlierThan => constraintDate < startDate
                    ? finishByConstraintStartDate
                    : finishDate,

                ActivityConstraintModes.StartNoLaterThan => constraintDate > finishDate
                    ? finishByConstraintStartDate
                    : startDate,

                ActivityConstraintModes.FinishNoEarlierThan => constraintDate > finishDate
                    ? constraintDate
                    : startDate,

                ActivityConstraintModes.FinishNoLaterThan => constraintDate < finishDate
                    ? constraintDate
                    : startDate,

                _ => finishDate
            };
        }

        public static PersianDateTime StartFromFinish(this ScheduleActivityViewModel scheduleActivity,
            Dictionary<int, ProjectCalendarCore> calendarCors, int workHoursInDay, PersianDateTime finishDate)
        {
            return calendarCors[scheduleActivity.ProjectCalendarId]
                .AddHours(finishDate, -(int)((1 - scheduleActivity.ActualProgress) * scheduleActivity.Duration * workHoursInDay));
        }

        public static PersianDateTime PossibleStartTime(this ScheduleActivityViewModel scheduleActivity, Dictionary<int, ProjectCalendarCore> calendarCors, int workHoursInDay, PersianDateTime thisDate)
        {
            var prevTimeBeforeConstraint = calendarCors[scheduleActivity.ProjectCalendarId]
                                    .AddHours(scheduleActivity.ConstraintPersianDateTime, -1 * (scheduleActivity.Duration * workHoursInDay));

            var forecastFinish =
                scheduleActivity.ForecastFinishDate(calendarCors, workHoursInDay, thisDate);

            if (scheduleActivity.Id == 976)
            {
                var a = 0;
            }

            if (thisDate < scheduleActivity.Starts[TailorModes.Plan])
                thisDate = scheduleActivity.Starts[TailorModes.Plan];

            return scheduleActivity.ConstraintMode switch
            {
                ActivityConstraintModes.AsSoonAsPossible => thisDate,
                ActivityConstraintModes.StartOn => scheduleActivity.ConstraintPersianDateTime,
                ActivityConstraintModes.StartNoEarlierThan => scheduleActivity.ConstraintPersianDateTime <
                    thisDate
                        ? thisDate
                        : scheduleActivity.ConstraintPersianDateTime,
                ActivityConstraintModes.StartNoLaterThan => scheduleActivity.ConstraintPersianDateTime <
                    thisDate
                        ? scheduleActivity.ConstraintPersianDateTime
                        : thisDate,
                ActivityConstraintModes.FinishOn => prevTimeBeforeConstraint,
                ActivityConstraintModes.FinishNoEarlierThan => prevTimeBeforeConstraint <
                    forecastFinish
                        ? prevTimeBeforeConstraint
                        : forecastFinish,
                ActivityConstraintModes.FinishNoLaterThan => prevTimeBeforeConstraint <
                    forecastFinish
                        ? forecastFinish
                        : prevTimeBeforeConstraint,
                ActivityConstraintModes.AsLateAsPossible => forecastFinish < scheduleActivity.Finishes[TailorModes.LatePlan] ? scheduleActivity.Starts[TailorModes.LatePlan] : prevTimeBeforeConstraint
            };
        }



        public static List<ScheduleActivityViewModel> FilterActivities(this List<ScheduleActivityViewModel> activities, string wbsList = null
            , int departmentId = 0, string departmentList = null, string itemList = null)
        {
            if (!string.IsNullOrEmpty(wbsList))
            {
                var wbs = wbsList.Split(",").ToList();

                activities = activities
                    .Where(a => wbs.Contains(a.WbsId.ToString()))
                    .ToList();
            }

            if (departmentId != 0)
            {
                activities = activities
                    .Where(a => a.DepartmentItem.DepartmentId == departmentId)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(departmentList))
            {
                var departments = departmentList.Split(",").ToList();

                activities = activities
                    .Where(a => departments.Contains(a.DepartmentItemId.ToString()))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(itemList))
            {
                var items = itemList.Split(",").ToList();

                activities = activities.Where(a => items.Contains(a.ProjectItemId.ToString())).ToList();
            }

            return activities;
        }

        public static List<ScheduleActivityViewModel> FilterActivitiesByStakeholders(this List<ScheduleActivityViewModel> activities, string stakeholderList = null)
        {
            if (!string.IsNullOrEmpty(stakeholderList))
            {
                var stakeholders = stakeholderList.Split(",").ToList();

                activities = activities.Where(a => a.StakeholderList.Any(sa => stakeholders.Contains(sa.id.ToString()))).ToList();
            }

            return activities;

        }

        public static List<string> GetPathsFromActivities(this List<ScheduleActivityViewModel> activities)
        {
            //forward path
            var result = new List<SchedulePath>();
            var tempPaths = new List<SchedulePath>();
            var newPaths = new List<SchedulePath>();

            //start activity and reschedule activities
            var startActivities = new List<ScheduleActivityViewModel>();

            foreach (var a in activities)
            {

                if (string.IsNullOrEmpty(a.Predecessors))
                {
                    startActivities.Add(a);
                }
                else
                {
                    bool noPredecessor = true;

                    foreach (var pred in a.PredecessorsList)
                    {
                        if (activities.Any(ac => ac.IdentityNumber == pred.PredecessorIdentityNumber))
                        {
                            noPredecessor = false;
                            break;
                        }
                    }

                    if (noPredecessor) startActivities.Add(a);
                }

            }

            foreach (var sa in startActivities)
            {
                var firstPath = new SchedulePath(sa.IdentityNumber);

                newPaths.Add(firstPath);
            }

            do
            {
                tempPaths = new List<SchedulePath>();

                foreach (var np in newPaths)
                {
                    tempPaths.Add(np);
                }

                newPaths = new List<SchedulePath>();

                //set early start
                foreach (var tPath in tempPaths)
                {

                    var actIndex = activities.FindIndex(a => a.IdentityNumber == tPath.LastActivityId);
                    var lastActivity = activities[actIndex];

                    bool haveNewActivity = false;

                    foreach (var successor in lastActivity.SuccessorsList)
                    {
                        var succesorActivity =
                            activities.SingleOrDefault(aa => aa.IdentityNumber == successor.SuccessorIdentityNumber);

                        if (succesorActivity == null) continue;

                        var nPath = new SchedulePath(tPath);

                        nPath.PathActivities += "," + successor.RelationText;

                        //$"{successor.RelationText}-{succesorActivity.GetDurationCalendarString()}";

                        nPath.LastActivityId = successor.SuccessorIdentityNumber;
                        newPaths.Add(nPath);

                        haveNewActivity = true;
                    }

                    if (!haveNewActivity) result.Add(tPath);

                };

            } while (newPaths.Count > 0);

            return result.Select(r => r.PathActivities).ToList();
        }

    }
}
