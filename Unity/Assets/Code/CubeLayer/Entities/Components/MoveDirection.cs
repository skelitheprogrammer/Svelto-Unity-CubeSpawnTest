using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Entities.Components
{
    public struct MoveDirection : IEntityComponent
    {
        public Vector3 Value;
    }
}