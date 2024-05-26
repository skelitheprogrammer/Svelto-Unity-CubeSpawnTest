using Svelto.ECS;

namespace Code.TimersLayer
{
    public static class TimerFilters
    {
        private static readonly FilterContextID TIMERS_CONTEXT = new();

        public static CombinedFilterID ExpiredTimer = new(0, TIMERS_CONTEXT);
    }
}