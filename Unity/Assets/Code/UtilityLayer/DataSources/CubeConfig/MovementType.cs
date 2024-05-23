using Code.Common.DataConfigSystem.ValueReference;
using Code.Common.DataConfigSystem.ValueReference.Unmanaged;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    public enum MovementType
    {
        STRAIGHT_LINE,
        SINE_WAVE
    }


    public abstract class MovementStrategy
    {
    }


    [System.Serializable]
    public class StraightLineMovementStrategy : MovementStrategy
    {
        [SerializeReference, SubclassSelector] public IValueReferenceFloat Speed = new ValueReferenceFloat();
    }

    [System.Serializable]
    public class SineWaveMovementStrategy : MovementStrategy
    {
        [SerializeReference, SubclassSelector] public IValueReferenceFloat Speed = new ValueReferenceFloat();
        public SineWaveData SineWaveData;
    }

    [System.Serializable]
    public class SineWaveData
    {
        [SerializeReference, SubclassSelector] public IValueReferenceFloat Frequency = new ValueReferenceFloat();
        [SerializeReference, SubclassSelector] public IValueReferenceFloat Amplitude = new ValueReferenceFloat();
    }
}