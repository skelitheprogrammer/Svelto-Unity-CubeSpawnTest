using Code.CubeLayer.Entities.Components;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Movement.SineWave
{
    public class AddCubesToSineMoveFilter : IQueryingEntitiesEngine, IReactOnAddAndRemoveEx<SineWaveData>
    {
        public EntitiesDB entitiesDB { get; set; }
        private EntitiesDB.SveltoFilters _filters;

        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
            _filters.CreatePersistentFilter<SineWaveData>(CubeFilters.SineMovableCubes);
        }

        public void Add((uint start, uint end) rangeOfEntities, in EntityCollection<SineWaveData> entities, ExclusiveGroupStruct groupID)
        {
            var (_, entityIDs, _) = entities;

            var cachedFilter = _filters.GetPersistentFilter<SineWaveData>(CubeFilters.SineMovableCubes);

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                cachedFilter.Add(entityIDs[i], groupID, i);
            }
        }

        public void Remove((uint start, uint end) rangeOfEntities, in EntityCollection<SineWaveData> entities, ExclusiveGroupStruct groupID)
        {
            var (_, entityIDs, _) = entities;

            var cachedFilter = _filters.GetPersistentFilter<SineWaveData>(CubeFilters.SineMovableCubes);

            for (uint i = rangeOfEntities.start; i < rangeOfEntities.end; i++)
            {
                cachedFilter.Remove(entityIDs[i], groupID);
            }
        }
    }
}