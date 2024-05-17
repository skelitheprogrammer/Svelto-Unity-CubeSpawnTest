using Code.CubeLayer.Infrastructure;
using Code.EngineViewSyncLayer.Infrastructure;
using Code.Ticking;
using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.Infrastructure
{
    public class SortedEnginesGroup : SortedEnginesGroup<IStepEngine, SortedTickEngineOrder>
    {
        public SortedEnginesGroup(FasterList<IStepEngine> engines) : base(engines)
        {
        }
    }
    
    public struct SortedTickEngineOrder : ISequenceOrder
    {
        public string[] enginesOrder => new[]
        {
            nameof(CubeEngineNames.MOVE_CUBE_ENGINE),
            nameof(CubeEngineNames.FACE_DIRECTION_ENGINE),
            nameof(SyncEngineNames.SYNC_POSITION_ENGINE),
            nameof(SyncEngineNames.SYNC_ROTATION_ENGINE),
            nameof(TickEngineNames.SUBMISSION_ENGINE),
        };
    }


}