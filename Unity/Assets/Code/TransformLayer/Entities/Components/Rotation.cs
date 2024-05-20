using Svelto.ECS;
using UnityEngine;

namespace Code.TransformLayer.Entities.Components
{
    public struct Rotation : IEntityComponent
    {
        public Quaternion Value;
    }
}