using System;
using System.Linq;
using Code.CubeLayer.Entities.Components;
using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer;
using Code.TimersLayer.Components;
using Svelto.ECS;

namespace Code.UtilityLayer.DataSources.CubeConfig.Attributes.Destroy
{
    public static class DestroyEntityAttributeExtensions
    {
        public static void ApplyToDescriptor<T>(this DestroyEntityAttribute attribute, ref DynamicEntityDescriptor<T> descriptor) where T : IEntityDescriptor, new()
        {
            foreach (DestroyEntityAttribute.IDestroyCondition condition in attribute.Conditions.Distinct())
            {
                switch (condition)
                {
                    case DestroyEntityAttribute.DistanceReachCondition:
                        descriptor.ExtendWith(new IComponentBuilder[]
                        {
                            new ComponentBuilder<DestroyDistance>(),
                            new ComponentBuilder<DistanceTraveled>()
                        });
                        break;
                    case DestroyEntityAttribute.TimeCondition:
                        descriptor.ExtendWith(new IComponentBuilder[]
                        {
                            new ComponentBuilder<Timer<Dead>>()
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(condition));
                }
            }
        }

        public static void ApplyToInitializer(this DestroyEntityAttribute attribute, ref EntityInitializer entityInitializer)
        {
            foreach (DestroyEntityAttribute.IDestroyCondition condition in attribute.Conditions.Distinct())
            {
                switch (condition)
                {
                    case DestroyEntityAttribute.DistanceReachCondition distanceReachCondition:
                        entityInitializer.Init(new DestroyDistance
                        {
                            Value = distanceReachCondition.DestroyDistance.Reference
                        });
                        break;
                    case DestroyEntityAttribute.TimeCondition timeCondition:
                        entityInitializer.Init(new Timer<Dead>()
                        {
                            StartValue = timeCondition.Time.Reference,
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(condition));
                }
            }
        }
    }
}