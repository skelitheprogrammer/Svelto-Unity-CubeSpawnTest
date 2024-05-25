using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.UtilityLayer.DataSources.CubeConfig.SpawnPosition
{
    public static class SpawnPositionExtensions
    {
        public static Vector3 GetSpawnPosition(this SpawnPositionType strategy)
        {
            Vector3 position = strategy switch
            {
                SpawnPositionType.ORIGIN => Vector3.zero,
                SpawnPositionType.RANDOM_AROUND_SPHERE => Random.onUnitSphere,
                _ => throw new ArgumentOutOfRangeException()
            };

            return position;
        }
    }
}