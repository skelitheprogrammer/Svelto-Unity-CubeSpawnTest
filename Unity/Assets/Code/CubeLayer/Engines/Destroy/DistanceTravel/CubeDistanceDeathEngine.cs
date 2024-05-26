using Code.CubeLayer.Entities.Components;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Destroy.DistanceTravel
{
    [Sequenced(nameof(CubeEngineNames.KILL_CUBE_DISTANCE))]
    public class CubeDistanceDeathEngine : CubeDeathEngine<DestroyDistance>
    {
        public CubeDistanceDeathEngine(IEntityFunctions functions) : base(functions)
        {
        }

        public override string name => nameof(CubeEngineNames.KILL_CUBE_DISTANCE);
    }
}