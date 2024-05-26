using Code.CubeLayer.Entities;
using Code.DestroyableLayer.Infrastructure;
using Svelto.ECS;
using Svelto.ECS.Internal;

namespace Code.CubeLayer.Engines.Destroy
{
    public abstract class CubeDeathEngine<TComponent> : IQueryingEntitiesEngine, IStepEngine where TComponent : struct, _IInternalEntityComponent
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
        }

        public EntitiesDB entitiesDB { get; set; }
        private readonly IEntityFunctions _functions;
        private EntitiesDB.SveltoFilters _filters;

        public string name => GetType().Name;

        public CubeDeathEngine(IEntityFunctions functions)
        {
            _functions = functions;
        }

        public void Step()
        {
            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct exclusiveGroupStruct) in _filters.GetTransientFilter<TComponent>(DestroyableFilterIds.DeadEntities))
            {
                for (int i = 0; i < indices.count; i++)
                {
                    _functions.SwapEntityGroup<CubeEntityDescriptor>(indices[i], exclusiveGroupStruct, DeadCubes.BuildGroup);
                }
            }
        }
    }
}