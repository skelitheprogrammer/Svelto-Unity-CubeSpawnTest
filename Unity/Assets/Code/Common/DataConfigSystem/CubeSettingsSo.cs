using Code.Common.DataConfigSystem.ValueReference;
using UnityEngine;

namespace Code.Common.DataConfigSystem
{
    [CreateAssetMenu(menuName = "Create CubeSettingsSo", fileName = "CubeSettingsSo", order = 0)]
    public class CubeSettingsSo : ScriptableObject
    {
        public CubeSettings Settings;
    }


    [System.Serializable]
    public class CubeSettings
    {
        [SerializeReference, SubclassSelector] public IValueReferenceInt Count;
        [SerializeReference, SubclassSelector] public CubeSpawnPositionType SpawnPositionType;
        [SerializeReference, SubclassSelector] public IValueReferenceFloat MoveSpeed;
    }
}