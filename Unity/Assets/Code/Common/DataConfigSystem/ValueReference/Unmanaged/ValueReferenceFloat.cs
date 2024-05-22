using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference
{
    [System.Serializable]
    public class ValueReferenceFloat : IValueReferenceFloat
    {
        [field: SerializeField] public float Reference { get; private set; }
    }
}