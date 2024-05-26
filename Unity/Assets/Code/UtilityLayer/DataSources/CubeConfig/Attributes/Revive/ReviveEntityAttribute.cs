using Code.UtilityLayer.DataSources.CubeConfig.Attributes.Conditions;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig.Attributes.Revive
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
        public class ReviveTimerCondition : TimerCondition, IReviveCondition
        {
        }
    }
}