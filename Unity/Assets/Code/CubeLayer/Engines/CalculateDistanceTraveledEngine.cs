using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.CALCULATE_CUBE_DISTANCE))]
    public class CalculateDistanceTraveledEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }

        public void Step()
        {
            foreach (((var positions, var distanceTraveleds, int count), _) in entitiesDB.QueryEntities<Position, DistanceTraveled>(Movable.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    Position position = positions[i];
                    ref DistanceTraveled traveled = ref distanceTraveleds[i];

                    traveled.Value = Vector3.Distance(position.Value, traveled.Start);
                }
            }
        }

        public string name => nameof(CubeEngineNames.CALCULATE_CUBE_DISTANCE);
    }
}