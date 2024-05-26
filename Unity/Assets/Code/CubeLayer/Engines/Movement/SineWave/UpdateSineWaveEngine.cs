using Code.CubeLayer.Entities.Components;
using Code.UtilityLayer;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Movement.SineWave
{
    public class UpdateSineWaveEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
        }

        public EntitiesDB entitiesDB { get; set; }
        private ITime _time;
        private EntitiesDB.SveltoFilters _filters;

        public string name => GetType().Name;

        public UpdateSineWaveEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct exclusiveGroupStruct) in _filters.GetPersistentFilter<SineWaveData>(CubeFilters.SineMovableCubes))
            {
                (var sineWaves, int _) = entitiesDB.QueryEntities<SineWaveData>(exclusiveGroupStruct);

                for (int i = 0; i < indices.count; i++)
                {
                    ref SineWaveData sineWave = ref sineWaves[indices[i]];

                    sineWave.Value = Mathf.Sin(_time.Time * sineWave.Frequency) * sineWave.Amplitude;
                }
            }
        }
    }
}