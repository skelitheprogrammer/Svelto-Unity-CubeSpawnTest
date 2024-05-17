using Code.EngineViewSyncLayer.Engines;
using Code.EngineViewSyncLayer.Objects;
using Svelto.DataStructures;
using Svelto.ECS;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Infrastructure
{
    public static class EngineSyncLayerComposer
    {
        public static void Compose(EnginesRoot root, EntityInstanceManager<GameObject> instanceManager, FasterList<IStepEngine> orderedEngines)
        {
            SyncPositionEngine syncPositionEngine = new(instanceManager);
            SyncRotationEngine syncRotationEngine = new(instanceManager);

            orderedEngines.Add(syncPositionEngine);
            orderedEngines.Add(syncRotationEngine);

            root.AddEngine(new SyncEntityCreation(instanceManager));
            root.AddEngine(syncPositionEngine);
            root.AddEngine(syncRotationEngine);
        }
    }
}