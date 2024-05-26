using System;
using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Components;
using Code.TimersLayer.Engines;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Destroy.Timer
{
    [Sequenced(nameof(CubeEngineNames.DESTROY_TIMER_STARTUP))]
    public class DestroyTimerStartup : TimersStartupEngine<Dead>
    {
        public override void MovedTo((uint start, uint end) rangeOfEntities, in EntityCollection<Timer<Dead>> entities, ExclusiveGroupStruct fromGroup, ExclusiveGroupStruct toGroup)
        {
            if (Alive.Includes(toGroup))
            {
                (var timers, _) = entities;

                for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
                {
                    timers[i].Value = timers[i].StartValue;
                }
            }
        }
    }


    [Sequenced(nameof(CubeEngineNames.ADD_TO_DESTROY_TIMER_EXPIRED))]
    public class DestroyTimerAddToExpired : AddToExpiredTimerEngine<Dead>
    {
        protected override Predicate<ExclusiveGroupStruct> ConditionGroup { get; } = Dead.Includes;
        public override string name => nameof(CubeEngineNames.ADD_TO_DESTROY_TIMER_EXPIRED);
    }
}