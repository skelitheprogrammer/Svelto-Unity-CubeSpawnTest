using System;
using System.Linq;
using Code.Common.DataConfigSystem.ValueReference;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    public enum DirectionType
    {
        FORWARD,
        RIGHT,
        DOWN,
        UP,
        LEFT,
        ON_SPHERE
    }

    [Serializable]
    public class DirectionStrategy
    {
        public DirectionType Type;
        [SerializeReference, SubclassSelector] public IValueReferenceFloat[] Modifiers;
    }

    public static class DirectionStrategyExtensions
    {
        public static Vector3 GetDirection(this DirectionStrategy strategy)
        {
            Vector3 direction = strategy.Type switch
            {
                DirectionType.FORWARD => Vector3.forward,
                DirectionType.RIGHT => Vector3.right,
                DirectionType.DOWN => Vector3.down,
                DirectionType.UP => Vector3.up,
                DirectionType.LEFT => Vector3.left,
                DirectionType.ON_SPHERE => Random.onUnitSphere,
                _ => throw new ArgumentOutOfRangeException()
            };

            return strategy.Modifiers.Aggregate(direction, (current, valueReferenceFloat) => current * valueReferenceFloat.Reference);
        }
    }
}