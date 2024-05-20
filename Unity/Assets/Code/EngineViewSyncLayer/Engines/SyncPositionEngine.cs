using Code.EngineViewSyncLayer.Entities.Components;
using Code.EngineViewSyncLayer.Infrastructure;
using Code.EngineViewSyncLayer.Objects;
using Code.TransformLayer.Entities.Components;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Engines
{
    [Sequenced(nameof(SyncEngineNames.SYNC_POSITION_ENGINE))]
    public class SyncPositionEngine : IQueryingEntitiesEngine, IStepEngine
    {
        private readonly EntityInstanceManager<GameObject> _instanceManager;
        public EntitiesDB entitiesDB { get; set; }
        public string name => nameof(SyncEngineNames.SYNC_POSITION_ENGINE);

        public SyncPositionEngine(EntityInstanceManager<GameObject> instanceManager)
        {
            _instanceManager = instanceManager;
        }

        public void Ready()
        {
        }

        public void Step()
        {
            var groups = entitiesDB.FindGroups<ViewReference, Position>();
            
            foreach (var ((_, positions, entitiesID, count), groupId) in entitiesDB.QueryEntities<ViewReference, Position>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    EGID entityId = new(entitiesID[i], groupId);
                    Position position = positions[i];
                    _instanceManager[entityId.entityID].transform.position = position.Value;
                }
            }
        }
    }
}