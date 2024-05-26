using Code.DestroyableLayer.Infrastructure;
using Code.EngineViewSyncLayer.Entities.Components;
using Code.EngineViewSyncLayer.Objects;
using Svelto.ECS;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Engines
{
    public class SyncEntityState : IReactOnAddAndRemoveEx<ViewReference>, IReactOnSwapEx<ViewReference>
    {
        private readonly EntityInstanceManager<GameObject> _instanceManager;

        public SyncEntityState(EntityInstanceManager<GameObject> instanceManager)
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

        public void MovedTo((uint start, uint end) rangeOfEntities, in EntityCollection<ViewReference> entities, ExclusiveGroupStruct fromGroup, ExclusiveGroupStruct toGroup)
        {
            var (buffer, entityIds, _) = entities;

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                if (Dead.Includes(toGroup))
                {
                    _instanceManager.Remove(entityIds[i], buffer[i].ResourceId);
                }

                if (Alive.Includes(toGroup))
                {
                    _instanceManager.Add(entityIds[i], buffer[i].ResourceId);
                }
            }
        }
    }
}