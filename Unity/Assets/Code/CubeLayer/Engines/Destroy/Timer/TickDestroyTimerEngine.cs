using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Components;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Destroy.Timer
{
    [Sequenced(nameof(CubeEngineNames.DESTROY_TIMER_TICK))]
    public class TickDestroyTimerEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }

        private ITime _time;

        public TickDestroyTimerEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            foreach (((var timers, int count), ExclusiveGroupStruct _) in entitiesDB.QueryEntities<Timer<Dead>>(Alive.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    timers[i].Value -= _time.DeltaTime;
                    Debug.Log($"Time to destroy {timers[i].Value}");
                }
            }
        }

        public string name => nameof(CubeEngineNames.DESTROY_TIMER_TICK);
    }
}