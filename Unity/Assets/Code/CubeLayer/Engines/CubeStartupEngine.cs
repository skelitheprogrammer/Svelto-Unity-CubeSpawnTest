using System;
using Code.CubeLayer.Services;
using Code.UtilityLayer.DataSources.CubeConfig;
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
            foreach (ICubeSettings cubeSettings in _config.CubeSettings)
            {
                CubeSettings settings = cubeSettings switch
                {
                    CubeSettings def => def,
                    CubeSettingsReference cubeSettingsReference => cubeSettingsReference,
                    _ => throw new ArgumentOutOfRangeException()
                };

                for (int i = 0; i < settings.Count.Reference; i++)
                {
                    _factory.Create(settings);
                }
            }
        }

        public string name => nameof(CubeEngineNames.STARTUP);
    }
}