using UnityEngine;

namespace Code.UtilityLayer.DataSources
{
    [CreateAssetMenu(menuName = "Create CubeSpawnConfig", fileName = "CubeSpawnConfig", order = 0)]
    public class CubeConfigSo : ScriptableObject
    {
        [field: SerializeField] public CubeConfig Config { get; private set; }
    }

    [System.Serializable]
    public class CubeConfig
    {
        public int Count;
        public int WithDistanceCount;

        public float MinCenterOffset;
        public float MaxCenterOffset;

        public float MinDestroyDistance;
        public float MaxDestroyDistance;

        public float RespawnTimer;


        public float MinSpeed;
        public float MaxSpeed;

        //Could be assetReference from addressables

        public GameObject Prefab;
    }
}