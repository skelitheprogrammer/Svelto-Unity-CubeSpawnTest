using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Code.EngineViewSyncLayer.Entities.Components;
using Code.TransformLayer.Entities.Components;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources;
using Svelto.DataStructures.Experimental;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer
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

        public void Create(in CubeConfig config)
        {
            EntityInitializer entityInitializer = CreateInternal<CubeEntityDescriptor>(TransformableCubes.BuildGroup);

            Configure(ref entityInitializer, config);
        }

        public void CreateDistanceTraveled(in CubeConfig config)
        {
            EntityInitializer entityInitializer = CreateInternal<CubeWithDistanceTraveledDescriptor>(AliveCubes.BuildGroup);

            Configure(ref entityInitializer, config);

            entityInitializer
                .InitChained(new DistanceTraveled
                {
                    From = entityInitializer.Get<Position>().Value
                })
                .InitChained(new DestroyDistance
                {
                    Value = Random.Range(config.MinDestroyDistance, config.MaxDestroyDistance)
                });
        }

        public void CreateRevivable(in CubeConfig config)
        {
            EntityInitializer entityInitializer = CreateInternal<CubeWithReviveTimerDescriptor>(AliveCubes.BuildGroup);

            Configure(ref entityInitializer, config);

            entityInitializer
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
                });
        }

        private ref EntityInitializer Configure(ref EntityInitializer entityInitializer, CubeConfig config)
        {
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
                });

            return ref entityInitializer;
        }

        private EntityInitializer CreateInternal<T>(ExclusiveBuildGroup group) where T : IEntityDescriptor, new()
        {
            uint entityID = EntityIdStorage.Get();
            EntityInitializer entityInitializer = _entityFactory.BuildEntity<T>(entityID, group);

            return entityInitializer;
        }
    }
}