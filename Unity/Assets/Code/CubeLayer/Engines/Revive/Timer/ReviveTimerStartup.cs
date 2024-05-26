using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Engines;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Revive.Timer
{
    [Sequenced(nameof(CubeEngineNames.REVIVE_TIMER_STARTUP))]
    public class ReviveTimerStartup : TimersStartupEngine<Alive>
    {
        protected override bool MovedToConditionGroup(in ExclusiveGroupStruct groupStruct) => Dead.Includes(groupStruct);
    }


    [Sequenced(nameof(CubeEngineNames.ADD_TO_REVIVE_TIMER_EXPIRED))]
    public class ReviveTimerAddToExpired : AddToExpiredTimerEngine<Alive>
    {
        protected override bool GroupIncludeCondition(in ExclusiveGroupStruct exclusiveGroupStruct) => Dead.Includes(exclusiveGroupStruct);

        public override string name => nameof(CubeEngineNames.ADD_TO_REVIVE_TIMER_EXPIRED);
    }
}