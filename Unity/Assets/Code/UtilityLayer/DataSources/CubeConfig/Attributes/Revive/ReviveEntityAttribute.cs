using Code.Common.DataConfigSystem.ValueReference;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    [System.Serializable]
    public partial class ReviveEntityAttribute : IEntityAttribute
    {
        public interface IReviveCondition : ICondition
        {
        }

        [SerializeReference, SubclassSelector] public IReviveCondition[] Conditions;
    }

    public partial class ReviveEntityAttribute
    {
        [System.Serializable]
        public class ReviveAfterTimeCondition : IReviveCondition
        {
            [SerializeReference, SubclassSelector] public IValueReferenceFloat Timer;
        }
    }
}