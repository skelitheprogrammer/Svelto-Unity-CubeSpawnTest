using Code.Common.DataConfigSystem.ValueReference.Unmanaged;
using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference.MinMax
{
    public abstract class MinMaxReferenceInt : MinMaxReference<int>, IValueReferenceInt
    {
        [SerializeReference, SubclassSelector] private IValueReferenceInt _min = new ValueReferenceInt();
        [SerializeReference, SubclassSelector] private IValueReferenceInt _max = new ValueReferenceInt();

        public override IValueReference<int> Min => _min;
        public override IValueReference<int> Max => _max;
    }
}