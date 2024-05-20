using Code.CubeLayer.Infrastructure;
using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.Infrastructure
{
    public struct SortedStartupEngineOrder : ISequenceOrder
    {
        private static readonly string[] ENGINES_ORDER =
        {
            nameof(CubeEngineNames.CUBE_STARTUP),
        };

        public string[] enginesOrder => ENGINES_ORDER;
    }

    public class SortedStartupEnginesGroup : SortedEnginesGroup<IStepEngine, SortedStartupEngineOrder>
    {
        public SortedStartupEnginesGroup(FasterList<IStepEngine> engines) : base(engines)
        {
        }
    }
}