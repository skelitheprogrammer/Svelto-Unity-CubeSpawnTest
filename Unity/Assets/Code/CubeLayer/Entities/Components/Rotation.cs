using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Entities.Components
{
    public struct Rotation : IEntityComponent
    {
        public Quaternion Value;
    }
}