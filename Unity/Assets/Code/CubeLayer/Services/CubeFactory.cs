using Code.Common.DataConfigSystem;
using Code.Common.Svelto;
using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.EngineViewSyncLayer.Entities.Components;
using Code.TransformLayer.Entities.Components;
using Code.UtilityLayer;
using Svelto.DataStructures.Experimental;
using Svelto.ECS;

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

        public void Create(in CubeSettings config, ExclusiveBuildGroup buildGroup)
        {
            uint entityId = EntityIdStorage.Get();
            EntityInitializer entityInitializer = _entityFactory.BuildEntity<CubeEntityDescriptor>(entityId, buildGroup);

            entityInitializer
                .InitChained(new Position
                {
                    Value = config.SpawnPositionType.Apply()
                })
                .InitChained(new MoveDirection
                {
                    Value = config.SpawnPositionType.Apply()
                })
                .InitChained(new MoveSpeed
                {
                    Value = config.MoveSpeed.Reference
                })
                .InitChained(new ViewReference
                {
                    ResourceId = _resourceIndex
                })
                .InitChained(new DistanceTraveled
                {
                    From = entityInitializer.Get<Position>().Value
                });
        }
    }
}