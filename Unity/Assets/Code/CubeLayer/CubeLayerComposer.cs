using System;
using Code.CubeLayer.Engines;
using Code.CubeLayer.Engines.DistanceTravel;
using Code.CubeLayer.Engines.Movement;
using Code.CubeLayer.Engines.Movement.SineWave;
using Code.CubeLayer.Engines.Revive;
using Code.CubeLayer.Services;
using Code.Infrastructure;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources;
using Svelto.ECS;
using static Code.Infrastructure.TickType;

namespace Code.CubeLayer
{
    public static class CubeLayerComposer
    {
        public static void Compose(Action<TickType?, IEngine> addEngine, CubeFactory factory, CubeConfig config, ITime time, IEntityFunctions functions)
        {
            CubeStartupEngine cubeStartupEngine = new(factory, config);

            UpdateSineWaveEngine updateSineWaveEngine = new(time);
            UpdateDirectionSineWaveEngine updateDirectionSineWaveEngine = new();

            CubeMoveEngine cubeMoveEngine = new(time);
            FaceRotationTowardsMoveDirectionEngine faceRotationTowardsMoveDirectionEngine = new();

            CubeCalculateDistanceTraveledEngine calculateDistanceTraveledEngine = new();
            DestroyCubesOnDistanceTraveled destroyCubesOnDistanceTraveled = new(functions);

            TickReviveTimerEngine tickReviveTimerEngine = new(time);
            ReviveCubeEngine reviveCubeEngine = new(functions);

            addEngine(STARTUP, cubeStartupEngine);

            addEngine(TICK, updateSineWaveEngine);
            addEngine(TICK, updateDirectionSineWaveEngine);

            addEngine(TICK, cubeMoveEngine);
            addEngine(TICK, faceRotationTowardsMoveDirectionEngine);

            addEngine(TICK, calculateDistanceTraveledEngine);
            addEngine(TICK, destroyCubesOnDistanceTraveled);

            addEngine(TICK, tickReviveTimerEngine);
            addEngine(TICK, reviveCubeEngine);
        }
    }
}