﻿using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Code.TransformLayer.Entities.Components;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.MOVE))]
    public class CubeMoveEngine : IStepEngine, IQueryingEntitiesEngine
    {
        public EntitiesDB entitiesDB { get; set; }
        public string name => nameof(CubeEngineNames.MOVE);

        private readonly ITime _time;

        public CubeMoveEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            foreach (((var positions, var directions, var speeds, int count), _) in entitiesDB.QueryEntities<Position, MoveDirection, MoveSpeed>(TransformableCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    positions[i].Value += directions[i].Value * (speeds[i].Value * _time.DeltaTime);
                }
            }
        }

        public void Ready()
        {
        }
    }
}