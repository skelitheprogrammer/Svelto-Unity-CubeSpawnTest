using Code.CubeLayer.Engines;
using Code.CubeLayer.Engines.Destroy.DistanceTravel;
using Code.CubeLayer.Engines.Destroy.Timer;
using Code.CubeLayer.Engines.Movement;
using Code.CubeLayer.Engines.Movement.SineWave;
using Code.CubeLayer.Engines.Revive.Timer;
using Code.CubeLayer.Services;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources.CubeConfig;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.CubeLayer
{
    public static class CubeLayerComposer
    {
        public static void Compose(EnginesRoot root, FasterList<IStepEngine> startup, FasterList<IStepEngine> tick, CubeFactory factory, CubeConfig config, ITime time, IEntityFunctions functions)
        {
            #region Initialization

            CubeStartupEngine cubeStartupEngine = new(factory, config);
            DestroyTimerStartup destroyTimerStartup = new();
            ReviveTimerStartup reviveTimerStartup = new();

            AddCubesToSineMoveFilter addCubesToSineMoveFilter = new();

            UpdateSineWaveEngine updateSineWaveEngine = new(time);
            UpdateDirectionSineWaveEngine updateDirectionSineWaveEngine = new(time);

            CubeMoveEngine cubeMoveEngine = new(time);
            FaceRotationTowardsMoveDirectionEngine faceRotationTowardsMoveDirectionEngine = new();

            CubeCalculateDistanceTraveledEngine calculateDistanceTraveledEngine = new();
            DestroyCubeOnDistanceTraveled destroyCubeOnDistanceTraveled = new();

            TickDestroyTimerEngine tickDestroyTimerEngine = new(time);
            DestroyCubeAddToExpiredFilterTimerEngine destroyCubeAddToExpiredFilterTimerEngine = new();
            DestroyCubeAddToDestroyFilterEngine destroyCubeAddToDestroyFilterEngine = new();

            TickReviveTimerEngine tickReviveTimerEngine = new(time);
            ReviveCubeAddToExpiredTimerFilterEngine reviveCubeAddToExpiredTimerFilterEngine = new();
            CubeTimerReviveEngine cubeReviveEngine = new(functions);
            ReviveCubeAddToAliveFilterEngine reviveCubeAddToAliveFilterEngine = new();

            CubeTimerDeathEngine cubeTimerDeathEngine = new(functions);
            CubeDistanceDeathEngine cubeDistanceDeathEngine = new(functions);

            #endregion

            FasterList<IStepEngine> movementGroup = new(
                updateSineWaveEngine,
                updateDirectionSineWaveEngine,
                cubeMoveEngine,
                faceRotationTowardsMoveDirectionEngine
            );

            FasterList<IStepEngine> destroyTimerGroup = new(
                tickDestroyTimerEngine,
                destroyCubeAddToExpiredFilterTimerEngine,
                destroyCubeAddToDestroyFilterEngine,
                cubeTimerDeathEngine
            );

            FasterList<IStepEngine> destroyDistanceReachGroup = new(
                calculateDistanceTraveledEngine,
                destroyCubeOnDistanceTraveled,
                cubeDistanceDeathEngine
            );

            FasterList<IStepEngine> reviveTimerGroup = new(
                tickReviveTimerEngine,
                reviveCubeAddToExpiredTimerFilterEngine,
                reviveCubeAddToAliveFilterEngine,
                cubeReviveEngine
            );

            FasterList<IStepEngine> startupGroup = new();
            startupGroup.Add(cubeStartupEngine);

            CubeLayerStartupGroup cubeStartupGroups = new(startupGroup);

            FasterList<IStepEngine> tickGroups = new();
            tickGroups.AddRange(movementGroup);
            tickGroups.AddRange(destroyTimerGroup);
            tickGroups.AddRange(destroyDistanceReachGroup);
            tickGroups.AddRange(reviveTimerGroup);

            CubeLayerUnsortedTickEngineGroup cubeTickGroups = new(tickGroups);

            root.AddEngine(addCubesToSineMoveFilter);
            root.AddEngine(destroyTimerStartup);
            root.AddEngine(reviveTimerStartup);

            startup.Add(cubeStartupGroups);
            root.AddEngine(cubeStartupEngine);

            tick.Add(cubeTickGroups);
            root.AddEngine(cubeTickGroups);
        }
    }
}