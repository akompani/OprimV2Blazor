using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO;
using Oprim.Domain.Old.Models.PMO.Schedules.ViewModels;
using Oprim.Domain.Old.Models.Projects;
using MD.PersianDateTime;

namespace Oprim.Domain.Old.Service.PMO
{
    public class CPM
    {
        private Dictionary<int, ScheduleActivityViewModel> _activities =
            new Dictionary<int, ScheduleActivityViewModel>();

        private List<int> _sortedIds = new List<int>();
        private Dictionary<int, List<int>> _adjList = new Dictionary<int, List<int>>();
        private Dictionary<int, ProjectCalendarCore> _calendarDic;
        private readonly int _scheduleDayWorkHours = 8;
        private HashSet<int> _visited;

        public CPM(Dictionary<long, ScheduleActivityViewModel> activities
            , Dictionary<int, ProjectCalendarCore> calendarDic
            , PersianDateTime rescheduleTime
            , int scheduleDayWorkHours)
        {
            _scheduleDayWorkHours = scheduleDayWorkHours;
            _calendarDic = calendarDic;

            foreach (var sa in activities.Values)
            {
                // sa.Starts[TailorModes.ReSchedule] = calendarDic[sa.ProjectCalendarId].ExactWorkStartTime(rescheduleTime);
                sa.Finishes[TailorModes.ReSchedule] =
                    sa.ForecastFinishDate(calendarDic, scheduleDayWorkHours, rescheduleTime);

                _activities.Add(sa.IdentityNumber, sa);
            }

            BuildAdjacencyList();
            TopologicalSort();
        }

        private void BuildAdjacencyList()
        {
            foreach (var activity in _activities.Values)
            {
                if (!_adjList.ContainsKey(activity.IdentityNumber))
                {
                    _adjList[activity.IdentityNumber] = new List<int>();
                }

                foreach (var dep in activity.PredecessorsList)
                {
                    if (_activities.ContainsKey(dep.PredecessorIdentityNumber))
                    {
                        if (!_adjList.ContainsKey(dep.PredecessorIdentityNumber))
                        {
                            _adjList[dep.PredecessorIdentityNumber] = new List<int>();
                        }

                        _adjList[dep.PredecessorIdentityNumber].Add(activity.IdentityNumber);
                    }
                }
            }
        }

