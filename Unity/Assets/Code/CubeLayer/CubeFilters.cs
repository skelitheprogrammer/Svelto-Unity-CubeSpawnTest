using Svelto.ECS;

namespace Code.CubeLayer
{
    public static class CubeFilters
    {
        private static readonly FilterContextID FILTER_CONTEXT_ID = new();

        public static CombinedFilterID SineMovableCubes = new(0, FILTER_CONTEXT_ID);
    }
}