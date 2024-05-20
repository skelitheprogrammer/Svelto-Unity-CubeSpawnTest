using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.DESTROY_ON_DISTANCE))]
    public class DestroyCubesOnDistanceTraveled : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }
        private readonly IEntityFunctions _functions;
        public string name => nameof(CubeEngineNames.DESTROY_ON_DISTANCE);

        public DestroyCubesOnDistanceTraveled(IEntityFunctions functions)
        {
            _functions = functions;
        }

        public void Step()
        {
            foreach ((var (distanceTraveleds, destroyDistances, ids, count), ExclusiveGroupStruct groupStruct) in entitiesDB.QueryEntities<DistanceTraveled, DestroyDistance>(AliveCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    bool condition = distanceTraveleds[i].Value >= destroyDistances[i].Value;

                    if (!condition)
                    {
                        continue;
                    }

                    EGID egid = new(ids[i], groupStruct);
                    _functions.SwapEntityGroup<CubeWithDistanceTraveledDescriptor>(egid, DestroyedCubes.BuildGroup);
                }
            }
        }
    }
}