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

    public class DestroyableCubeEntityDescriptor : ExtendibleEntityDescriptor<CubeEntityDescriptor>
    {
        public DestroyableCubeEntityDescriptor()
        {
            ExtendWith(new IComponentBuilder[]
            {
                new ComponentBuilder<DestroyDistance>(),
                new ComponentBuilder<DistanceTraveled>(),
            });
        }
    }
}