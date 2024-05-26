using Code.CubeLayer.Entities;
using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Components;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Revive.Timer
{
    [Sequenced(nameof(CubeEngineNames.REVIVE_TIMER_TICK))]
    public class TickReviveTimerEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }
        private ITime _time;

        public TickReviveTimerEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            foreach (((var timers, int count), _) in entitiesDB.QueryEntities<Timer<Alive>>(DeadCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    timers[i].Value -= _time.DeltaTime;
                    Debug.Log($"Time to revive {timers[i].Value}");
                }
            }
        }

        public string name => nameof(CubeEngineNames.REVIVE_TIMER_TICK);
    }
}