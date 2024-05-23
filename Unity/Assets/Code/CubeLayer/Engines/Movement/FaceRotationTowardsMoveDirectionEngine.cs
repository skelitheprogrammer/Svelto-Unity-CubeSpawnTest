using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
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
            var groups = entitiesDB.FindGroups<Position, MoveDirection, MoveSpeed>();

            foreach (((var directions, var rotations, int count), var groupStruct) in entitiesDB.QueryEntities<MoveDirection, Rotation>(groups))
            {
                if (AliveCubes.Includes(groupStruct))
                {
                    for (int i = 0; i < count; i++)
                    {
                        rotations[i].Value = Quaternion.FromToRotation(Vector3.up, directions[i].Value);
                    }
                }
            }
        }

        public string name => nameof(CubeEngineNames.FACE_DIRECTION);
    }
}