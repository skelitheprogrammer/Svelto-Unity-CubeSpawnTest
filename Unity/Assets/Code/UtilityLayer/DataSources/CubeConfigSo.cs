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

        public float MinCenterOffset;
        public float MaxCenterOffset;

        public float MinDestroyDistance;
        public float MaxDestroyDistance;

        public float RespawnTimer;

        public float MinSpeed;
        public float MaxSpeed;

        public float MinAmplitude;
        public float MaxAmplitude;

        public float MinFrequency;
        public float MaxFrequency;

        public Vector3 SineWaveAxis;

        public GameObject Prefab;
    }
}