        public List<ScheduleActivityViewModel> GetUpdateActivities()
        {
            try
            {
                ForwardPass();

                BackwardPass();

                return _activities.Values.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void TopologicalSort()
        {
            var inDegree = new Dictionary<int, long>();
            foreach (var activity in _activities.Values)
            {
                inDegree[activity.IdentityNumber] = 0;
            }

            foreach (var deps in _adjList.Values)
            {
                foreach (var dep in deps)
                {
                    inDegree[dep]++;
                }
            }

            var queue = new Queue<int>();
            foreach (var activity in _activities.Values)
            {
                if (inDegree[activity.IdentityNumber] == 0)
                {
                    queue.Enqueue(activity.IdentityNumber);
                }
            }

            _sortedIds = new List<int>();
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                _sortedIds.Add(current);

                foreach (var neighbor in _adjList[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return;
        }


        private void ForwardPass()
        {
            try
            {
                _visited = new HashSet<int>();

                foreach (var id in _sortedIds)
                {
                    if (!_activities.ContainsKey(id)) continue;

                    var activity = _activities[id];

                    CalculateFinishTime(activity);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private PersianDateTime CalculateFinishTime(ScheduleActivityViewModel activity)
        {
            if (_visited.Contains(activity.IdentityNumber)) return activity.Finishes[TailorModes.ReSchedule];

            PersianDateTime earliestFinishTime = activity.Starts[TailorModes.ReSchedule];

            foreach (var dep in activity.PredecessorsList)
            {
                if (!_activities.ContainsKey(dep.PredecessorIdentityNumber)) continue;

                var depActivity = _activities[dep.PredecessorIdentityNumber];

                var finishTime = CalculateFinishTime(depActivity);

                PersianDateTime dependencyFinishTime = GetForwardModeStartByRelation(dep, finishTime);

                if (dependencyFinishTime > earliestFinishTime) earliestFinishTime = dependencyFinishTime;
            }

            activity.Starts[TailorModes.ReSchedule] = earliestFinishTime;
            activity.Finishes[TailorModes.ReSchedule] =
                activity.ForecastFinishDate(_calendarDic, _scheduleDayWorkHours, earliestFinishTime);

            _visited.Add(activity.IdentityNumber);
            return activity.Finishes[TailorModes.ReSchedule];
        }

        private void BackwardPass()
        {
            _visited = new HashSet<int>();
            var reversedOrder = _sortedIds.AsEnumerable().Reverse().ToList();

            PersianDateTime maxEarlyFinish = _activities.Values.Max(a => a.Finishes[TailorModes.ReSchedule]);

            foreach (var id in reversedOrder)
            {
                if (!_activities.ContainsKey(id)) continue;

                var activity = _activities[id];

                activity.Finishes[TailorModes.LateReSchedule] = maxEarlyFinish;

                CalculateStartTime(activity);
            }
        }

        private PersianDateTime CalculateStartTime(ScheduleActivityViewModel activity)
        {
            if (_visited.Contains(activity.IdentityNumber)) return activity.Starts[TailorModes.LateReSchedule];

            PersianDateTime minLateFinish = activity.Finishes[TailorModes.LateReSchedule];

            if (activity.PredecessorsList.Count > 0)
            {
                foreach (var suc in activity.SuccessorsList)
                {
                    if (!_activities.ContainsKey(suc.SuccessorIdentityNumber)) continue;

                    var sucActivity = _activities[suc.SuccessorIdentityNumber];

                    var startTime = CalculateStartTime(sucActivity);

                    var sucTime = GetBackwardModeFinishByRelation(suc, startTime);

                    if (sucTime < minLateFinish) minLateFinish = sucTime;
                }

                activity.Finishes[TailorModes.LatePlan] = minLateFinish;
            }

            activity.Starts[TailorModes.LateReSchedule] =
                activity.BackwardStartDate(_calendarDic, _scheduleDayWorkHours, minLateFinish);

            _visited.Add(activity.IdentityNumber);
            return activity.Starts[TailorModes.LateReSchedule];
        }


        private PersianDateTime GetForwardModeStartByRelation(ActivityRelationViewModel relation
            , PersianDateTime prevFinish)
        {
            if (relation == null) throw new Exception("ErrorInRelation");

            var currentActivity = _activities[relation.SuccessorIdentityNumber];
            var currentCalendarCore = _calendarDic[currentActivity.ProjectCalendarId];
            var currentActivityDuration = currentActivity?.Duration ?? 0;

            var prevActivity = _activities[relation.PredecessorIdentityNumber];
            var prevCalendarCore = _calendarDic[prevActivity.ProjectCalendarId];
            var prevActivityDuration = prevActivity?.Duration ?? 0;

            return relation.RelationMode switch
            {
                ActivityRelationModes.FinishToStart => currentCalendarCore.AddDays(prevFinish, relation.Lag,
                    _scheduleDayWorkHours),
                ActivityRelationModes.FinishToFinish => currentCalendarCore.AddDays(prevFinish,
                    relation.Lag - currentActivityDuration, _scheduleDayWorkHours),
                ActivityRelationModes.StartToStart => prevCalendarCore.AddDays(prevFinish,
                    relation.Lag - prevActivityDuration, _scheduleDayWorkHours),
                ActivityRelationModes.StartToFinish => currentCalendarCore.AddDays(
                    prevCalendarCore.AddDays(prevFinish, -prevActivityDuration + relation.Lag, _scheduleDayWorkHours),
                    -currentActivityDuration, _scheduleDayWorkHours),
            };
        }

        private PersianDateTime GetBackwardModeFinishByRelation(ActivityRelationViewModel relation,
            PersianDateTime nextStart)
        {
            if (relation == null) throw new Exception("ErrorInRelation");

            var currentActivity = _activities[relation.SuccessorIdentityNumber];
            var currentCalendarCore = _calendarDic[currentActivity.ProjectCalendarId];
            var currentActivityDuration = currentActivity.Duration;

            var prevActivity = _activities[relation.PredecessorIdentityNumber];
            var prevCalendarCore = _calendarDic[prevActivity.ProjectCalendarId];
            var prevActivityDuration = prevActivity.Duration;

            return relation.RelationMode switch
            {
                ActivityRelationModes.FinishToStart => currentCalendarCore.AddDays(nextStart, -relation.Lag,
                    _scheduleDayWorkHours),
                ActivityRelationModes.FinishToFinish => currentCalendarCore.AddDays(nextStart,
                    currentActivityDuration - relation.Lag, _scheduleDayWorkHours),
                ActivityRelationModes.StartToStart => prevCalendarCore.AddDays(nextStart,
                    prevActivityDuration - relation.Lag, _scheduleDayWorkHours),
                ActivityRelationModes.StartToFinish => prevCalendarCore.AddDays(
                    currentCalendarCore.AddDays(nextStart, currentActivityDuration - relation.Lag,
                        _scheduleDayWorkHours), prevActivityDuration, _scheduleDayWorkHours)
            };
        }
    }
}