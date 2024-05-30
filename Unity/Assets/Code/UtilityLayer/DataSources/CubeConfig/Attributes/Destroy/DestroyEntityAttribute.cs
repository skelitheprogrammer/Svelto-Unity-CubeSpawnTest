using System;
using Code.Common.DataConfigSystem.ValueReference;
using Code.Common.DataConfigSystem.ValueReference.Unmanaged;
using Code.UtilityLayer.DataSources.CubeConfig.Attributes.Conditions;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig.Attributes.Destroy
{
    [Serializable]
    public partial class DestroyEntityAttribute : IEntityAttribute
    {
        public interface IDestroyCondition : ICondition
        {
        }

        [SerializeReference, SubclassSelector] public IDestroyCondition[] Conditions;
    }

    public partial class DestroyEntityAttribute
    {
        [Serializable]
        public class DistanceReachCondition : IDestroyCondition
        {
            [SerializeReference, SubclassSelector] public IValueReferenceFloat DestroyDistance = new ValueReferenceFloat();
        }
        
        [Serializable]
        public class DestroyTimerCondition : TimerCondition, IDestroyCondition
        {
        }
    }


}