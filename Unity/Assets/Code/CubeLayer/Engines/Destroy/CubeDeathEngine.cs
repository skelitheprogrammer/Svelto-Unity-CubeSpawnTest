using Code.CubeLayer.Entities;
using Code.DestroyableLayer.Infrastructure;
using Svelto.ECS;
using Svelto.ECS.Internal;

namespace Code.CubeLayer.Engines.Destroy
{
    public abstract class CubeDeathEngine<T> : IQueryingEntitiesEngine, IStepEngine where T : struct, _IInternalEntityComponent
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
            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct exclusiveGroupStruct) in _filters.GetTransientFilter<T>(DestroyableFilterIds.DeadEntities))
            {
                for (int i = 0; i < indices.count; i++)
                {
                    _functions.SwapEntityGroup<CubeEntityDescriptor>(indices[i], exclusiveGroupStruct, DeadCubes.BuildGroup);
                }
            }
        }

        public abstract string name { get; }
    }
}