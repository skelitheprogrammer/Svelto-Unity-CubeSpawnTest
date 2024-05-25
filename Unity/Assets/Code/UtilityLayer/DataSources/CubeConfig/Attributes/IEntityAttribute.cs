using System;
using Svelto.ECS;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    public interface IEntityAttribute
    {
    }


    public static class EntityAttributesExtensions
    {
        public static void ApplyAttributesToDescriptor<T>(this IEntityAttribute[] attributes, ref DynamicEntityDescriptor<T> descriptor) where T : IEntityDescriptor, new()
        {
            foreach (IEntityAttribute entityAttribute in attributes)
            {
                switch (entityAttribute)
                {
                    case DestroyEntityAttribute destroyEntityAttribute:
                        destroyEntityAttribute.ApplyToDescriptor(ref descriptor);
                        break;
                    case ReviveEntityAttribute reviveEntityAttribute:
                        reviveEntityAttribute.ApplyToDescriptor(ref descriptor);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(entityAttribute));
                }
            }
        }

        public static void ApplyAttributesToInitializer(this IEntityAttribute[] attributes, ref EntityInitializer initializer)
        {
            foreach (IEntityAttribute entityAttribute in attributes)
            {
                switch (entityAttribute)
                {
                    case DestroyEntityAttribute destroyEntityAttribute:
                        destroyEntityAttribute.ApplyToInitializer(ref initializer);
                        break;
                    case ReviveEntityAttribute reviveEntityAttribute:
                        reviveEntityAttribute.ApplyToInitializer(ref initializer);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(entityAttribute));
                }
            }
        }
    }
}