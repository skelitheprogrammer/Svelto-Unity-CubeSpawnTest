using Code.Common.DataConfigSystem.ValueReference.Unmanaged;
using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference.MinMax
{
    public abstract class MinMaxReferenceFloat : MinMaxReference<float>, IValueReferenceFloat
    {
        [SerializeReference, SubclassSelector] private IValueReferenceFloat _min = new ValueReferenceFloat();
        [SerializeReference, SubclassSelector] private IValueReferenceFloat _max = new ValueReferenceFloat();

        public override IValueReference<float> Min => _min;
        public override IValueReference<float> Max => _max;
    }
}