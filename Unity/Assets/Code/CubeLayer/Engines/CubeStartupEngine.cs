using Code.UtilityLayer.DataSources;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
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

        public string name { get; set; }
    }

    public class DestroyableCubeStartup : IStepEngine
    {
        private readonly CubeFactory _factory;
        private readonly DestroyableCubeConfig _config;

        public DestroyableCubeStartup(CubeFactory factory, DestroyableCubeConfig config)
        {
            _factory = factory;
            _config = config;
        }

        public void Step()
        {
            for (int i = 0; i < _config.Default.Count; i++)
            {
                _factory.CreateDestroyable(_config);
            }
        }

        public string name { get; set; }
    }
}