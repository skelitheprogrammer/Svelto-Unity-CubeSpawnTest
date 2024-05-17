using Svelto.DataStructures.Experimental;
using Svelto.ECS;

namespace Code.EngineViewSyncLayer.Components
{
    public struct ViewReference : IEntityComponent
    {
        public ValueIndex ResourceId;
    }
}