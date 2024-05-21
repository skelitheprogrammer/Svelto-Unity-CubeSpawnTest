using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Entities.Components
{
    public struct SineWaveData : IEntityComponent
    {
        public float Value;
        
        public float Amplitude;
        public float Frequency;
        public Vector3 Axis;
    }
}