using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.TransformLayer.Entities.Components;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.DistanceTravel
{
    [Sequenced(nameof(CubeEngineNames.CALCULATE_DISTANCE))]
    public class CubeCalculateDistanceTraveledEngine : IQueryingEntitiesEngine, IStepEngine, IReactOnSwapEx<DistanceTraveled>
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }

        public string name => nameof(CubeEngineNames.CALCULATE_DISTANCE);

        public void Step()
        {
            foreach (((var positions, var distanceTraveleds, int count), _) in entitiesDB.QueryEntities<Position, DistanceTraveled>(CubesWithTraveledDistance.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    distanceTraveleds[i].Value = Vector3.Distance(distanceTraveleds[i].From, positions[i].Value);
                }
            }
        }

        public void MovedTo((uint start, uint end) rangeOfEntities, in EntityCollection<DistanceTraveled> entities, ExclusiveGroupStruct fromGroup, ExclusiveGroupStruct toGroup)
        {
            (var positions, var distanceTraveleds, int count) = entitiesDB.QueryEntities<Position, DistanceTraveled>(toGroup);

            for (int i = 0; i < count; i++)
            {
                distanceTraveleds[i].From = positions[i].Value;
            }
        }
    }
}