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

            nameof(CubeEngineNames.DESTROY_TIMER_TICK),
            nameof(CubeEngineNames.ADD_TO_DESTROY_TIMER_EXPIRED),
            nameof(CubeEngineNames.DESTROY_ON_TIMER_EXPIRED),

            nameof(CubeEngineNames.KILL_CUBE_DISTANCE),
            nameof(CubeEngineNames.KILL_CUBE_TIMER),

            nameof(CubeEngineNames.REVIVE_TIMER_TICK),
            nameof(CubeEngineNames.ADD_TO_REVIVE_TIMER_EXPIRED),
            nameof(CubeEngineNames.REVIVE_ON_TIMER_EXPIRED),
            nameof(CubeEngineNames.REVIVE_CUBE_TIMER),

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