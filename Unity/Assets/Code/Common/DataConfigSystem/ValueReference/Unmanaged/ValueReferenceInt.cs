using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference.Unmanaged
{
    [System.Serializable]
    public class ValueReferenceInt : IValueReferenceInt
    {
        [field: SerializeField] public int Reference { get; private set; }

        public static implicit operator int(ValueReferenceInt referenceInt) => referenceInt.Reference;
    }
}