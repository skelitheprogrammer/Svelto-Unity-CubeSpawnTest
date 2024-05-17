using Code.CubeLayer.DestroyableLayer.Infrastructure;
using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.DESTROY_CUBE_ON_DISTANCE_REACH))]
    public class DestroyOnDistanceTraveled : IQueryingEntitiesEngine, IStepEngine
    {
        public EntitiesDB entitiesDB { get; set; }
        private IEntityFunctions _functions;

        public DestroyOnDistanceTraveled(IEntityFunctions functions)
        {
            _functions = functions;
        }

        public void Ready()
        {
            entitiesDB.GetFilters();
        }

        public void Step()
        {
            foreach (var ((distanceTraveleds, destroyDistances, ids, count), groupStruct) in entitiesDB.QueryEntities<DistanceTraveled, DestroyDistance>(Movable.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    DistanceTraveled distanceTraveled = distanceTraveleds[i];
                    DestroyDistance destroyDistance = destroyDistances[i];

                    if (distanceTraveled.Value >= destroyDistance.Value)
                    {
                        _functions.SwapEntityGroup<DestroyableCubeEntityDescriptor>(ids[i], groupStruct, Destroyed.BuildGroup);
                    }
                }
            }
        }

        public string name => nameof(CubeEngineNames.DESTROY_CUBE_ON_DISTANCE_REACH);
    }
}