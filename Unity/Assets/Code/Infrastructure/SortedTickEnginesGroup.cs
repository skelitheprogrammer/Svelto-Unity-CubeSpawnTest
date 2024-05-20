using Code.CubeLayer.Infrastructure;
using Code.EngineViewSyncLayer.Infrastructure;
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
            nameof(CubeEngineNames.CUBE_MOVE),
            nameof(CubeEngineNames.CUBE_FACE_DIRECTION),

            nameof(SyncEngineNames.SYNC_POSITION_ENGINE),
            nameof(SyncEngineNames.SYNC_ROTATION_ENGINE),
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