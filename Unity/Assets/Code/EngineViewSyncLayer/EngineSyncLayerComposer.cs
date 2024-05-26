using System;
using Code.EngineViewSyncLayer.Engines;
using Code.EngineViewSyncLayer.Objects;
using Code.Infrastructure;
using Svelto.DataStructures;
using Svelto.ECS;
using UnityEngine;
using static Code.Infrastructure.TickType;

namespace Code.EngineViewSyncLayer.Infrastructure
{
    public static class EngineSyncLayerComposer
    {
        public static void Compose(Action<TickType?, IEngine> addEngine, EntityInstanceManager<GameObject> instanceManager)
        {
            SyncEntityState syncEntityStateReactionEngine = new(instanceManager);

            SyncPositionEngine syncPositionEngine = new(instanceManager);
            SyncRotationEngine syncRotationEngine = new(instanceManager);

            var unsortedGroup = new FasterList<IStepEngine>(
                syncPositionEngine,
                syncRotationEngine
            );
            SyncLayerUnsortedTickGroup syncLayerUnsortedTickGroup = new(unsortedGroup);

            addEngine(null, syncEntityStateReactionEngine);
            
            addEngine(TICK, syncLayerUnsortedTickGroup);
        }
    }
}