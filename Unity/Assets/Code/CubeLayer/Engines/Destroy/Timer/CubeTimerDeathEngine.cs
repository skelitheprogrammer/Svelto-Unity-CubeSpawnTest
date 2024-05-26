using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Components;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Destroy.Timer
{
    public class CubeTimerDeathEngine : CubeDeathEngine<Timer<Dead>>
    {
        public CubeTimerDeathEngine(IEntityFunctions functions) : base(functions)
        {
        }
    }
}