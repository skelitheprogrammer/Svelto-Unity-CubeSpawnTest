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

        public void Create(in CubeSettings config)
        {
            uint entityId = EntityIdStorage.Get();
            DynamicEntityDescriptor<CubeEntityDescriptor> dynamicEntityDescriptor = DynamicEntityDescriptor<CubeEntityDescriptor>.CreateDynamicEntityDescriptor();

            config.MovementType.ApplyStrategyToDescriptor(ref dynamicEntityDescriptor);
            config.Attributes.ApplyAttributesToDescriptor(ref dynamicEntityDescriptor);

            EntityInitializer initializer = _entityFactory.BuildEntity(entityId, AliveCubes.BuildGroup, dynamicEntityDescriptor);

            Vector3 spawnPosition = config.SpawnType.GetSpawnPosition();

            initializer
                .InitChained(new Position
                {
                    Value = spawnPosition
                })
                .InitChained(new MoveDirection
                {
                    Value = config.DirectionType.GetDirection()
                })
                .InitChained(new ViewReference
                {
                    ResourceId = _resourceIndex
                })
                ;

            config.MovementType.ApplyStrategyToInitializer(ref initializer);
            config.Attributes.ApplyAttributesToInitializer(ref initializer);
        }
    }
}