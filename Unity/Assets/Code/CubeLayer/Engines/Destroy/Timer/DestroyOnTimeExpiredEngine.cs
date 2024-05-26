using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer;
using Code.TimersLayer.Components;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Destroy.Timer
{
    [Sequenced(nameof(CubeEngineNames.DESTROY_ON_TIMER_EXPIRED))]
    public class DestroyOnTimeExpiredEngine : IQueryingEntitiesEngine, IStepEngine
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
                    Debug.Log("DeadFilterAdded");
                }
            }
        }

        public string name => nameof(CubeEngineNames.DESTROY_ON_TIMER_EXPIRED);
    }
}