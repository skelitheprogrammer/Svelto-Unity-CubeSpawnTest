using System;
using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Components;
using Code.TimersLayer.Engines;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Revive.Timer
{
    [Sequenced(nameof(CubeEngineNames.REVIVE_TIMER_STARTUP))]
    public class ReviveTimerStartup : TimersStartupEngine<Alive>
    {
        public override void MovedTo((uint start, uint end) rangeOfEntities, in EntityCollection<Timer<Alive>> entities, ExclusiveGroupStruct fromGroup, ExclusiveGroupStruct toGroup)
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


    [Sequenced(nameof(CubeEngineNames.ADD_TO_REVIVE_TIMER_EXPIRED))]
    public class ReviveTimerAddToExpired : AddToExpiredTimerEngine<Alive>
    {
        protected override Predicate<ExclusiveGroupStruct> ConditionGroup { get; } = Alive.Includes;
        public override string name => nameof(CubeEngineNames.ADD_TO_REVIVE_TIMER_EXPIRED);
    }
}