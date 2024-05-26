using Svelto.ECS;

namespace Code.TimersLayer.Engines
{
    public abstract class TimersStartupEngine<T> : IQueryingEntitiesEngine, IReactOnAddEx<Timer<T>>, IReactOnSwapEx<Timer<T>>
    {
        public void Ready()
        {
            EntitiesDB.SveltoFilters filters = entitiesDB.GetFilters();
            filters.CreateTransientFilter<Timer<T>>(TimerFilters.ExpiredTimer);
        }

        public EntitiesDB entitiesDB { get; set; }

        public void Add((uint start, uint end) rangeOfEntities, in EntityCollection<Timer<T>> entities, ExclusiveGroupStruct groupID)
        {
            var (timers, _) = entities;

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                ref var timer = ref timers[i];
                timer.Value = timer.StartValue;
            }
        }

        public abstract void MovedTo((uint start, uint end) rangeOfEntities, in EntityCollection<Timer<T>> entities, ExclusiveGroupStruct fromGroup, ExclusiveGroupStruct toGroup);
    }
}