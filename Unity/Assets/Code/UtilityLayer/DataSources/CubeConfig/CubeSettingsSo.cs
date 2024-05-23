using Code.Common.DataConfigSystem.ValueReference;
using Code.Common.DataConfigSystem.ValueReference.Unmanaged;
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
        [SerializeReference, SubclassSelector] public MovementStrategy MovementType;
        [SerializeReference, SubclassSelector] public IValueReferenceInt Count;
        public SpawnPositionStrategy SpawnStrategy;
        public DirectionStrategy DirectionStrategy;
    }

    [System.Serializable]
    public class CubeSettingsReference : ICubeSettings
    {
        public CubeSettingsSo Reference;

        public static implicit operator CubeSettings(CubeSettingsReference so) => so.Reference.Settings;
    }
}