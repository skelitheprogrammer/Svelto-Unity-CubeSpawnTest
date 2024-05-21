using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.ECS;
using UnityEngine;

namespace Code.CubeLayer.Engines.Movement.SineWave
{
    [Sequenced(nameof(CubeEngineNames.UPDATE_SINE_WAVE))]
    public class UpdateSineWaveEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }
        private ITime _time;

        public UpdateSineWaveEngine(ITime time)
        {
            _time = time;
        }

        public void Step()
        {
            foreach (((var sineWaves, int count), _) in entitiesDB.QueryEntities<SineWaveData>(SineWaveCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref SineWaveData sineWave = ref sineWaves[i];

                    sineWave.Value = Mathf.Sin(_time.Time * sineWave.Frequency) * sineWave.Amplitude;
                    
                }
            }
        }

        public string name => nameof(CubeEngineNames.UPDATE_SINE_WAVE);
    }
}