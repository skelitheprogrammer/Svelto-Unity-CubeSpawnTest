using System;
using Code.Common.Svelto;
using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.EngineViewSyncLayer.Entities.Components;
using Code.TransformLayer.Entities.Components;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources.CubeConfig;
using Svelto.DataStructures.Experimental;
using Svelto.ECS;
using UnityEngine;
using SineWaveData = Code.CubeLayer.Entities.Components.SineWaveData;

namespace Code.CubeLayer.Services
{
    public class CubeFactory
    {
        private readonly IEntityFactory _entityFactory;
        private readonly ValueIndex _resourceIndex;

        public CubeFactory(IEntityFactory entityFactory, ValueIndex resourceIndex)
        {
            _entityFactory = entityFactory;
            _resourceIndex = resourceIndex;
        }

        /*public void Create(in CubeConfig config, ExclusiveBuildGroup buildGroup)
        {
            uint entityId = EntityIdStorage.Get();
            EntityInitializer entityInitializer = _entityFactory.BuildEntity<CubeEntityDescriptor>(entityId, buildGroup);

            Vector3 onUnit = Random.onUnitSphere;
            float positionOffset = Random.Range(config.MinCenterOffset, config.MaxCenterOffset);

            entityInitializer
                .InitChained(new Position
                {
                    Value = onUnit * positionOffset
                })
                .InitChained(new MoveDirection
                {
                    Value = onUnit
                })
                .InitChained(new MoveSpeed
                {
                    Value = Random.Range(config.MinSpeed, config.MaxSpeed)
                })
                .InitChained(new ViewReference
                {
                    ResourceId = _resourceIndex
                })
                .InitChained(new DistanceTraveled
                {
                    From = entityInitializer.Get<Position>().Value
                })
                .InitChained(new DestroyDistance
                {
                    Value = Random.Range(config.MinDestroyDistance, config.MaxDestroyDistance)
                })
                .InitChained(new ReviveTimer
                {
                    Timer = config.RespawnTimer
                })
                .InitChained(new DistanceTraveled
                {
                    From = entityInitializer.Get<Position>().Value
                })
                .InitChained(new DestroyDistance
                {
                    Value = Random.Range(config.MinDestroyDistance, config.MaxDestroyDistance)
                })
                .InitChained(new SineWaveData
                {
                    Amplitude = Random.Range(config.MinAmplitude, config.MaxAmplitude),
                    Frequency = Random.Range(config.MinFrequency, config.MaxFrequency),
                    Axis = config.SineWaveAxis
                });
        }*/

        public void Create(in CubeSettings config)
        {
            uint entityId = EntityIdStorage.Get();


            EntityInitializer entityInitializer = _entityFactory.BuildEntity<CubeEntityDescriptor>(entityId, config.MovementType.BuildGroup);

            entityInitializer
                .InitChained(new Position
                {
                    Value = config.SpawnStrategy.GetSpawnPosition()
                })
                .InitChained(new MoveDirection
                {
                    Value = config.DirectionStrategy.GetDirection()
                })
                .InitChained(new ViewReference
                {
                    ResourceId = _resourceIndex
                })
                ;

            switch (config.MovementType)
            {
                case SineWaveMovementStrategy sineWaveMovementStrategy:
                    entityInitializer.InitChained(new MoveSpeed
                    {
                        Value = sineWaveMovementStrategy.Speed.Reference
                    }).InitChained(new SineWaveData
                    {
                        Axis = Vector3.up,
                        Amplitude = sineWaveMovementStrategy.SineWaveData.Amplitude.Reference,
                        Frequency = sineWaveMovementStrategy.SineWaveData.Frequency.Reference,
                    });
                    break;
                case StraightLineMovementStrategy straightLineMovementStrategy:
                    entityInitializer.InitChained(new MoveSpeed
                    {
                        Value = straightLineMovementStrategy.Speed.Reference
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}