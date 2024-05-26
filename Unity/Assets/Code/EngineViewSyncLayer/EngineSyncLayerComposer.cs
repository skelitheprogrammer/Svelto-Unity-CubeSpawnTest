using Code.EngineViewSyncLayer.Engines;
using Code.EngineViewSyncLayer.Objects;
using Svelto.DataStructures;
using Svelto.ECS;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Infrastructure
{
    public static class EngineSyncLayerComposer
    {
        public static void Compose(EnginesRoot root, FasterList<IStepEngine> tick, EntityInstanceManager<GameObject> instanceManager)
        {
            SyncEntityState syncEntityStateReactionEngine = new(instanceManager);

            SyncPositionEngine syncPositionEngine = new(instanceManager);
            SyncRotationEngine syncRotationEngine = new(instanceManager);

            var unsortedGroup = new FasterList<IStepEngine>(
                syncPositionEngine,
                syncRotationEngine
            );
            SyncLayerUnsortedTickGroup syncLayerUnsortedTickGroup = new(unsortedGroup);
            
            root.AddEngine(syncEntityStateReactionEngine);
            
            tick.Add(syncLayerUnsortedTickGroup);
            root.AddEngine(syncLayerUnsortedTickGroup);
        }
    }
}