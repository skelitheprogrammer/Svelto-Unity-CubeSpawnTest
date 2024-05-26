using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.DestroyableLayer.Infrastructure;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Destroy.DistanceTravel
{
    [Sequenced(nameof(CubeEngineNames.DESTROY_ON_DISTANCE))]
    public class DestroyCubesOnDistanceTraveled : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();

            _filters.CreateTransientFilter<DestroyDistance>(DestroyableFilterIds.DeadEntities);
        }

        public EntitiesDB entitiesDB { get; set; }
        private EntitiesDB.SveltoFilters _filters;
        public string name => nameof(CubeEngineNames.DESTROY_ON_DISTANCE);

        public void Step()
        {
            var groups = entitiesDB.FindGroups<DistanceTraveled, DestroyDistance>();
            EntityFilterCollection filter = _filters.GetTransientFilter<DestroyDistance>(DestroyableFilterIds.DeadEntities);

            foreach ((var (distanceTraveleds, destroyDistances, ids, count), ExclusiveGroupStruct groupStruct) in entitiesDB.QueryEntities<DistanceTraveled, DestroyDistance>(groups))
            {
                if (!AliveCubes.Includes(groupStruct))
                {
                    continue;
                }

                for (int i = 0; i < count; i++)
                {
                    bool condition = distanceTraveleds[i].Value >= destroyDistances[i].Value;

                    if (!condition)
                    {
                        continue;
                    }

                    filter.Add(new(ids[i], groupStruct), ids[i]);
                }
            }
        }
    }
}