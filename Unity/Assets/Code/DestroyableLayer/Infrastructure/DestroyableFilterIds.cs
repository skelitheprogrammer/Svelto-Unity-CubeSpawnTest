using Svelto.ECS;

namespace Code.DestroyableLayer.Infrastructure
{
    public static class DestroyableFilterIds
    {
        private static readonly FilterContextID CONTEXT_ID = FilterContextID.GetNewContextID();

        public static CombinedFilterID AliveEntities = new(0, CONTEXT_ID);
        public static CombinedFilterID DeadEntities = new(1, CONTEXT_ID);
    }
}