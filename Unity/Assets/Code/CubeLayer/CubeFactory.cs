using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Code.EngineViewSyncLayer.Components;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources;
using Svelto.DataStructures.Experimental;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer
{
    public class CubeFactory
    {
        private readonly IdStorage _storage;

        private readonly IEntityFactory _entityFactory;
        private readonly ValueIndex _resourceIndex;

        public CubeFactory(IEntityFactory entityFactory, ValueIndex resourceIndex)
        {
            _entityFactory = entityFactory;
            _resourceIndex = resourceIndex;
            _storage = new();
        }

        public void Create(in CubeConfig config)
        {
            uint entityID = _storage.Get();
            EntityInitializer entityInitializer = _entityFactory.BuildEntity<CubeEntityDescriptor>(entityID, MovableCubes.BuildGroup);

            Vector3 onUnit = Random.onUnitSphere;
            float positionOffset = Random.Range(config.MinCenterOffset, config.MaxCenterOffset);

            //imagine if this could be chained instead of 'void'
            entityInitializer.Init(new Position
            {
                Value = onUnit * positionOffset
            });
            entityInitializer.Init(new Direction
            {
                Value = onUnit
            });
            entityInitializer.Init(new MoveSpeed
            {
                Value = Random.Range(config.MinSpeed, config.MaxSpeed)
            });
            entityInitializer.Init(new ViewReference
            {
                ResourceId = _resourceIndex
            });
            
        }
    }
}