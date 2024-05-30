using Code.CubeLayer;
using Code.EngineViewSyncLayer.Entities.Components;
using Code.EngineViewSyncLayer.Objects;
using Code.TransformLayer.Entities.Components;
using Svelto.ECS;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Engines
{
    public class SyncRotationEngine : IQueryingEntitiesEngine, IStepEngine
    {
        private readonly EntityInstanceManager<GameObject> _instanceManager;
        public EntitiesDB entitiesDB { get; set; }
        public string name => nameof(SyncRotationEngine);

        public SyncRotationEngine(EntityInstanceManager<GameObject> instanceManager)
        {
            _instanceManager = instanceManager;
        }

        public void Ready()
        {
        }

        public void Step()
        {
            var groups = entitiesDB.FindGroups<ViewReference, Position>();

            foreach (var ((_, positions, entitiesID, count), groupStruct) in entitiesDB.QueryEntities<ViewReference, Rotation>(groups))
            {
                if (AliveCubes.Includes(groupStruct))
                {
                    for (int i = 0; i < count; i++)
                    {
                        EGID entityId = new(entitiesID[i], groupStruct);
                        Rotation position = positions[i];
                        _instanceManager[entityId.entityID].transform.rotation = position.Value;
                    }
                }
            }
        }
    }
}