using Code.CubeLayer;
using Code.EngineViewSyncLayer;
using Code.Ticking;
using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.Infrastructure
{
    public struct SortedTickEngineOrder : ISequenceOrder
    {
        private static readonly string[] ENGINES_ORDER =
        {
            nameof(CubeEngineNames.UNSORTED),

            nameof(SyncEngineNames.SYNC_UNSORTED),

            nameof(TickEngineNames.SUBMISSION_ENGINE),
        };

        public string[] enginesOrder => ENGINES_ORDER;
    }

    public class SortedTickEnginesGroup : SortedEnginesGroup<IStepEngine, SortedTickEngineOrder>
    {
        public SortedTickEnginesGroup(FasterList<IStepEngine> engines) : base(engines)
        {
        }
    }
}