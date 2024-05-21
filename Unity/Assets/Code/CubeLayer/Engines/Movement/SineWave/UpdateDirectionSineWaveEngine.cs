using Code.CubeLayer.Entities;
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
        }

        public EntitiesDB entitiesDB { get; set; }
        private ITime _time;

        public UpdateDirectionSineWaveEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            foreach (((var directions, var sineWaves, int count), _) in entitiesDB.QueryEntities<MoveDirection, SineWaveData>(SineWaveDirectionMovementCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    SineWaveData sineWave = sineWaves[i];
                    directions[i].Value += Vector3.Cross(directions[i].Value, sineWave.Axis) * (sineWave.Value * _time.DeltaTime);
                    directions[i].Value.Normalize();
                }
            }
        }

        public string name => nameof(CubeEngineNames.UPDATE_DIRECTION_SINE_WAVE);
    }
}