using Svelto.DataStructures.Experimental;
using Svelto.ECS;

namespace Code.EngineViewSyncLayer.Entities.Components
{
    public struct ViewReference : IEntityComponent
    {
        public ValueIndex ResourceId;
    }
}