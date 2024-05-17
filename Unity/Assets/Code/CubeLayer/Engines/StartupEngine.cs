using Code.UtilityLayer.DataSources;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    public class StartupEngine : IStepEngine
    {
        private readonly CubeFactory _factory;
        private readonly CubeConfig _config;

        public StartupEngine(CubeFactory factory, CubeConfig config)
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

        public string name { get; set; }
    }
}