using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference.Unmanaged
{
    [System.Serializable]
    public class ValueReferenceVector3 : IValueReferenceVector3
    {
        [field: SerializeField] public virtual Vector3 Reference { get; private set; }
    }
}