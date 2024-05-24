using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.DestroyableLayer.Infrastructure;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.KILL_CUBE))]
    public class CubeDeathEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
        }

        public EntitiesDB entitiesDB { get; set; }
        private readonly IEntityFunctions _functions;
        private EntitiesDB.SveltoFilters _filters;

        public CubeDeathEngine(IEntityFunctions functions)
        {
            _functions = functions;
        }

        public void Step()
        {
            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct exclusiveGroupStruct) in _filters.GetTransientFilter<DestroyDistance>(DestroyableFilterIds.DeadEntities))
            {
                for (int i = 0; i < indices.count; i++)
                {
                    _functions.SwapEntityGroup<CubeEntityDescriptor>(indices[i], exclusiveGroupStruct, DestroyedCubes.BuildGroup);
                }
            }
        }

        public string name => nameof(CubeEngineNames.KILL_CUBE);
    }
}