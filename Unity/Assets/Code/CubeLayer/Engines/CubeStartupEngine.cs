using System;
using Code.CubeLayer.Services;
using Code.UtilityLayer.DataSources.CubeConfig;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    public class CubeStartupEngine : IQueryingEntitiesEngine
    {
        private readonly CubeFactory _factory;
        private readonly CubeConfig _config;

        public string name => GetType().Name;

        public CubeStartupEngine(CubeFactory factory, CubeConfig config)
        {
            _factory = factory;
            _config = config;
        }
        
        public void Ready()
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

        public EntitiesDB entitiesDB { get; set; }
    }
}