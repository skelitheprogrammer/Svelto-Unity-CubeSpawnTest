using Code.Common.DataConfigSystem.ValueReference;
using Code.Common.DataConfigSystem.ValueReference.Unmanaged;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig.Attributes.Conditions
{
    [System.Serializable]
    public abstract class TimerCondition : ICondition
    {
        [SerializeReference, SubclassSelector] public IValueReferenceFloat Time = new ValueReferenceFloat();
    }
}