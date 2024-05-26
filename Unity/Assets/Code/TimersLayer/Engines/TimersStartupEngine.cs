using Code.TimersLayer.Components;
using Svelto.ECS;

namespace Code.TimersLayer.Engines
{
    public abstract class TimersStartupEngine<T> : IQueryingEntitiesEngine, IReactOnAddEx<Timer<T>>, IReactOnSwapEx<Timer<T>>
    {
        public EntitiesDB entitiesDB { get; set; }

        public void Ready()
        {
            EntitiesDB.SveltoFilters filters = entitiesDB.GetFilters();
            filters.CreateTransientFilter<Timer<T>>(TimerFilters.ExpiredTimer);
        }

        public void Add((uint start, uint end) rangeOfEntities, in EntityCollection<Timer<T>> entities, ExclusiveGroupStruct groupID)
        {
            var (timers, _) = entities;

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                timers[i].Value = timers[i].StartValue;
            }
        }

        public void MovedTo((uint start, uint end) rangeOfEntities, in EntityCollection<Timer<T>> entities, ExclusiveGroupStruct fromGroup, ExclusiveGroupStruct toGroup)
        {
            if (!MovedToConditionGroup(toGroup))
            {
                return;
            }

            var (timers, _) = entities;

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                timers[i].Value = timers[i].StartValue;
            }
        }

        protected abstract bool MovedToConditionGroup(in ExclusiveGroupStruct groupStruct);
    }
}