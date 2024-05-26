using Code.CubeLayer.Entities;
using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Engines;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Revive.Timer
{
    [Sequenced(nameof(CubeEngineNames.REVIVE_TIMER_TICK))]
    public class TickReviveTimerEngine : TimerTickEngine<Alive>
    {
        public override string name => nameof(CubeEngineNames.REVIVE_TIMER_TICK);
        protected override FasterReadOnlyList<ExclusiveGroupStruct> Groups { get; } = DeadCubes.Groups;

        public TickReviveTimerEngine(ITime time)
        {
            _time = time;
        }

        private ITime _time;
        protected override float DeltaTime() => _time.DeltaTime;
    }
}