using Code.CubeLayer.Entities.Components;
using Code.UtilityLayer;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Movement.SineWave
{
    public class UpdateDirectionSineWaveEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
        }

        public EntitiesDB entitiesDB { get; set; }

        private EntitiesDB.SveltoFilters _filters;
        private ITime _time;
        public string name => GetType().Name;

        public UpdateDirectionSineWaveEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            //TODO: Ugly. Make it better
            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct group) in _filters.GetPersistentFilter<SineWaveData>(CubeFilters.SineMovableCubes))
            {
                (var directions, int _) = entitiesDB.QueryEntities<MoveDirection>(group);
                (var sineWaves, int _) = entitiesDB.QueryEntities<SineWaveData>(group);

                for (int i = 0; i < indices.count; ++i)
                {
                    uint filteredIndex = indices[i];

                    SineWaveData sineWave = sineWaves[filteredIndex];
                    ref MoveDirection moveDirection = ref directions[filteredIndex];
                    moveDirection.Value += Vector3.Cross(moveDirection.Value, sineWave.Axis) * (sineWave.Value * _time.DeltaTime);
                    moveDirection.Value.Normalize();
                }
            }
        }
    }
}