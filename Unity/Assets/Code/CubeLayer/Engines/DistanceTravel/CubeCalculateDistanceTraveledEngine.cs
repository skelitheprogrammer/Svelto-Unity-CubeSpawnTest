﻿using Code.CubeLayer.Entities;
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
            var groups = entitiesDB.FindGroups<Position, DistanceTraveled>();

            foreach (((var positions, var distanceTraveleds, int count), var groupStruct) in entitiesDB.QueryEntities<Position, DistanceTraveled>(groups))
            {
                if (!AliveCubes.Includes(groupStruct))
                {
                    continue;
                }

                for (int i = 0; i < count; i++)
                {
                    distanceTraveleds[i].Value = Vector3.Distance(distanceTraveleds[i].From, positions[i].Value);
                }
            }
        }

        public void MovedTo((uint start, uint end) rangeOfEntities, in EntityCollection<DistanceTraveled> entities, ExclusiveGroupStruct fromGroup, ExclusiveGroupStruct toGroup)
        {
            if (!AliveCubes.Includes(toGroup))
            {
                return;
            }

            var (positions, distanceTraveleds, count) = entitiesDB.QueryEntities<Position, DistanceTraveled>(toGroup);

            for (int i = 0; i < count; i++)
            {
                distanceTraveleds[i].From = positions[i].Value;
            }
        }
    }
}