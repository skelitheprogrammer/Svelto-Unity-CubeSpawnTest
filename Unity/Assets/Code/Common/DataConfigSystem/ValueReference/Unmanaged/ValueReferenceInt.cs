using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference
{
    [System.Serializable]
    public class ValueReferenceInt : IValueReferenceInt
    {
        [field: SerializeField] public int Reference { get; private set; }
    }
}