using Code.EngineViewSyncLayer.Entities.Components;
using Code.TransformLayer.Entities;
using Svelto.ECS;

namespace Code.EngineViewSyncLayer.Entities
{
    public class ViewEntityDescriptor : ExtendibleEntityDescriptor<TransformEntityDescriptor>
    {
        public ViewEntityDescriptor()
        {
            ExtendWith(new IComponentBuilder[]
            {
                new ComponentBuilder<ViewReference>()
            });
        }
    }
}