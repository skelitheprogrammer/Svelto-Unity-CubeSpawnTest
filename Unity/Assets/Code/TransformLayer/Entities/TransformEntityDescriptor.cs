using Code.TransformLayer.Entities.Components;
using Svelto.ECS;

namespace Code.TransformLayer.Entities
{
    public class TransformEntityDescriptor : IEntityDescriptor
    {
        public IComponentBuilder[] componentsToBuild { get; } =
        {
            new ComponentBuilder<Position>(),
            new ComponentBuilder<Rotation>(),
        };
    }
}