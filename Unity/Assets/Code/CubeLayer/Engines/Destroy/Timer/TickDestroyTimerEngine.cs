using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Engines;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Destroy.Timer
{
    public class TickDestroyTimerEngine : TimerTickEngine<Dead>
    {
        public TickDestroyTimerEngine(ITime time)
        {
            _time = time;
        }
        
        protected override FasterReadOnlyList<ExclusiveGroupStruct> Groups { get; } = Alive.Groups;
        protected override float DeltaTime() => _time.DeltaTime;

        private ITime _time;
    }
}