using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Components;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Revive.Timer
{
    public class CubeTimerReviveEngine : CubeReviveEngine<Timer<Alive>>
    {
        public CubeTimerReviveEngine(IEntityFunctions functions) : base(functions)
        {
        }
        
    }
}