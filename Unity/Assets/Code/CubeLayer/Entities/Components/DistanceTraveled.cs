using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Entities.Components
{
    public struct DistanceTraveled : IEntityComponent
    {
        public Vector3 From;
        public float Value;
    }
}