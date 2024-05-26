using System;
using Code.CubeLayer.Engines;
using Code.CubeLayer.Engines.Destroy.DistanceTravel;
using Code.CubeLayer.Engines.Destroy.Timer;
using Code.CubeLayer.Engines.Movement;
using Code.CubeLayer.Engines.Movement.SineWave;
using Code.CubeLayer.Engines.Revive;
using Code.CubeLayer.Engines.Revive.Timer;
using Code.CubeLayer.Services;
using Code.Infrastructure;
using Code.TimersLayer;
using Code.TimersLayer.Engines;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources.CubeConfig;
using Svelto.ECS;
using static Code.Infrastructure.TickType;

namespace Code.CubeLayer
{
    public static class CubeLayerComposer
    {
        public static void Compose(Action<TickType?, IEngine> addEngine, CubeFactory factory, CubeConfig config, ITime time, IEntityFunctions functions)
        {
            CubeStartupEngine cubeStartupEngine = new(factory, config);
            DestroyTimerStartup destroyTimerStartup = new();
            ReviveTimerStartup reviveTimerStartup = new();

            AddCubesToSineMoveFilter addCubesToSineMoveFilter = new();

            UpdateSineWaveEngine updateSineWaveEngine = new(time);
            UpdateDirectionSineWaveEngine updateDirectionSineWaveEngine = new(time);

            CubeMoveEngine cubeMoveEngine = new(time);
            FaceRotationTowardsMoveDirectionEngine faceRotationTowardsMoveDirectionEngine = new();

            CubeCalculateDistanceTraveledEngine calculateDistanceTraveledEngine = new();
            DestroyCubesOnDistanceTraveled destroyCubesOnDistanceTraveled = new();

            TickDestroyTimerEngine tickDestroyTimerEngine = new(time);
            DestroyTimerAddToExpired destroyTimerAddToExpired = new();
            DestroyOnTimeExpiredEngine destroyOnTimeExpiredEngine = new();


            TickReviveTimerEngine tickReviveTimerEngine = new(time);
            ReviveTimerAddToExpired reviveTimerAddToExpired = new();
            CubeTimerReviveEngine cubeReviveEngine = new(functions);
            ReviveOnTimerExpiredEngine reviveOnTimerExpiredEngine =new();

            CubeTimerDeathEngine cubeTimerDeathEngine = new(functions);
            CubeDistanceDeathEngine cubeDistanceDeathEngine = new(functions);

            addEngine(null, addCubesToSineMoveFilter);

            addEngine(STARTUP, cubeStartupEngine);
            addEngine(null, destroyTimerStartup);
            addEngine(null, reviveTimerStartup);

            addEngine(TICK, updateSineWaveEngine);
            addEngine(TICK, updateDirectionSineWaveEngine);

            addEngine(TICK, cubeMoveEngine);
            addEngine(TICK, faceRotationTowardsMoveDirectionEngine);

            addEngine(TICK, tickDestroyTimerEngine);
            addEngine(TICK, destroyTimerAddToExpired);

            addEngine(TICK, destroyOnTimeExpiredEngine);

            addEngine(TICK, calculateDistanceTraveledEngine);
            addEngine(TICK, destroyCubesOnDistanceTraveled);

            addEngine(TICK, cubeTimerDeathEngine);
            addEngine(TICK, cubeDistanceDeathEngine);

            addEngine(TICK, tickReviveTimerEngine);
            addEngine(TICK, reviveTimerAddToExpired);
            addEngine(TICK, cubeReviveEngine);
            addEngine(TICK, reviveOnTimerExpiredEngine);
        }
    }
}