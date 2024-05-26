using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Engines;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Destroy.Timer
{
    [Sequenced(nameof(CubeEngineNames.DESTROY_TIMER_STARTUP))]
    public class DestroyTimerStartup : TimersStartupEngine<Dead>
    {
        protected override bool MovedToConditionGroup(in ExclusiveGroupStruct groupStruct) => Alive.Includes(groupStruct);
    }


    [Sequenced(nameof(CubeEngineNames.ADD_TO_DESTROY_TIMER_EXPIRED))]
    public class DestroyTimerAddToExpired : AddToExpiredTimerEngine<Dead>
    {
        protected override bool GroupIncludeCondition(in ExclusiveGroupStruct exclusiveGroupStruct) => Alive.Includes(exclusiveGroupStruct);

        public override string name => nameof(CubeEngineNames.ADD_TO_DESTROY_TIMER_EXPIRED);
    }
}