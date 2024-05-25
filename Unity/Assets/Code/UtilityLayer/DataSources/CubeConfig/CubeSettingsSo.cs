using Code.Common.DataConfigSystem.ValueReference;
using Code.UtilityLayer.DataSources.CubeConfig.Attributes;
using Code.UtilityLayer.DataSources.CubeConfig.MovementType;
using Code.UtilityLayer.DataSources.CubeConfig.SetDirection;
using Code.UtilityLayer.DataSources.CubeConfig.SpawnPosition;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    [CreateAssetMenu(menuName = "Create CubeSettingsSo", fileName = "CubeSettingsSo", order = 0)]
    public class CubeSettingsSo : ScriptableObject
    {
        [field: SerializeField] public CubeSettings Settings { get; private set; }

        public static implicit operator CubeSettings(CubeSettingsSo so) => so.Settings;
    }

    public interface ICubeSettings
    {
    }

    [System.Serializable]
    public class CubeSettings : ICubeSettings
    {
        [SerializeReference, SubclassSelector] public IValueReferenceInt Count;
        [SerializeReference, SubclassSelector] public MovementStrategy MovementType;
        public DirectionType DirectionType;
        public SpawnPositionType SpawnType;
        [SerializeReference, SubclassSelector] public IEntityAttribute[] Attributes;
    }

    [System.Serializable]
    public class CubeSettingsReference : ICubeSettings
    {
        public CubeSettingsSo Reference;

        public static implicit operator CubeSettings(CubeSettingsReference so) => so.Reference.Settings;
    }
}