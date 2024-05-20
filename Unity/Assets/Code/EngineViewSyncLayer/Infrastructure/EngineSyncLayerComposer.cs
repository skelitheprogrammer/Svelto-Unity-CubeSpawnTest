using System;
using Code.EngineViewSyncLayer.Engines;
using Code.EngineViewSyncLayer.Objects;
using Code.Infrastructure;
using Svelto.ECS;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Infrastructure
{
    public static class EngineSyncLayerComposer
    {
        public static void Compose(Action<TickType, IEngine> addEngine, EntityInstanceManager<GameObject> instanceManager)
        {
            SyncEntityState syncEntityState = new(instanceManager);

            SyncPositionEngine syncPositionEngine = new(instanceManager);
            SyncRotationEngine syncRotationEngine = new(instanceManager);

            addEngine(TickType.TICK, syncEntityState);
            addEngine(TickType.TICK, syncPositionEngine);
            addEngine(TickType.TICK, syncRotationEngine);
        }
    }
}