using Code.UtilityLayer.DataSources.CubeConfig;
using Svelto.Context;

namespace Code.Infrastructure
{
    public class MainContext : UnityContext<MainCompositionRoot>
    {
        public CubeConfigSo ConfigSO;
    }
}