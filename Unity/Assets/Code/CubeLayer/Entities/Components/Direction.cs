using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Entities.Components
{
    public struct Direction : IEntityComponent
    {
        public Vector3 Value;
    }

    public struct Rotation : IEntityComponent
    {
        public Quaternion Value;
    }
}