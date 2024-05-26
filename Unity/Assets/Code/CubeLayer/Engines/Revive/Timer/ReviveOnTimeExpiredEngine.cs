using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer;
using Code.TimersLayer.Components;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Revive.Timer
{
    public class ReviveCubeAddToAliveFilterEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
            _filters.CreateTransientFilter<Timer<Alive>>(DestroyableFilterIds.AliveEntities);
        }

        public EntitiesDB entitiesDB { get; set; }
        private EntitiesDB.SveltoFilters _filters;

        public string name => GetType().Name;

        public void Step()
        {
            var expiredTimerFilter = _filters.GetTransientFilter<Timer<Alive>>(TimerFilters.ExpiredTimer);
            var aliveFilter = _filters.GetTransientFilter<Timer<Alive>>(DestroyableFilterIds.AliveEntities);

            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct group) in expiredTimerFilter)
            {
                for (var i = 0; i < indices.count; i++)
                {
                    aliveFilter.Add(new(indices[i], group), indices[i]);
                }
            }
        }
    }
}