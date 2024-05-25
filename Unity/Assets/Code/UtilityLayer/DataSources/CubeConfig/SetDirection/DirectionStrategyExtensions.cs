using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.UtilityLayer.DataSources.CubeConfig.SetDirection
{
    public static class DirectionStrategyExtensions
    {
        public static Vector3 GetDirection(this DirectionType strategy)
        {
            Vector3 direction = strategy switch
            {
                DirectionType.UP => Vector3.up,
                DirectionType.RIGHT => Vector3.right,
                DirectionType.DOWN => Vector3.down,
                DirectionType.LEFT => Vector3.left,
                DirectionType.BACK => Vector3.back,
                DirectionType.FORWARD => Vector3.forward,
                DirectionType.RANDOM_ON_SPHERE => Random.onUnitSphere,
                _ => throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null)
            };

            return direction;
        }
    }
}