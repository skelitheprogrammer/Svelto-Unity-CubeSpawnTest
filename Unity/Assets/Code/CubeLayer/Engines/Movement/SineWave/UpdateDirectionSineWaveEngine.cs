using Code.CubeLayer.Entities.Components;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Movement.SineWave
{
    [Sequenced(nameof(CubeEngineNames.UPDATE_DIRECTION_SINE_WAVE))]
    public class UpdateDirectionSineWaveEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
        }

        public EntitiesDB entitiesDB { get; set; }

        private EntitiesDB.SveltoFilters _filters;
        private ITime _time;

        public UpdateDirectionSineWaveEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            foreach ((EntityFilterIndices indices, ExclusiveGroupStruct group) in _filters.GetPersistentFilter<SineWaveData>(CubeFilters.SineMovableCubes))
            {
                (var directions, var sineWaves, int _) = entitiesDB.QueryEntities<MoveDirection, SineWaveData>(group);

                for (int i = 0; i < indices.count; i++)
                {
                    SineWaveData sineWave = sineWaves[indices[i]];
                    ref MoveDirection moveDirection = ref directions[indices[i]];
                    moveDirection.Value += Vector3.Cross(moveDirection.Value, sineWave.Axis) * (sineWave.Value * _time.DeltaTime);
                    moveDirection.Value.Normalize();
                }
            }
        }

        public string name => nameof(CubeEngineNames.UPDATE_DIRECTION_SINE_WAVE);
    }
}