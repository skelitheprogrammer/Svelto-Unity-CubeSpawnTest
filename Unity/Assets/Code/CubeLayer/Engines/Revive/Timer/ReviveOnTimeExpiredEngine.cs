using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Revive
{
    [Sequenced(nameof(CubeEngineNames.REVIVE_ON_TIMER_EXPIRED))]
    public class ReviveOnTimerExpiredEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
            _filters.CreateTransientFilter<Timer<Alive>>(DestroyableFilterIds.AliveEntities);
        }

        public EntitiesDB entitiesDB { get; set; }
        private EntitiesDB.SveltoFilters _filters;

        public void Step()
        {
            var expiredTimerFilter = _filters.GetTransientFilter<Timer<Alive>>(TimerFilters.ExpiredTimer);
            var aliveFilter = _filters.GetTransientFilter<Timer<Alive>>(DestroyableFilterIds.AliveEntities);

            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct group) in expiredTimerFilter)
            {
                for (var i = 0; i < indices.count; i++)
                {
                    aliveFilter.Add(new(indices[i], group), indices[i]);
                    Debug.Log("AliveFilterAdded");
                }
            }
        }

        public string name => nameof(CubeEngineNames.REVIVE_ON_TIMER_EXPIRED);
    }
}