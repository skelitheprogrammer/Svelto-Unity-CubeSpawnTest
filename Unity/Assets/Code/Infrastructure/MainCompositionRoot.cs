using Code.CubeLayer;
using Code.CubeLayer.Engines;
using Code.CubeLayer.Infrastructure;
using Code.EngineViewSyncLayer.Infrastructure;
using Code.EngineViewSyncLayer.Objects;
using Code.Ticking;
using Code.UtilityLayer;
using Code.UtilityLayer.DataSources;
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
            EntitiesSubmissionScheduler entityScheduler = new();
            _engineRoot = new EnginesRoot(entityScheduler);
            IEntityFunctions functions = _engineRoot.GenerateEntityFunctions();
            IEntityFactory entityFactory = _engineRoot.GenerateEntityFactory();

            CubeConfig cubeConfig = contextHolder.ConfigSO.Config;
            DestroyableCubeConfig destroyableCubeConfig = contextHolder.ConfigSO.DestroyableCubeConfig;


            ViewHandlerResourceManager<GameObject> gameObjectViewHandlerManager = new();
            EntityInstanceManager<GameObject> entityInstanceManager = new(gameObjectViewHandlerManager);
            GameObjectFactory gameObjectFactory = new(gameObjectViewHandlerManager);

            ValueIndex cubeResourceIndex = gameObjectViewHandlerManager.Add(cubeConfig.Prefab);

            GameObjectPool gameObjectPool = new(cubeResourceIndex, gameObjectFactory);
            CubeViewHandler cubeViewHandler = new(gameObjectPool);

            gameObjectViewHandlerManager.RegisterHandler(cubeResourceIndex, cubeViewHandler);

            CubeFactory cubeFactory = new(entityFactory, cubeResourceIndex);
            ITime time = new UnityTime();

            FasterList<IStepEngine> orderedEngines = new();

            ComposeLayers();

            SortedEnginesGroup sortedEnginesGroup = new(orderedEngines);

            CubeStartupEngine cubeStartupEngine = new(cubeFactory, cubeConfig);
            DestroyableCubeStartup destroyableCubeStartup = new(cubeFactory, destroyableCubeConfig);

            AttachPlayerLoop(new IStepEngine[]
            {
                cubeStartupEngine,
                destroyableCubeStartup
            }, sortedEnginesGroup);

            void ComposeLayers()
            {
                CubeLayerComposer.Compose(_engineRoot, time, orderedEngines, functions);
                EngineSyncLayerComposer.Compose(_engineRoot, entityInstanceManager, orderedEngines);
                orderedEngines.Add(new TickEngine(entityScheduler));
            }
        }

        private void AttachPlayerLoop(IStepEngine[] startupEngines, SortedEnginesGroup sortedEnginesGroup)
        {
            PlayerLoopSystem sveltoInit = PlayerLoopHelper.SveltoInitialization.Create(() =>
            {
                lock (this)
                {
                    if (_initialized)
                    {
                        return;
                    }

                    foreach (IStepEngine startupEngine in startupEngines)
                    {
                        startupEngine.Step();
                    }

                    _initialized = true;
                }
            });

            PlayerLoopSystem sveltoSimulate = PlayerLoopHelper.SveltoSimulationStep.Create(StepEngines);

            PlayerLoopSystem copyLoop = PlayerLoop.GetCurrentPlayerLoop();
            PlayerLoopSystem resetCopyLoop = copyLoop;

            //In order to reset Player Loop when user checked Edit/ProjectSettings/Editor: EnterPlayModeOptions
            //user have to use this callbacks
            Application.quitting -= Reset;
            Application.quitting += Reset;

            copyLoop.InsertSystem(sveltoInit, typeof(Initialization), PlayerLoopSystemExtensions.InsertType.AFTER);
            copyLoop.InsertSystem(sveltoSimulate, typeof(Update.ScriptRunBehaviourUpdate), PlayerLoopSystemExtensions.InsertType.BEFORE);

            PlayerLoop.SetPlayerLoop(copyLoop);

            void StepEngines()
            {
                lock (this)
                {
                    if (_engineRoot.IsValid())
                    {
                        sortedEnginesGroup.Step();
                    }
                }
            }

            void Reset()
            {
                PlayerLoop.SetPlayerLoop(resetCopyLoop);
            }
        }
    }
}