using Code.Common.DataConfigSystem;
using Code.CubeLayer.Entities;
using Code.CubeLayer.Services;
using Code.UtilityLayer.DataSources;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.STARTUP))]
    public class CubeStartupEngine : IStepEngine
    {
        private readonly CubeFactory _factory;
        private readonly CubeConfig _config;

        public CubeStartupEngine(CubeFactory factory, CubeConfig config)
        {
            _factory = factory;
            _config = config;
        }

        public void Step()
        {
            foreach (CubeSettings configSetting in _config.Settings)
            {
                for (int i = 0; i < configSetting.Count.Reference; i++)
                {
                    _factory.Create(configSetting, StraightLineCubes.BuildGroup);
                }
            }

            /*for (int i = 0; i < _config.Count; i++)
            {
                _factory.Create(_config, StraightLineCubes.BuildGroup);
            }

            for (int i = 0; i < _config.Count; i++)
            {
                _factory.Create(_config, SineWaveDirectionMovementCubes.BuildGroup);
            }    */
            /*for (int i = 0; i < _config.Count; i++)
            {
                _factory.Create(_config, SineWavePositionMovementCubes.BuildGroup);
            }*/

            /*
            for (int i = 0; i < _config.WithDistanceCount; i++)
            {
                _factory.CreateDistanceTraveled(_config);
            }
            */

            /*for (int i = 0; i < _config.WithDistanceCount; i++)
            {
                _factory.CreateRevivable(_config);
            }*/
        }

        public string name => nameof(CubeEngineNames.STARTUP);
    }
}