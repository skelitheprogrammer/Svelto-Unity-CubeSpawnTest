using Svelto.Common;

namespace Code.CubeLayer.Infrastructure
{
    public class DemoEngineOrder : ISequenceOrder
    {
        public string[] enginesOrder => new[]
        {
            nameof(CubeEngineNames.MOVE_CUBE_ENGINE)
        };
    }
}