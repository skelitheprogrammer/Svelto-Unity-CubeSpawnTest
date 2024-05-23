using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference.Unmanaged
{
    [System.Serializable]
    public class ValueReferenceFloat : IValueReferenceFloat
    {
        [field: SerializeField] public virtual float Reference { get; private set; }
    }
}