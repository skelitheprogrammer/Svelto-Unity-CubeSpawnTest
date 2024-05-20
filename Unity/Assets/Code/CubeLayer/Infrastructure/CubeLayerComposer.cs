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
        public static void Compose(Action<TickType?, IEngine> addEngine, CubeFactory factory, CubeConfig config, ITime time, IEntityFunctions functions)
        {
            CubeStartupEngine cubeStartupEngine = new(factory, config);
            CubeMoveEngine cubeMoveEngine = new(time);
            CubeFaceMoveDirectionEngine cubeFaceMoveDirectionEngine = new();

            CubeCalculateDistanceTraveledEngine calculateDistanceTraveledEngine = new();
            DestroyCubesOnDistanceTraveled destroyCubesOnDistanceTraveled = new(functions);


            addEngine(TickType.STARTUP, cubeStartupEngine);
            addEngine(TickType.TICK, cubeMoveEngine);
            addEngine(TickType.TICK, cubeFaceMoveDirectionEngine);
            addEngine(TickType.TICK, calculateDistanceTraveledEngine);
            addEngine(TickType.TICK, destroyCubesOnDistanceTraveled);
        }
    }
}