using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    [CreateAssetMenu(menuName = "Create CubeSpawnConfig", fileName = "CubeSpawnConfig", order = 0)]
    public class CubeConfigSo : ScriptableObject
    {
        [field: SerializeField] public CubeConfig Config { get; private set; }
    }

    [System.Serializable]
    public class CubeConfig
    {
        [SerializeReference, SubclassSelector] public ICubeSettings[] CubeSettings;
        public GameObject Prefab;
    }
}