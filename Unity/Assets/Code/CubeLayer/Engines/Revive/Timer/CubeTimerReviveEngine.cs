﻿using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Revive
{
    [Sequenced(nameof(CubeEngineNames.REVIVE_CUBE_TIMER))]
    public class CubeTimerReviveEngine : CubeReviveEngine<Timer<Alive>>
    {
        public CubeTimerReviveEngine(IEntityFunctions functions) : base(functions)
        {
        }

        public override string name => nameof(CubeEngineNames.REVIVE_CUBE_TIMER);
    }
}