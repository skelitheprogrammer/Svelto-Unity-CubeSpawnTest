using UnityEngine;

namespace Code.UtilityLayer.DataSources
{
    [CreateAssetMenu(menuName = "Create CubeSpawnConfig", fileName = "CubeSpawnConfig", order = 0)]
    public class CubeConfigSo : ScriptableObject
    {
        [field: SerializeField] public CubeConfig Config { get; private set; }
        [field: SerializeField] public DestroyableCubeConfig DestroyableCubeConfig { get; private set; }
    }

    [System.Serializable]
    public class CubeConfig
    {
        public int Count;

        public float MinCenterOffset;
        public float MaxCenterOffset;

        public float MinSpeed;
        public float MaxSpeed;

        //Could be assetReference from addressables

        public GameObject Prefab;
    }

    [System.Serializable]
    public class DestroyableCubeConfig
    {
        public CubeConfig Default;
        public float MinDestroyDistance;
        public float MaxDestroyDistance;
    }
}