using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.FACE_DIRECTION_ENGINE))]
    public class FaceCubeDirectionEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public EntitiesDB entitiesDB { get; set; }

        public string name => nameof(CubeEngineNames.FACE_DIRECTION_ENGINE);

        public void Ready()
        {
        }

        public void Step()
        {
            foreach (((var rotations, var directions, int count), _) in entitiesDB.QueryEntities<Rotation, Direction>(MovableCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref Rotation rotation = ref rotations[i];
                    ref Direction direction = ref directions[i];

                    rotation.Value = Quaternion.FromToRotation(Vector3.up, direction.Value);
                }
            }
        }
    }
}