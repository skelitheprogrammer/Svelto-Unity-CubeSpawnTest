using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer;
using Code.TimersLayer.Components;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Destroy.Timer
{
    public class DestroyCubeAddToDestroyFilterEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
            _filters.CreateTransientFilter<Timer<Dead>>(DestroyableFilterIds.DeadEntities);
        }

        public EntitiesDB entitiesDB { get; set; }
        private EntitiesDB.SveltoFilters _filters;

        public void Step()
        {
            var expiredTimerFilter = _filters.GetTransientFilter<Timer<Dead>>(TimerFilters.ExpiredTimer);
            var deadFilter = _filters.GetTransientFilter<Timer<Dead>>(DestroyableFilterIds.DeadEntities);

            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct group) in expiredTimerFilter)
            {
                for (var i = 0; i < indices.count; i++)
                {
                    deadFilter.Add(new(indices[i], group), indices[i]);
                }
            }
        }

        public string name => GetType().Name;
    }
}