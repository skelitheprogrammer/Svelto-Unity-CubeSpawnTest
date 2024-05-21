using Code.CubeLayer.Entities;
using Code.CubeLayer.Entities.Components;
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

        public void Step()
        {
            foreach (((var directions, var sineWaves, int count), var group) in entitiesDB.QueryEntities<MoveDirection, SineWaveData>(SineWaveCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    directions[i].Value = Vector3.Cross(directions[i].Value, sineWaves[i].Axis).normalized * sineWaves[i].Value;
                }
            }
        }

        public string name => nameof(CubeEngineNames.UPDATE_DIRECTION_SINE_WAVE);
    }
}