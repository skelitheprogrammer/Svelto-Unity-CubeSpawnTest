using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    public enum SpawnPositionType
    {
        ORIGIN,
        AROUND_SPHERE
    }

    [Serializable]
    public class SpawnPositionStrategy
    {
        public SpawnPositionType Type;
        [SerializeReference, SubclassSelector] public ISpawnModifier[] Modifiers;
    }

    public static class SpawnPositionExtensions
    {
        public static Vector3 GetSpawnPosition(this SpawnPositionStrategy strategy)
        {
            Vector3 position = strategy.Type switch
            {
                SpawnPositionType.ORIGIN => Vector3.zero,
                SpawnPositionType.AROUND_SPHERE => Random.onUnitSphere,
                _ => throw new ArgumentOutOfRangeException()
            };

            foreach (ISpawnModifier strategyModifier in strategy.Modifiers)
            {
                strategyModifier.Apply(ref position);
            }

            return position;
        }
    }
}