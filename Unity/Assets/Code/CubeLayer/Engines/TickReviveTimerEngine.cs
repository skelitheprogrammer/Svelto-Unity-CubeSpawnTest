using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.REVIVE_TICK))]
    public class TickReviveTimerEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }
        private ITime _time;

        public TickReviveTimerEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            foreach (((var timers, int count), _) in entitiesDB.QueryEntities<ReviveTimer>(DestroyedCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    timers[i].Value -= _time.DeltaTime;
                }
            }
        }

        public string name => nameof(CubeEngineNames.REVIVE_TICK);
    }
}