using Code.CubeLayer.Entities.Components;
using Code.EngineViewSyncLayer.Entities;
using Svelto.ECS;

namespace Code.CubeLayer.Entities
{
    public class CubeEntityDescriptor : ExtendibleEntityDescriptor<ViewEntityDescriptor>
    {
        public CubeEntityDescriptor()
        {
            ExtendWith(new IComponentBuilder[]
            {
                new ComponentBuilder<MoveSpeed>(),
                new ComponentBuilder<MoveDirection>()
            });
        }
    }

    public class CubeWithDistanceTraveledDescriptor : ExtendibleEntityDescriptor<CubeEntityDescriptor>
    {
        public CubeWithDistanceTraveledDescriptor()
        {
            ExtendWith(new IComponentBuilder[]
            {
                new ComponentBuilder<DistanceTraveled>(),
                new ComponentBuilder<DestroyDistance>()
            });
        }
    }
}