using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Entities.Components
{
    public struct DistanceTraveled : IEntityComponent
    {
        public readonly Vector3 Start;
        public float Value;

        public DistanceTraveled(Vector3 start) : this()
        {
            Start = start;
        }
    }
}