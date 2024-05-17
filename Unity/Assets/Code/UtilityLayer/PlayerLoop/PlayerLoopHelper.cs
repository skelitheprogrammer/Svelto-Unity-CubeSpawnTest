using UnityEngine.LowLevel;

namespace Code.UtilityLayer.PlayerLoop
{
    public static class PlayerLoopHelper
    {
        public struct SveltoInitialization
        {
            public static PlayerLoopSystem Create(PlayerLoopSystem.UpdateFunction updateFunction) => new()
            {
                type = typeof(SveltoInitialization),
                updateDelegate = updateFunction
            };
        }

        public struct SveltoSimulationStep
        {
            public static PlayerLoopSystem Create(PlayerLoopSystem.UpdateFunction updateFunction) => new()
            {
                type = typeof(SveltoSimulationStep),
                updateDelegate = updateFunction
            };
        }
    }
}