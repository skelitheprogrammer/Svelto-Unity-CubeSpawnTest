using Code.CubeLayer.Engines;
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
            nameof(CubeEngineNames.UPDATE_SINE_WAVE),
            nameof(CubeEngineNames.UPDATE_DIRECTION_SINE_WAVE),

            nameof(CubeEngineNames.MOVE),
            nameof(CubeEngineNames.FACE_DIRECTION),

            nameof(CubeEngineNames.CALCULATE_DISTANCE),
            nameof(CubeEngineNames.DESTROY_ON_DISTANCE),

            nameof(CubeEngineNames.KILL_CUBE),

            // nameof(CubeEngineNames.REVIVE_TICK),
            // nameof(CubeEngineNames.REVIVE),

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