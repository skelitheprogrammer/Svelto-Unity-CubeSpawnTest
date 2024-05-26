using Code.CubeLayer.Entities;
using Code.DestroyableLayer.Infrastructure;
using Svelto.ECS;
using Svelto.ECS.Internal;

namespace Code.CubeLayer.Engines.Revive
{
    public abstract class CubeReviveEngine<T> : IQueryingEntitiesEngine, IStepEngine where T : struct, _IInternalEntityComponent
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
        }

        public EntitiesDB entitiesDB { get; set; }
        private readonly IEntityFunctions _functions;
        private EntitiesDB.SveltoFilters _filters;

        public string name => GetType().Name;

        public CubeReviveEngine(IEntityFunctions functions)
        {
            _functions = functions;
        }

        public void Step()
        {
            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct exclusiveGroupStruct) in _filters.GetTransientFilter<T>(DestroyableFilterIds.AliveEntities))
            {
                for (int i = 0; i < indices.count; i++)
                {
                    _functions.SwapEntityGroup<CubeEntityDescriptor>(indices[i], exclusiveGroupStruct, AliveCubes.BuildGroup);
                }
            }
        }
    }
}