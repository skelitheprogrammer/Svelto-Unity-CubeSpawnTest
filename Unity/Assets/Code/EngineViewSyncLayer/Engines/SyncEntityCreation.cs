using Code.EngineViewSyncLayer.Components;
using Code.EngineViewSyncLayer.Objects;
using Svelto.ECS;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Engines
{
    public class SyncEntityCreation : IReactOnAddAndRemoveEx<ViewReference>
    {
        private readonly EntityInstanceManager<GameObject> _instanceManager;

        public SyncEntityCreation(EntityInstanceManager<GameObject> instanceManager)
        {
            _instanceManager = instanceManager;
        }

        public void Add((uint start, uint end) rangeOfEntities, in EntityCollection<ViewReference> entities, ExclusiveGroupStruct groupID)
        {
            var (buffer, entityIDs, _) = entities;

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                _instanceManager.Add(entityIDs[i], buffer[i].ResourceId);
            }
        }

        public void Remove((uint start, uint end) rangeOfEntities, in EntityCollection<ViewReference> entities, ExclusiveGroupStruct groupID)
        {
            var (buffer, entityIDs, _) = entities;

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                _instanceManager.Remove(entityIDs[i], buffer[i].ResourceId);
            }
        }
    }
}