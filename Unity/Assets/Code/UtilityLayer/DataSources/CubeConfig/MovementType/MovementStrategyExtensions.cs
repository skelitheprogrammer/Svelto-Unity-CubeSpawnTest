using Code.Common.Svelto;
using Code.CubeLayer.Entities.Components;
using Svelto.ECS;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    public static class MovementStrategyExtensions
    {
        public static void ApplyStrategyToDescriptor<T>(this MovementStrategy strategy, ref DynamicEntityDescriptor<T> descriptor) where T : IEntityDescriptor, new()
        {
            switch (strategy)
            {
                case SineWaveMovementStrategy:
                    descriptor.Add<CubeLayer.Entities.Components.SineWaveData>();
                    break;
                case StraightLineMovementStrategy:
                    break;
            }
        }

        public static void ApplyStrategyToInitializer(this MovementStrategy strategy, ref EntityInitializer initializer)
        {
            switch (strategy)
            {
                case SineWaveMovementStrategy sineWaveMovementStrategy:
                    initializer
                        .InitChained(new MoveSpeed
                        {
                            Value = sineWaveMovementStrategy.Speed.Reference
                        })
                        .InitChained(new CubeLayer.Entities.Components.SineWaveData
                        {
                            Axis = Vector3.up,
                            Amplitude = sineWaveMovementStrategy.SineWaveData.Amplitude.Reference,
                            Frequency = sineWaveMovementStrategy.SineWaveData.Frequency.Reference,
                        });
                    break;
                case StraightLineMovementStrategy straightLineMovementStrategy:
                    initializer
                        .InitChained(new MoveSpeed
                        {
                            Value = straightLineMovementStrategy.Speed.Reference
                        });
                    break;
            }
        }
    }
}