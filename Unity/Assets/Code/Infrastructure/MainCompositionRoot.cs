using System.Collections.Generic;
using Code.CubeLayer;
using Code.CubeLayer.Services;
using Code.EngineViewSyncLayer.Infrastructure;
using Code.EngineViewSyncLayer.Objects;
using Code.Ticking;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources.CubeConfig;
using Code.UtilityLayer.PlayerLoop;
using PlayerLoopExtender;
using Svelto.Context;
using Svelto.DataStructures;
using Svelto.DataStructures.Experimental;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Code.Infrastructure
{
    public enum TickType
    {
        STARTUP,
        TICK
    }

    public class MainCompositionRoot : ICompositionRoot
    {
        private EnginesRoot _engineRoot;
        private bool _initialized;
        
        public void OnContextCreated<T>(T contextHolder)
        {
        }

        public void OnContextInitialized<T>(T contextHolder)
        {
            CompositionRoot(contextHolder as MainContext);
        }

        public void OnContextDestroyed(bool hasBeenInitialised)
        {
            _engineRoot.Dispose();
        }

        private void CompositionRoot(MainContext contextHolder)
        {
            #region Svelto Core

            EntitiesSubmissionScheduler entityScheduler = new();
            _engineRoot = new(entityScheduler);
            IEntityFunctions functions = _engineRoot.GenerateEntityFunctions();
            IEntityFactory entityFactory = _engineRoot.GenerateEntityFactory();

            #endregion

            CubeConfig cubeConfig = contextHolder.ConfigSO.Config;

            ViewHandlerResourceManager<GameObject> gameObjectViewHandlerManager = new();
            EntityInstanceManager<GameObject> entityInstanceManager = new(gameObjectViewHandlerManager);
            GameObjectFactory gameObjectFactory = new(gameObjectViewHandlerManager);

            ITime time = new UnityTime();

            #region CubeDependencies

            ValueIndex cubeResourceIndex = gameObjectViewHandlerManager.Add(cubeConfig.Prefab);

            CubeFactory factory = new(entityFactory, cubeResourceIndex);
            GameObjectPool gameObjectPool = new(cubeResourceIndex, gameObjectFactory);
            CubeViewHandler cubeViewHandler = new(gameObjectPool);

            gameObjectViewHandlerManager.RegisterHandler(cubeResourceIndex, cubeViewHandler);

            #endregion

            ComposeLayers(out FasterList<IStepEngine> startupEngines, out FasterList<IStepEngine> tickEngines);
            AttachPlayerLoop();

            void ComposeLayers(out FasterList<IStepEngine> startupEngines, out FasterList<IStepEngine> tickEngines)
            {
                Dictionary<TickType?, FasterList<IStepEngine>> map = new()
                {
                    {
                        TickType.STARTUP, startupEngines = new()
                    },
                    {
                        TickType.TICK, tickEngines = new()
                    }
                };
                
                CubeLayerComposer.Compose(AddEngine, factory, cubeConfig, time, functions);
                EngineSyncLayerComposer.Compose(AddEngine, entityInstanceManager);

                TickEngine tickEngine = new(entityScheduler);
                tickEngines.Add(tickEngine);
                _engineRoot.AddEngine(tickEngine);

                void AddEngine(TickType? type, IEngine engine)
                {
                    if (type is not null && engine is IStepEngine stepEngine)
                    {
                        map[type].Add(stepEngine);
                    }

                    _engineRoot.AddEngine(engine);
                }
            }

            void AttachPlayerLoop()
            {
                SortedStartupEnginesGroup startupEngineGroup = new(startupEngines);
                SortedTickEnginesGroup tickEngineGroup = new(tickEngines);

                PlayerLoopSystem sveltoInit = PlayerLoopHelper.SveltoInitialization.Create(StartupEngines);
                PlayerLoopSystem sveltoSimulate = PlayerLoopHelper.SveltoSimulationStep.Create(TickEngines);

                PlayerLoopSystem copyLoop = PlayerLoop.GetCurrentPlayerLoop();
                PlayerLoopSystem resetCopyLoop = copyLoop;

                //In order to reset Player Loop when user checked Edit/ProjectSettings/Editor: EnterPlayModeOptions
                //user have to use this callbacks
                Application.quitting -= Reset;
                Application.quitting += Reset;

                copyLoop.InsertSystem(sveltoInit, typeof(Initialization), PlayerLoopSystemExtensions.InsertType.AFTER);
                copyLoop.InsertSystem(sveltoSimulate, typeof(Update.ScriptRunBehaviourUpdate), PlayerLoopSystemExtensions.InsertType.BEFORE);

                PlayerLoop.SetPlayerLoop(copyLoop);

                void StartupEngines()
                {
                    lock (this)
                    {
                        if (_initialized)
                        {
                            return;
                        }

                        startupEngineGroup.Step();

                        _initialized = true;
                    }
                }

                void TickEngines()
                {
                    lock (this)
                    {
                        if (!_initialized)
                        {
                            return;
                        }

                        if (!_engineRoot.IsValid())
                        {
                            return;
                        }

                        tickEngineGroup.Step();
                    }
                }

                void Reset()
                {
                    PlayerLoop.SetPlayerLoop(resetCopyLoop);
                }
            }
        }
    }
}