﻿using Code.CubeLayer.Entities.Components;
using Code.TransformLayer;
using Code.TransformLayer.Entities.Components;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Movement
{
    [Sequenced(nameof(CubeEngineNames.FACE_DIRECTION))]
    public class FaceRotationTowardsMoveDirectionEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }

        public void Step()
        {
            foreach (((var directions, var rotations, int count), _) in entitiesDB.QueryEntities<MoveDirection, Rotation>(Transformable.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    rotations[i].Value = Quaternion.FromToRotation(Vector3.up, directions[i].Value);
                }
            }
        }

        public string name => nameof(CubeEngineNames.FACE_DIRECTION);
    }
}