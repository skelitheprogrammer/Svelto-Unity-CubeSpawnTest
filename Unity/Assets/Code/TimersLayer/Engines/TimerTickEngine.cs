using Code.TimersLayer.Components;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.TimersLayer.Engines
{
    public abstract class TimerTickEngine<TTimerTag> : IQueryingEntitiesEngine, IStepEngine
    {
        public EntitiesDB entitiesDB { get; set; }
        public abstract string name { get; }

        protected abstract FasterReadOnlyList<ExclusiveGroupStruct> Groups { get; }

        public void Ready()
        {
        }

        protected abstract float DeltaTime();

        public virtual void Step()
        {
            foreach (var ((timers, count), _) in entitiesDB.QueryEntities<Timer<TTimerTag>>(Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    timers[i].Value -= DeltaTime();
                }
            }
        }
    }
}