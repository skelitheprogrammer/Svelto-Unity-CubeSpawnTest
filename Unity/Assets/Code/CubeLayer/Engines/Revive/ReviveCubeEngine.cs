using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Svelto.Common;
using Svelto.ECS;
using Svelto.ECS.Internal;

namespace Code.CubeLayer.Engines.Revive
{
    [Sequenced(nameof(CubeEngineNames.REVIVE))]
    public class ReviveCubeEngine : IQueryingEntitiesEngine, IStepEngine, IReactOnSwapEx<ReviveTimer>
    {
        public ReviveCubeEngine(IEntityFunctions functions)
        {
            _functions = functions;
        }

        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }
        private IEntityFunctions _functions;

        public void Step()
        {
            foreach (((var timers, NativeEntityIDs entityIDs, int count), ExclusiveGroupStruct exclusiveGroupStruct) in entitiesDB.QueryEntities<ReviveTimer>(DestroyedCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    if (timers[i].Value <= 0)
                    {
                        EGID egid = new(entityIDs[i], exclusiveGroupStruct);
                        _functions.SwapEntityGroup<CubeEntityDescriptor>(egid, AliveCubes.BuildGroup);
                    }
                }
            }
        }

        public string name => nameof(CubeEngineNames.REVIVE);

        public void MovedTo((uint start, uint end) rangeOfEntities, in EntityCollection<ReviveTimer> entities, ExclusiveGroupStruct fromGroup, ExclusiveGroupStruct toGroup)
        {
            var (buffer, _, _) = entities;

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                if (AliveCubes.Includes(toGroup))
                {
                    ref ReviveTimer reviveTimer = ref buffer[i];
                    reviveTimer.Value = reviveTimer.Timer;
                }
            }
        }
    }
}