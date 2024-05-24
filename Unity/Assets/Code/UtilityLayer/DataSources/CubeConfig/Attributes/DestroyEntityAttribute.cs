using Code.Common.DataConfigSystem.ValueReference;
using Code.Common.DataConfigSystem.ValueReference.Unmanaged;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    [System.Serializable]
    public partial class DestroyEntityAttribute : IEntityAttribute
    {
        [SerializeReference, SubclassSelector] public ICondition[] Conditions;
    }

    public partial class DestroyEntityAttribute
    {
        public interface ICondition
        {
        }

        [System.Serializable]
        public class DistanceReachCondition : ICondition
        {
            [SerializeReference, SubclassSelector] public IValueReferenceFloat DestroyDistance = new ValueReferenceFloat();
        }
    }
    
}