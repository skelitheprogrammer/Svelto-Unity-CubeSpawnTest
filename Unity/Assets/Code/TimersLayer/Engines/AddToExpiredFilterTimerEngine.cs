using Code.TimersLayer.Components;
using Svelto.ECS;

namespace Code.TimersLayer.Engines
{
    public abstract class AddToExpiredFilterTimerEngine<T> : IQueryingEntitiesEngine, IStepEngine
    {
        public EntitiesDB entitiesDB { get; set; }
        private EntitiesDB.SveltoFilters _filters;
        public string name => GetType().Name;

        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
        }

        public void Step()
        {
            var groups = entitiesDB.FindGroups<Timer<T>>();
            var filter = _filters.GetTransientFilter<Timer<T>>(TimerFilters.ExpiredTimer);

            foreach ((var (timers, ids, count), ExclusiveGroupStruct group) in entitiesDB.QueryEntities<Timer<T>>(groups))
            {
                if (!GroupIncludeCondition(group))
                {
                    continue;
                }

                for (int i = 0; i < count; i++)
                {
                    if (timers[i].Value > 0)
                    {
                        continue;
                    }

                    timers[i].Value = 0;
                    filter.Add(new(ids[i], group), ids[i]);
                }
            }
        }

        protected abstract bool GroupIncludeCondition(in ExclusiveGroupStruct exclusiveGroupStruct);
    }
}