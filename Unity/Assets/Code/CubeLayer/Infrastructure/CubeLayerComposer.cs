using System;
using Code.CubeLayer.Engines;
using Code.Infrastructure;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources;
using Svelto.ECS;

namespace Code.CubeLayer.Infrastructure
{
    public static class CubeLayerComposer
    {
        public static void Compose(Action<TickType, IStepEngine> addEngine, CubeFactory factory, CubeConfig config, ITime time)
        {
            CubeStartupEngine cubeStartupEngine = new(factory, config);

            CubeMoveEngine cubeMoveEngine = new(time);

            addEngine(TickType.STARTUP, cubeStartupEngine);
            addEngine(TickType.TICK, cubeMoveEngine);
        }
    }
}