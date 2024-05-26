using Code.CubeLayer;
using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.EngineViewSyncLayer.Infrastructure
{
    [Sequenced(nameof(SyncEngineNames.SYNC_UNSORTED))]
    public class SyncLayerUnsortedTickGroup : UnsortedEnginesGroup<IStepEngine>
    {
        public SyncLayerUnsortedTickGroup(FasterList<IStepEngine> engines) : base(engines)
        {
        }
    }
}