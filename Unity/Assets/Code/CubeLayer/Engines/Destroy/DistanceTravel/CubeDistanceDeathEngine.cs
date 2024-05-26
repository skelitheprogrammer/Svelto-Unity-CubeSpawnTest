using Code.CubeLayer.Entities.Components;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines.Destroy.DistanceTravel
{
    public class CubeDistanceDeathEngine : CubeDeathEngine<DestroyDistance>
    {
        public CubeDistanceDeathEngine(IEntityFunctions functions) : base(functions)
        {
        }
    }
}