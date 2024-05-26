using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.DistanceTravel
{
    [Sequenced(nameof(CubeEngineNames.KILL_CUBE_TIMER))]
    public class CubeTimerDeathEngine : CubeDeathEngine<Timer<Dead>>
    {
        public CubeTimerDeathEngine(IEntityFunctions functions) : base(functions)
        {
        }

        public override string name => nameof(CubeEngineNames.KILL_CUBE_TIMER);
    }
}