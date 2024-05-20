using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Code.TransformLayer.Entities.Components;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.CALCULATE_DISTANCE))]
    public class CubeCalculateDistanceTraveledEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }

        public string name => nameof(CubeEngineNames.CALCULATE_DISTANCE);

        public void Step()
        {
            foreach (((var positions, var distanceTraveleds, int count), _) in entitiesDB.QueryEntities<Position, DistanceTraveled>(TransformableCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    distanceTraveleds[i].Value = Vector3.Distance(distanceTraveleds[i].From, positions[i].Value);
                    Debug.Log(distanceTraveleds[i].Value);
                }
            }
        }
    }
}