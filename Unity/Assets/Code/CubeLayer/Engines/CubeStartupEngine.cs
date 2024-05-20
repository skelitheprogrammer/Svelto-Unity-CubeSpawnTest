using Code.CubeLayer.Infrastructure;
using Code.UtilityLayer.DataSources;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.CUBE_STARTUP))]
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
            for (int i = 0; i < _config.Count; i++)
            {
                _factory.Create(_config);
            }
        }

        public string name => nameof(CubeEngineNames.CUBE_STARTUP);
    }
}