using Code.CubeLayer.Entities.Components;
using Code.EngineViewSyncLayer.Components;
using Svelto.ECS;

namespace Code.CubeLayer.Entities
{
    public class CubeEntityDescriptor : IEntityDescriptor
    {
        public IComponentBuilder[] componentsToBuild { get; } =
        {
            new ComponentBuilder<Position>(),
            new ComponentBuilder<Direction>(),
            new ComponentBuilder<MoveSpeed>(),
            new ComponentBuilder<Rotation>(),
            new ComponentBuilder<ViewReference>()
        };
    }
}