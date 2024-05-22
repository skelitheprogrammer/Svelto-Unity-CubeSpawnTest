using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference
{
    public abstract class MinMaxRangeFloat : IValueReferenceFloat
    {
        [SerializeReference, SubclassSelector] public IValueReferenceFloat Min;
        [SerializeReference, SubclassSelector] public IValueReferenceFloat Max;
        public abstract float Reference { get; }
    }

    [System.Serializable]
    public class MinMaxRangeUnityFloat : MinMaxRangeFloat
    {
        public override float Reference => Random.Range(Min.Reference, Max.Reference);
    }
}