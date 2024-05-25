using System;
using System.Linq;
using Code.CubeLayer.Entities.Components;
using Svelto.ECS;

namespace Code.UtilityLayer.DataSources.CubeConfig.Attributes.Revive
{
    public static class ReviveEntityAttributeExtensions
    {
        public static void ApplyToDescriptor<T>(this ReviveEntityAttribute attribute, ref DynamicEntityDescriptor<T> descriptor) where T : IEntityDescriptor, new()
        {
            foreach (ReviveEntityAttribute.IReviveCondition condition in attribute.Conditions.Distinct())
            {
                switch (condition)
                {
                    case ReviveEntityAttribute.ReviveAfterTimeCondition:
                        descriptor.ExtendWith(new[]
                        {
                            new ComponentBuilder<ReviveTimer>(),
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(condition));
                }
            }
        }

        public static void ApplyToInitializer(this ReviveEntityAttribute attribute, ref EntityInitializer entityInitializer)
        {
            foreach (ICondition condition in attribute.Conditions.Distinct())
            {
                switch (condition)
                {
                    case ReviveEntityAttribute.ReviveAfterTimeCondition reviveAfterTimeCondition:
                        entityInitializer.Init(new ReviveTimer
                        {
                            Timer = reviveAfterTimeCondition.Timer.Reference
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(condition));
                }
            }
        }
    }
}